#!/usr/bin/env python3
"""Regenerates the ML-DSA ACVP conformance vector file used by MLDsaAcvpTests.

Downloads the three NIST ACVP-Server internal projection files for FIPS 204 and
flattens the relevant test cases into a gzip-compressed, pipe-delimited text
file. The format matches scripts/fetch-mlkem-acvp-vectors.py and is deliberately
not JSON: the test project targets net48, where System.Text.Json is not
available without an extra package reference, and String.Split needs no
dependency at all.

Only the *external interface, pure ML-DSA* groups are emitted -- the ones the
library implements today. The ACVP files also carry pre-hash (HashML-DSA),
internal-interface and external-mu groups; those are skipped and counted, so
adding them later is a filter change rather than a format change. That filter,
not an arbitrary cap, is what keeps the artifact small: it takes sigGen from 360
cases to 90 and sigVer from 180 to 45, so every case we can actually run is
included.

The output is gzipped because the flattened vectors run to several megabytes of
hex -- ACVP messages alone are up to ~7 KB each. Compression is deterministic
(mtime zeroed), so regenerating unchanged vectors produces a byte-identical file
rather than a spurious diff.

Source (public, no authentication):
  https://github.com/usnistgov/ACVP-Server
    gen-val/json-files/ML-DSA-keyGen-FIPS204/internalProjection.json
    gen-val/json-files/ML-DSA-sigGen-FIPS204/internalProjection.json
    gen-val/json-files/ML-DSA-sigVer-FIPS204/internalProjection.json

Record format, one per line, '#' introduces a comment:

  K|<parameterSet>|<tcId>|<seed>|<pk>|<sk>                                key generation
  S|<parameterSet>|<tcId>|<deterministic>|<sk>|<message>|<context>|<rnd>|<signature>
                                                                         signature generation
  V|<parameterSet>|<tcId>|<pass>|<reason>|<pk>|<message>|<context>|<signature>
                                                                         signature verification

'rnd' is empty for deterministic signature generation rows, where FIPS 204 fixes
it to 32 zero bytes.

Usage:
  python scripts/fetch-mldsa-acvp-vectors.py
  python scripts/fetch-mldsa-acvp-vectors.py --limit 5   # cap sigGen/sigVer per group
"""
import argparse
import gzip
import io
import json
import pathlib
import urllib.request

BASE = ("https://raw.githubusercontent.com/usnistgov/ACVP-Server/master/"
        "gen-val/json-files/")
KEYGEN = BASE + "ML-DSA-keyGen-FIPS204/internalProjection.json"
SIGGEN = BASE + "ML-DSA-sigGen-FIPS204/internalProjection.json"
SIGVER = BASE + "ML-DSA-sigVer-FIPS204/internalProjection.json"

OUT = (pathlib.Path(__file__).resolve().parent.parent
       / "tests" / "Security" / "Cryptography" / "TestData"
       / "mldsa-acvp-fips204.txt.gz")


def fetch(url):
    print("fetching", url)
    with urllib.request.urlopen(url, timeout=300) as response:
        return json.loads(response.read().decode("utf-8"))


def clean(value):
    """ACVP reason strings are free text; keep them delimiter-safe."""
    return (value or "").replace("|", "/").strip()


def is_pure_external(group):
    """True for the external-interface, pure ML-DSA groups the library implements.

    The remaining groups are HashML-DSA (preHash), the internal test interface,
    and external-mu signing -- none of which have an implementation to test yet.
    """
    return (group.get("signatureInterface") == "external"
            and group.get("preHash") == "pure"
            and not group.get("externalMu", False))


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--limit", type=int, default=0,
                        help="cap signature cases per test group (0 = no cap)")
    args = parser.parse_args()

    keygen = fetch(KEYGEN)
    siggen = fetch(SIGGEN)
    sigver = fetch(SIGVER)

    limit_note = (f"# sigGen/sigVer capped at {args.limit} cases per group."
                  if args.limit else
                  "# Every external-interface pure ML-DSA case is included; no cap applied.")

    lines = [
        "# ML-DSA (FIPS 204) conformance vectors from the NIST ACVP-Server project.",
        "# Regenerate with scripts/fetch-mldsa-acvp-vectors.py -- do not hand-edit.",
        "# Source: https://github.com/usnistgov/ACVP-Server",
        "#   gen-val/json-files/ML-DSA-keyGen-FIPS204/internalProjection.json",
        "#   gen-val/json-files/ML-DSA-sigGen-FIPS204/internalProjection.json",
        "#   gen-val/json-files/ML-DSA-sigVer-FIPS204/internalProjection.json",
        "#",
        "# External interface, pure ML-DSA only: pre-hash (HashML-DSA), the internal",
        "# test interface and external-mu groups are skipped, having no implementation yet.",
        limit_note,
        "#",
        "# K|set|tcId|seed|pk|sk",
        "# S|set|tcId|deterministic|sk|message|context|rnd|signature",
        "# V|set|tcId|pass|reason|pk|message|context|signature",
    ]

    counts = {}
    skipped = 0

    def add(kind, *fields):
        counts[kind] = counts.get(kind, 0) + 1
        lines.append("|".join([kind] + [str(f) for f in fields]))

    for group in keygen["testGroups"]:
        parameter_set = group["parameterSet"]
        for test in group["tests"]:
            add("K", parameter_set, test["tcId"],
                test["seed"], test["pk"], test["sk"])

    for group in siggen["testGroups"]:
        if not is_pure_external(group):
            skipped += len(group["tests"])
            continue

        parameter_set = group["parameterSet"]
        deterministic = bool(group["deterministic"])
        tests = group["tests"]
        if args.limit:
            tests = tests[:args.limit]

        for test in tests:
            # Deterministic signing fixes rnd to 32 zero bytes, so ACVP omits it.
            add("S", parameter_set, test["tcId"],
                "true" if deterministic else "false",
                test["sk"], test["message"], test.get("context", ""),
                test.get("rnd", ""), test["signature"])

    for group in sigver["testGroups"]:
        if not is_pure_external(group):
            skipped += len(group["tests"])
            continue

        parameter_set = group["parameterSet"]
        tests = group["tests"]
        if args.limit:
            tests = tests[:args.limit]

        for test in tests:
            add("V", parameter_set, test["tcId"],
                "true" if test["testPassed"] else "false",
                clean(test.get("reason")),
                test["pk"], test["message"], test.get("context", ""),
                test["signature"])

    plain = ("\n".join(lines) + "\n").encode("utf-8")

    # mtime=0 keeps the output byte-stable across regenerations.
    buffer = io.BytesIO()
    with gzip.GzipFile(fileobj=buffer, mode="wb", compresslevel=9, mtime=0) as f:
        f.write(plain)

    OUT.parent.mkdir(parents=True, exist_ok=True)
    OUT.write_bytes(buffer.getvalue())

    print("wrote", OUT, OUT.stat().st_size, "bytes",
          f"({len(plain)} uncompressed)")
    for kind in sorted(counts):
        print(f"  {kind}: {counts[kind]}")
    print(f"  skipped (pre-hash / internal / external-mu): {skipped}")


if __name__ == "__main__":
    main()
