#!/usr/bin/env python3
"""Regenerates the ML-DSA ACVP conformance vector file used by MLDsaAcvpTests.

Downloads the three NIST ACVP-Server internal projection files for FIPS 204 and
stores them, gzip-compressed, in NIST's own JSON schema. The test groups and
test cases are kept exactly as published -- the only transformation is dropping
whole groups the library has no implementation for. Keeping the upstream shape
means MLDsaAcvpVectors reads real ACVP JSON, and enabling a skipped group later
is a change to the filter below rather than to a bespoke file format.

By default only the *external interface, pure ML-DSA* groups are kept. The ACVP
files also carry pre-hash (HashML-DSA), internal-interface and external-mu
groups; those are skipped and counted. That filter, not an arbitrary cap, is what
keeps the file small: it takes sigGen from 360 cases to 90 and sigVer from 180 to
45, so every case that can actually be run is included.

The pre-hash groups (HashML-DSA, FIPS 204 section 5.4) are now implemented too,
and are fetched by their own profiles into their own files -- rather than merged
into the pure one, whose already-committed 2.5 MB blob would then be rewritten on
every regeneration:

  pure (default)  135 cases, ~2.53 MB  -> committed, embedded in the tests
  prehash          57 cases, ~0.88 MB  -> committed, embedded in the tests
  prehash-full    135 cases, ~2.11 MB  -> gitignored, fetched on demand

The prehash profile is chosen by rule, not by cap: sigGen keeps every
(parameter set, pre-hash function) pair exactly once -- 3 x 12 -- splitting them
between the deterministic and hedged groups by pre-hash index parity so both
signing modes are covered for every set; sigVer keeps one valid case per
(set, pre-hash function) plus every failure reason. Run with --profile
prehash-full and point CRYPTOHIVES_MLDSA_PREHASH_ACVP_VECTORS at the result to
execute all 135.

The output is gzipped because the vectors run to megabytes of hex -- ACVP
messages alone are up to ~7 KB each. Compression is deterministic (mtime zeroed),
so regenerating unchanged vectors produces a byte-identical file rather than a
spurious diff.

Source (public, no authentication):
  https://github.com/usnistgov/ACVP-Server
    gen-val/json-files/ML-DSA-keyGen-FIPS204/internalProjection.json
    gen-val/json-files/ML-DSA-sigGen-FIPS204/internalProjection.json
    gen-val/json-files/ML-DSA-sigVer-FIPS204/internalProjection.json

Output shape:

  {
    "generator": { ... provenance ... },
    "documents": [ <upstream keyGen doc>, <upstream sigGen doc>, <upstream sigVer doc> ]
  }

Each document keeps its own ACVP envelope, so the loader dispatches on the
document's own "mode" field and the envelope above carries no schema of its own.

Usage:
  python scripts/fetch-mldsa-acvp-vectors.py
  python scripts/fetch-mldsa-acvp-vectors.py --limit 5   # cap cases per kept group
"""
import argparse
import gzip
import io
import json
import pathlib
import urllib.request

BASE = ("https://raw.githubusercontent.com/usnistgov/ACVP-Server/master/"
        "gen-val/json-files/")
SOURCES = [
    BASE + "ML-DSA-keyGen-FIPS204/internalProjection.json",
    BASE + "ML-DSA-sigGen-FIPS204/internalProjection.json",
    BASE + "ML-DSA-sigVer-FIPS204/internalProjection.json",
]

TEST_DATA = (pathlib.Path(__file__).resolve().parent.parent
             / "tests" / "Security" / "Cryptography" / "TestData")

OUT = {
    "pure": TEST_DATA / "mldsa-acvp-fips204.json.gz",
    "prehash": TEST_DATA / "mldsa-prehash-acvp-fips204.json.gz",
    # Gitignored: a stray full set must never be mistaken for the committed one.
    "prehash-full": TEST_DATA / "mldsa-prehash-acvp-fips204.full.json.gz",
}

PREHASH_PROFILES = ("prehash", "prehash-full")

FILTER = "external interface, pure ML-DSA only (no pre-hash, no external mu)"

PREHASH_FILTER = "external interface, HashML-DSA (pre-hash) only"

# The twelve approved pre-hash functions, in OID order (FIPS 204 section 5.4).
# Index parity decides whether a pair is taken from the deterministic or the
# hedged group, so all twelve appear in both modes across the three sets.
PREHASH_HASHES = (
    "SHA2-224", "SHA2-256", "SHA2-384", "SHA2-512", "SHA2-512/224", "SHA2-512/256",
    "SHA3-224", "SHA3-256", "SHA3-384", "SHA3-512", "SHAKE-128", "SHAKE-256",
)


def fetch(url):
    print("fetching", url)
    with urllib.request.urlopen(url, timeout=300) as response:
        return json.loads(response.read().decode("utf-8"))


def is_pure_external(group):
    """True for the external-interface, pure ML-DSA groups the library implements.

    The remaining groups are HashML-DSA (preHash), the internal test interface,
    and external-mu signing -- none of which have an implementation to test yet.
    keyGen groups carry none of these keys and are always kept.
    """
    if "signatureInterface" not in group:
        return True

    return (group.get("signatureInterface") == "external"
            and group.get("preHash") == "pure"
            and not group.get("externalMu", False))


