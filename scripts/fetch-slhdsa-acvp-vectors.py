#!/usr/bin/env python3
"""Regenerates the SLH-DSA ACVP conformance vector file used by SlhDsaAcvpTests.

Downloads the three NIST ACVP-Server internal projection files for FIPS 205 and
stores them, gzip-compressed, in NIST's own JSON schema -- the same shape and the
same envelope as fetch-mldsa-acvp-vectors.py produces, so SlhDsaAcvpVectors and
MLDsaAcvpVectors read identically structured data.

Unlike ML-DSA, the runnable set cannot simply be committed whole. An SLH-DSA
signature is 7,856 to 49,856 bytes, so the same "external interface, pure, no
pre-hash" filter that trims ML-DSA to 2.5 MB leaves SLH-DSA at 11.8 MB gzipped.
Hence two profiles:

  stratified (default)  180 cases, ~2.15 MB  -> committed, embedded in the tests
  full                  456 cases, ~11.8 MB  -> gitignored, fetched on demand

The stratified profile is not a blind cap. It keeps keyGen in full (all 12
parameter sets, 120 cases, 0.02 MB -- essentially free), one sigGen case per
group so every set is covered in both deterministic and hedged form, and for
sigVer one valid case per set plus every failure reason on four representative
sets. Those four span both hash instantiations, both speed variants, all three
security categories, and the SHA-512 split SlhDsaHash uses for categories 3
and 5.

Nothing is lost by defaulting to stratified: run this script with
--profile full and point CRYPTOHIVES_SLHDSA_ACVP_VECTORS at the result to run
every vector the library can execute. The weekly acvp-full-vectors workflow does
exactly that.

Compression is deterministic (mtime zeroed), so regenerating unchanged vectors
produces a byte-identical file rather than a spurious diff.

Source (public, no authentication):
  https://github.com/usnistgov/ACVP-Server
    gen-val/json-files/SLH-DSA-keyGen-FIPS205/internalProjection.json
    gen-val/json-files/SLH-DSA-sigGen-FIPS205/internalProjection.json
    gen-val/json-files/SLH-DSA-sigVer-FIPS205/internalProjection.json

Output shape:

  {
    "generator": { ... provenance ... },
    "documents": [ <upstream keyGen doc>, <upstream sigGen doc>, <upstream sigVer doc> ]
  }

Each document keeps its own ACVP envelope, so the loader dispatches on the
document's own "mode" field and the envelope above carries no schema of its own.

Usage:
  python scripts/fetch-slhdsa-acvp-vectors.py
  python scripts/fetch-slhdsa-acvp-vectors.py --profile full
  python scripts/fetch-slhdsa-acvp-vectors.py --limit 2   # cap cases per kept group
"""
import argparse
import collections
import gzip
import io
import json
import pathlib
import urllib.request

BASE = ("https://raw.githubusercontent.com/usnistgov/ACVP-Server/master/"
        "gen-val/json-files/")
SOURCES = [
    BASE + "SLH-DSA-keyGen-FIPS205/internalProjection.json",
    BASE + "SLH-DSA-sigGen-FIPS205/internalProjection.json",
    BASE + "SLH-DSA-sigVer-FIPS205/internalProjection.json",
]

TEST_DATA = (pathlib.Path(__file__).resolve().parent.parent
             / "tests" / "Security" / "Cryptography" / "TestData")

OUT = {
    "stratified": TEST_DATA / "slhdsa-acvp-fips205.json.gz",
    # Deliberately a different name, and gitignored: an 11.8 MB blob does not
    # belong in git history, and a stray one must never be mistaken for the
    # committed file.
    "full": TEST_DATA / "slhdsa-acvp-fips205.full.json.gz",
}

FILTER = "external interface, pure SLH-DSA only (no pre-hash, no internal interface)"

# Parameter sets that keep every sigVer failure reason under the stratified
# profile. Chosen to span both hash instantiations (SHA2 and SHAKE), both speed
# variants (s and f), all three security categories, and the SHA-512 split that
# SlhDsaHash applies for categories 3 and 5. Every other set still keeps its
# valid case, so no set goes unverified.
SIGVER_FULL_REASON_SETS = frozenset({
    "SLH-DSA-SHA2-128f",
    "SLH-DSA-SHAKE-128f",
    "SLH-DSA-SHA2-192s",
    "SLH-DSA-SHAKE-256f",
})


def fetch(url):
    print("fetching", url)
    with urllib.request.urlopen(url, timeout=600) as response:
        return json.loads(response.read().decode("utf-8"))


def is_pure_external(group):
    """True for the external-interface, pure SLH-DSA groups the library implements.

    The remaining groups are HashSLH-DSA (preHash) and the internal test
    interface, neither of which has an implementation to test yet. keyGen groups
    carry none of these keys and are always kept.
    """
    if "signatureInterface" not in group:
        return True

    return (group.get("signatureInterface") == "external"
            and group.get("preHash") == "pure")


def stratify(mode, group):
    """Selects the cases a stratified build keeps from one already-filtered group."""
    tests = group["tests"]

    if mode == "keyGen":
        # 120 cases for 0.02 MB: keys are two and four n-byte seeds, not signatures.
        return tests

    if mode == "sigGen":
        # One byte-exact known-answer signature per (parameter set, deterministic).
        return tests[:1]

    # sigVer: one case per reason, but the full reason matrix only for the
    # representative sets -- every other set keeps just its valid case.
    every_reason = group["parameterSet"] in SIGVER_FULL_REASON_SETS
    seen = collections.Counter()
    selected = []
    for test in tests:
        if not (every_reason or test["testPassed"]):
            continue
        if seen[test["reason"]]:
            continue
        seen[test["reason"]] += 1
        selected.append(test)
    return selected


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--profile", choices=["stratified", "full"],
                        default="stratified",
                        help="which selection to build (default: stratified)")
    parser.add_argument("--limit", type=int, default=0,
                        help="additionally cap test cases per kept group (0 = no cap)")
    args = parser.parse_args()

    documents = []
    kept = skipped = dropped = 0

    for url in SOURCES:
        document = fetch(url)
        mode = document["mode"]
        groups = []

        for group in document["testGroups"]:
            if not is_pure_external(group):
                skipped += len(group["tests"])
                continue

            tests = group["tests"]
            if args.profile == "stratified":
                selected = stratify(mode, group)
                dropped += len(tests) - len(selected)
                tests = selected

            if args.limit:
                dropped += max(0, len(tests) - args.limit)
                tests = tests[:args.limit]

            kept += len(tests)
            groups.append(dict(group, tests=tests))

        document["testGroups"] = groups
        documents.append(document)

    payload = {
        "generator": {
            "script": "scripts/fetch-slhdsa-acvp-vectors.py",
            "note": "Regenerate with the script above -- do not hand-edit.",
            "sources": SOURCES,
            "filter": FILTER,
            "profile": args.profile,
            "limit": args.limit or None,
        },
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
    print(f"  kept {kept}, skipped (pre-hash / internal interface) {skipped}, "
          f"dropped by profile/limit {dropped}")

    if args.profile == "full":
        print()
        print("Point the tests at this file to run every runnable vector:")
        print(f"  PowerShell: $env:CRYPTOHIVES_SLHDSA_ACVP_VECTORS = '{out}'")
        print(f"  bash:       export CRYPTOHIVES_SLHDSA_ACVP_VECTORS='{out}'")


if __name__ == "__main__":
    main()
