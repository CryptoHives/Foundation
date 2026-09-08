#!/usr/bin/env python3
"""Regenerates the ML-DSA ACVP conformance vector file used by MLDsaAcvpTests.

Downloads the three NIST ACVP-Server internal projection files for FIPS 204 and
stores them, gzip-compressed, in NIST's own JSON schema. The test groups and
test cases are kept exactly as published -- the only transformation is dropping
whole groups the library has no implementation for. Keeping the upstream shape
means MLDsaAcvpVectors reads real ACVP JSON, and enabling a skipped group later
is a change to the filter below rather than to a bespoke file format.

Only the *external interface, pure ML-DSA* groups are kept. The ACVP files also
carry pre-hash (HashML-DSA), internal-interface and external-mu groups; those are
skipped and counted. That filter, not an arbitrary cap, is what keeps the file
small: it takes sigGen from 360 cases to 90 and sigVer from 180 to 45, so every
case that can actually be run is included.

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

OUT = (pathlib.Path(__file__).resolve().parent.parent
       / "tests" / "Security" / "Cryptography" / "TestData"
       / "mldsa-acvp-fips204.json.gz")

FILTER = "external interface, pure ML-DSA only (no pre-hash, no external mu)"


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


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--limit", type=int, default=0,
                        help="cap test cases per kept group (0 = no cap)")
    args = parser.parse_args()

    documents = []
    kept = skipped = 0

    for url in SOURCES:
        document = fetch(url)
        groups = []

        for group in document["testGroups"]:
            if not is_pure_external(group):
                skipped += len(group["tests"])
                continue

            if args.limit:
                group = dict(group, tests=group["tests"][:args.limit])

            kept += len(group["tests"])
            groups.append(group)

        document["testGroups"] = groups
        documents.append(document)

    payload = {
        "generator": {
            "script": "scripts/fetch-mldsa-acvp-vectors.py",
            "note": "Regenerate with the script above -- do not hand-edit.",
            "sources": SOURCES,
            "filter": FILTER,
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

    OUT.parent.mkdir(parents=True, exist_ok=True)
    OUT.write_bytes(buffer.getvalue())

    print("wrote", OUT, OUT.stat().st_size, "bytes",
          f"({len(plain)} uncompressed)")
    for document in documents:
        cases = sum(len(g["tests"]) for g in document["testGroups"])
        print(f"  {document['mode']}: {len(document['testGroups'])} groups, {cases} cases")
    print(f"  kept {kept}, skipped (pre-hash / internal / external-mu) {skipped}")


if __name__ == "__main__":
    main()