def is_prehash_external(group):
    """True for the external-interface HashML-DSA groups.

    The mirror of is_pure_external. keyGen carries no prehash groups at all,
    which is why the prehash profiles fetch only sigGen and sigVer.
    """
    return (group.get("signatureInterface") == "external"
            and group.get("preHash") == "preHash"
            and not group.get("externalMu", False))


def stratify_prehash(mode, group):
    """Selects the cases a prehash build keeps from one already-filtered group."""
    tests = group["tests"]

    if mode == "sigGen":
        # Every (parameter set, pre-hash function) pair exactly once. Even-indexed
        # functions come from the deterministic group and odd-indexed from the
        # hedged one, so both signing modes are exercised for every set without
        # paying for the full 72-case cross product.
        deterministic = bool(group.get("deterministic"))
        selected = []
        seen = set()
        for test in tests:
            hash_alg = test.get("hashAlg")
            if hash_alg in seen or hash_alg not in PREHASH_HASHES:
                continue
            if (PREHASH_HASHES.index(hash_alg) % 2 == 0) != deterministic:
                continue
            seen.add(hash_alg)
            selected.append(test)
        return selected

    # sigVer: one valid case per pre-hash function, plus every failure reason.
    selected = []
    seen_valid = set()
    seen_reasons = set()
    for test in tests:
        if test["testPassed"]:
            hash_alg = test.get("hashAlg")
            if hash_alg in seen_valid:
                continue
            seen_valid.add(hash_alg)
        else:
            if test["reason"] in seen_reasons:
                continue
            seen_reasons.add(test["reason"])
        selected.append(test)
    return selected


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--profile", choices=["pure", "prehash", "prehash-full"],
                        default="pure",
                        help="which selection to build (default: pure)")
    parser.add_argument("--limit", type=int, default=0,
                        help="cap test cases per kept group (0 = no cap)")
    args = parser.parse_args()

    prehash = args.profile in PREHASH_PROFILES
    # keyGen has no pre-hash notion at all, so the prehash profiles skip that
    # document rather than emitting an empty one.
    sources = [u for u in SOURCES if not (prehash and "keyGen" in u)]

    documents = []
    kept = skipped = dropped = 0

    for url in sources:
        document = fetch(url)
        mode = document["mode"]
        keep_group = is_prehash_external if prehash else is_pure_external
        groups = []

        for group in document["testGroups"]:
            if not keep_group(group):
                skipped += len(group["tests"])
                continue

            tests = group["tests"]
            if args.profile == "prehash":
                selected = stratify_prehash(mode, group)
                dropped += len(tests) - len(selected)
                tests = selected

            if args.limit:
                dropped += max(0, len(tests) - args.limit)
                tests = tests[:args.limit]

            kept += len(tests)
            groups.append(dict(group, tests=tests))

        document["testGroups"] = groups
        documents.append(document)

    generator = {
        "script": "scripts/fetch-mldsa-acvp-vectors.py",
        "note": "Regenerate with the script above -- do not hand-edit.",
        "sources": sources,
        "filter": PREHASH_FILTER if prehash else FILTER,
        "limit": args.limit or None,
    }
    # Only the prehash profiles record a "profile" key. Adding one to the pure
    # envelope would change every byte of the already-committed 2.5 MB file for
    # no gain, and byte-stable regeneration is the point of this script.
    if prehash:
        generator["profile"] = args.profile

    payload = {
        "generator": generator,
        "documents": documents,
    }

    # Compact separators: the file is gzipped and machine-read, so the whitespace
    # would be pure overhead.
    plain = json.dumps(payload, separators=(",", ":")).encode("utf-8")

    # mtime=0 keeps the output byte-stable across regenerations.
    buffer = io.BytesIO()
    with gzip.GzipFile(fileobj=buffer, mode="wb", compresslevel=9, mtime=0) as f:
        f.write(plain)

    out = OUT[args.profile]
    out.parent.mkdir(parents=True, exist_ok=True)
    out.write_bytes(buffer.getvalue())

    print("wrote", out, out.stat().st_size, "bytes",
          f"({len(plain)} uncompressed)")
    for document in documents:
        cases = sum(len(g["tests"]) for g in document["testGroups"])
        print(f"  {document['mode']}: {len(document['testGroups'])} groups, {cases} cases")
    skipped_note = ("pure / internal / external-mu" if prehash
                    else "pre-hash / internal / external-mu")
    print(f"  kept {kept}, skipped ({skipped_note}) {skipped}, "
          f"dropped by profile/limit {dropped}")

    if args.profile == "prehash-full":
        print()
        print("Point the tests at this file to run every runnable vector:")
        print(f"  PowerShell: $env:CRYPTOHIVES_MLDSA_PREHASH_ACVP_VECTORS = '{out}'")
        print(f"  bash:       export CRYPTOHIVES_MLDSA_PREHASH_ACVP_VECTORS='{out}'")


if __name__ == "__main__":
    main()
