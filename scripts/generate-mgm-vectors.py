#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT OR Apache-2.0
"""Generate Kuznyechik-MGM (RFC 9058) test vectors.

No .NET library implements MGM, so the reference is the small MGM below, written from
RFC 9058 section 4 and run over the Kuznyechik block cipher of the `gostcrypto` package.
It must reproduce both RFC 9058 Appendix A.1 examples before anything is written.

    python -m pip install gostcrypto==1.2.5
    python scripts/generate-mgm-vectors.py

Writes tests/Security/Cryptography/TestData/mgm-kuznyechik.json.gz.
"""

import gzip
import json
import random
from pathlib import Path

from gostcrypto.gostcipher import GOST34122015Kuznechik

OUTPUT = Path(__file__).resolve().parent.parent / "tests" / "Security" / "Cryptography" / "TestData" / "mgm-kuznyechik.json.gz"

BLOCK = 16
MASK64 = (1 << 64) - 1
POLY = (1 << 128) | 0x87  # w^128 + w^7 + w^2 + w + 1


def gf_mul(x: int, y: int) -> int:
    z = 0
    for i in range(128):
        if (y >> i) & 1:
            z ^= x << i
    for i in range(254, 127, -1):
        if (z >> i) & 1:
            z ^= POLY << (i - 128)
    return z


def mgm(key: bytes, nonce: bytes, aad: bytes, data: bytes, tag_len: int, encrypt: bool):
    if len(nonce) != BLOCK or nonce[0] & 0x80:
        raise ValueError("nonce must be 16 bytes with the top bit clear")
    cipher = GOST34122015Kuznechik(bytearray(key))

    def e(block: int) -> int:
        return int.from_bytes(cipher.encrypt(bytearray(block.to_bytes(BLOCK, "big"))), "big")

    icn = int.from_bytes(nonce, "big")
    out = bytearray()
    if data:
        y = e(icn)
        for i in range(0, len(data), BLOCK):
            chunk = data[i:i + BLOCK]
            ks = e(y).to_bytes(BLOCK, "big")
            out += bytes(a ^ b for a, b in zip(chunk, ks))
            y = (y & ~MASK64) | (((y & MASK64) + 1) & MASK64)
    ciphertext = bytes(out) if encrypt else data

    z = e(icn | (1 << 127))
    acc = 0

    def absorb(block: bytes):
        nonlocal z, acc
        h = e(z)
        acc ^= gf_mul(h, int.from_bytes(block.ljust(BLOCK, b"\0"), "big"))
        z = ((((z >> 64) + 1) & MASK64) << 64) | (z & MASK64)

    for i in range(0, len(aad), BLOCK):
        absorb(aad[i:i + BLOCK])
    for i in range(0, len(ciphertext), BLOCK):
        absorb(ciphertext[i:i + BLOCK])
    absorb(((len(aad) * 8) << 64 | (len(ciphertext) * 8)).to_bytes(BLOCK, "big"))
    tag = e(acc).to_bytes(BLOCK, "big")[:tag_len]
    return bytes(out), tag


def h(s: str) -> bytes:
    return bytes.fromhex(s.replace(" ", ""))


def check_rfc9058():
    key = h("8899AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF")
    nonce = h("1122334455667700FFEEDDCCBBAA9988")
    aad = h("0202020202020202010101010101010104040404040404040303030303030303EA0505050505050505")
    pt = h("1122334455667700FFEEDDCCBBAA998800112233445566778899AABBCCEEFF0A"
           "112233445566778899AABBCCEEFF0A002233445566778899AABBCCEEFF0A0011AABBCC")
    ct, tag = mgm(key, nonce, aad, pt, 16, True)
    assert ct == h("A9757B8147956E9055B8A33DE89F42FC8075D2212BF9FD5BD3F7069AADC16B39"
                   "497AB15915A6BA85936B5D0EA9F6851CC60C14D4D3F883D0AB94420695C76DEB2C7552")
    assert tag == h("CF5D656F40C34F5C46E8BB0E29FCDB4C")

    key = h("99AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF88")
    ct, tag = mgm(key, nonce, h("01" * 16), b"", 16, True)
    assert ct == b"" and tag == h("7901E9EA2085CD247ED249695F9F8A85")


def main():
    check_rfc9058()
    rng = random.Random(9058)
    lengths = [0, 1, 15, 16, 17, 31, 32, 33, 64, 100]
    cases = []
    for pt_len in lengths:
        for aad_len in lengths:
            if pt_len == 0 and aad_len == 0:
                continue
            if rng.random() > 0.4:
                continue
            tag_len = rng.choice([4, 8, 12, 16])
            key = rng.randbytes(32)
            nonce = bytearray(rng.randbytes(16))
            nonce[0] &= 0x7F
            aad = rng.randbytes(aad_len)
            pt = rng.randbytes(pt_len)
            ct, tag = mgm(key, bytes(nonce), aad, pt, tag_len, True)
            cases.append({
                "key": key.hex().upper(), "nonce": bytes(nonce).hex().upper(),
                "aad": aad.hex().upper(), "pt": pt.hex().upper(),
                "ct": ct.hex().upper(), "tag": tag.hex().upper(),
            })
    doc = {
        "source": "scripts/generate-mgm-vectors.py: RFC 9058 MGM over gostcrypto 1.2.5 Kuznyechik, seed 9058",
        "tests": cases,
    }
    OUTPUT.parent.mkdir(parents=True, exist_ok=True)
    with gzip.GzipFile(OUTPUT, "wb", mtime=0) as f:
        f.write(json.dumps(doc, indent=1).encode())
    print(f"{len(cases)} cases -> {OUTPUT}")


if __name__ == "__main__":
    main()
