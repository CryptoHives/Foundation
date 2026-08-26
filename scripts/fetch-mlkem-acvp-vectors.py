#!/usr/bin/env python3
"""Regenerates the ML-KEM ACVP conformance vector file used by MLKemAcvpTests.

Downloads the two NIST ACVP-Server internal projection files for FIPS 203 and
flattens every test case into a gzip-compressed, pipe-delimited text file. The
format is deliberately not JSON: the test project targets net48, where
System.Text.Json is not available without an extra package reference, and
String.Split needs no dependency at all.

The output is gzipped because the flattened vectors are about 1.7 MB of hex --
ML-KEM-1024 alone carries roughly 9.6 KB per key generation case. Compression
is deterministic (mtime zeroed), so regenerating unchanged vectors produces a
byte-identical file rather than a spurious diff.

Source (public, no authentication):
  https://github.com/usnistgov/ACVP-Server
    gen-val/json-files/ML-KEM-keyGen-FIPS203/internalProjection.json
    gen-val/json-files/ML-KEM-encapDecap-FIPS203/internalProjection.json

Record format, one per line, '#' introduces a comment:

  K|<parameterSet>|<tcId>|<d>|<z>|<ek>|<dk>          key generation
  E|<parameterSet>|<tcId>|<ek>|<dk>|<m>|<c>|<k>      encapsulation
  D|<parameterSet>|<tcId>|<reason>|<dk>|<c>|<k>      decapsulation
  X|<parameterSet>|<tcId>|<pass>|<reason>|<ek>       encapsulation key check
  Y|<parameterSet>|<tcId>|<pass>|<reason>|<dk>       decapsulation key check

Usage:
  python scripts/fetch-mlkem-acvp-vectors.py
"""
import gzip
import io
import json
import pathlib
import urllib.request

BASE = ("https://raw.githubusercontent.com/usnistgov/ACVP-Server/master/"
        "gen-val/json-files/")
KEYGEN = BASE + "ML-KEM-keyGen-FIPS203/internalProjection.json"
ENCAPDECAP = BASE + "ML-KEM-encapDecap-FIPS203/internalProjection.json"

OUT = (pathlib.Path(__file__).resolve().parent.parent
       / "tests" / "Security" / "Cryptography" / "TestData"
       / "mlkem-acvp-fips203.txt.gz")


def fetch(url):
    print("fetching", url)
    with urllib.request.urlopen(url, timeout=180) as response:
        return json.loads(response.read().decode("utf-8"))


def clean(value):
    """ACVP reason strings are free text; keep them delimiter-safe."""
    return (value or "").replace("|", "/").strip()


def main():
    keygen = fetch(KEYGEN)
    encapdecap = fetch(ENCAPDECAP)

    lines = [
        "# ML-KEM (FIPS 203) conformance vectors from the NIST ACVP-Server project.",
        "# Regenerate with scripts/fetch-mlkem-acvp-vectors.py -- do not hand-edit.",
        "# Source: https://github.com/usnistgov/ACVP-Server",
        "#   gen-val/json-files/ML-KEM-keyGen-FIPS203/internalProjection.json",
        "#   gen-val/json-files/ML-KEM-encapDecap-FIPS203/internalProjection.json",
        "#",
        "# K|set|tcId|d|z|ek|dk          E|set|tcId|ek|dk|m|c|k",
        "# D|set|tcId|reason|dk|c|k      X|set|tcId|pass|reason|ek",
        "# Y|set|tcId|pass|reason|dk",
    ]

    counts = {}

    def add(kind, *fields):
        counts[kind] = counts.get(kind, 0) + 1
        lines.append("|".join([kind] + [str(f) for f in fields]))

    for group in keygen["testGroups"]:
        parameter_set = group["parameterSet"]
        for test in group["tests"]:
            add("K", parameter_set, test["tcId"],
                test["d"], test["z"], test["ek"], test["dk"])

    for group in encapdecap["testGroups"]:
        parameter_set = group["parameterSet"]
        function = group["function"]
        for test in group["tests"]:
            if function == "encapsulation":
                add("E", parameter_set, test["tcId"],
                    test["ek"], test["dk"], test["m"], test["c"], test["k"])
            elif function == "decapsulation":
                add("D", parameter_set, test["tcId"], clean(test.get("reason")),
                    test["dk"], test["c"], test["k"])
            elif function == "encapsulationKeyCheck":
                add("X", parameter_set, test["tcId"],
                    "true" if test["testPassed"] else "false",
                    clean(test.get("reason")), test["ek"])
            elif function == "decapsulationKeyCheck":
                add("Y", parameter_set, test["tcId"],
                    "true" if test["testPassed"] else "false",
                    clean(test.get("reason")), test["dk"])
            else:
                raise SystemExit("unknown function: " + function)

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


if __name__ == "__main__":
    main()
