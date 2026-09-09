#!/usr/bin/env python3
"""Regenerates the ML-KEM ACVP conformance vector file used by MLKemAcvpTests.

Downloads the two NIST ACVP-Server internal projection files for FIPS 203 and
stores them, gzip-compressed, in NIST's own JSON schema. Nothing is filtered:
every ML-KEM group -- key generation, encapsulation, decapsulation and both key
checks -- has an implementation to test, so the stored documents are the upstream
ones verbatim. Keeping the upstream shape means MLKemAcvpVectors reads real ACVP
JSON rather than a bespoke file format.

The output is gzipped because the vectors run to megabytes of hex -- ML-KEM-1024
alone carries roughly 9.6 KB per key generation case. Compression is
deterministic (mtime zeroed), so regenerating unchanged vectors produces a
byte-identical file rather than a spurious diff.

Source (public, no authentication):
  https://github.com/usnistgov/ACVP-Server
    gen-val/json-files/ML-KEM-keyGen-FIPS203/internalProjection.json
    gen-val/json-files/ML-KEM-encapDecap-FIPS203/internalProjection.json

Output shape:

  {
    "generator": { ... provenance ... },
    "documents": [ <upstream keyGen doc>, <upstream encapDecap doc> ]
  }

Each document keeps its own ACVP envelope, so the loader dispatches on the
document's own "mode" field and the envelope above carries no schema of its own.

Usage:
  python scripts/fetch-mlkem-acvp-vectors.py
  python scripts/fetch-mlkem-acvp-vectors.py --limit 5   # cap cases per group
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
    BASE + "ML-KEM-keyGen-FIPS203/internalProjection.json",
    BASE + "ML-KEM-encapDecap-FIPS203/internalProjection.json",
]

OUT = (pathlib.Path(__file__).resolve().parent.parent
       / "tests" / "Security" / "Cryptography" / "TestData"
       / "mlkem-acvp-fips203.json.gz")


def fetch(url):
    print("fetching", url)
    with urllib.request.urlopen(url, timeout=300) as response:
        return json.loads(response.read().decode("utf-8"))


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--limit", type=int, default=0,
                        help="cap test cases per group (0 = no cap)")
    args = parser.parse_args()

    documents = []

    for url in SOURCES:
        document = fetch(url)

        if args.limit:
            document["testGroups"] = [
                dict(group, tests=group["tests"][:args.limit])
                for group in document["testGroups"]
            ]

        documents.append(document)

    payload = {
        "generator": {
            "script": "scripts/fetch-mlkem-acvp-vectors.py",
            "note": "Regenerate with the script above -- do not hand-edit.",
            "sources": SOURCES,
            "filter": "none -- every ML-KEM group has an implementation",
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


if __name__ == "__main__":
    main()
