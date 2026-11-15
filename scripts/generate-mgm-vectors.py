#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT OR Apache-2.0
"""Generate Kuznyechik-MGM and Magma-MGM (RFC 9058) test vectors.

No .NET library implements MGM, so the reference is the small MGM below, written from
RFC 9058 section 4 and run over the Kuznyechik and Magma block ciphers of the `gostcrypto`
package. It must reproduce all four RFC 9058 Appendix A examples before anything is written.

    python -m pip install gostcrypto==1.2.5
    python scripts/generate-mgm-vectors.py

Writes tests/Security/Cryptography/TestData/mgm-kuznyechik.json.gz and mgm-magma.json.gz.
"""

import gzip
import json
import random
from pathlib import Path

from gostcrypto.gostcipher import GOST34122015Kuznechik, GOST34122015Magma

TEST_DATA = Path(__file__).resolve().parent.parent / "tests" / "Security" / "Cryptography" / "TestData"

# Field polynomials of RFC 9058 section 3, by block size in bytes.
POLY = {
    16: (1 << 128) | 0x87,  # w^128 + w^7 + w^2 + w + 1
    8: (1 << 64) | 0x1B,    # w^64 + w^4 + w^3 + w + 1
}


def gf_mul(x: int, y: int, block: int) -> int:
    bits = block * 8
    z = 0
    for i in range(bits):
        if (y >> i) & 1:
            z ^= x << i
    for i in range(2 * bits - 2, bits - 1, -1):
        if (z >> i) & 1:
            z ^= POLY[block] << (i - bits)
    return z


def mgm(cipher_type, key: bytes, nonce: bytes, aad: bytes, data: bytes, tag_len: int, encrypt: bool):
    cipher = cipher_type(bytearray(key))
    block = cipher.block_size
    half = block * 4
    half_mask = (1 << half) - 1
    if len(nonce) != block or nonce[0] & 0x80:
        raise ValueError("nonce must be one block with the top bit clear")

    def e(value: int) -> int:
        return int.from_bytes(cipher.encrypt(bytearray(value.to_bytes(block, "big"))), "big")

    icn = int.from_bytes(nonce, "big")
    out = bytearray()
    if data:
        y = e(icn)
        for i in range(0, len(data), block):
            chunk = data[i:i + block]
            ks = e(y).to_bytes(block, "big")
            out += bytes(a ^ b for a, b in zip(chunk, ks))
            y = (y & ~half_mask) | (((y & half_mask) + 1) & half_mask)
    ciphertext = bytes(out) if encrypt else data

    z = e(icn | (1 << (block * 8 - 1)))
    acc = 0

    def absorb(chunk: bytes):
        nonlocal z, acc
        h = e(z)
        acc ^= gf_mul(h, int.from_bytes(chunk.ljust(block, b"\0"), "big"), block)
        z = ((((z >> half) + 1) & half_mask) << half) | (z & half_mask)

    for i in range(0, len(aad), block):
        absorb(aad[i:i + block])
    for i in range(0, len(ciphertext), block):
        absorb(ciphertext[i:i + block])
    absorb(((len(aad) * 8) << half | (len(ciphertext) * 8)).to_bytes(block, "big"))
    tag = e(acc).to_bytes(block, "big")[:tag_len]
    return bytes(out), tag


def h(s: str) -> bytes:
    return bytes.fromhex(s.replace(" ", ""))


def check_rfc9058():
    k = GOST34122015Kuznechik
    key = h("8899AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF")
    nonce = h("1122334455667700FFEEDDCCBBAA9988")
    aad = h("0202020202020202010101010101010104040404040404040303030303030303EA0505050505050505")
    pt = h("1122334455667700FFEEDDCCBBAA998800112233445566778899AABBCCEEFF0A"
           "112233445566778899AABBCCEEFF0A002233445566778899AABBCCEEFF0A0011AABBCC")
    ct, tag = mgm(k, key, nonce, aad, pt, 16, True)
    assert ct == h("A9757B8147956E9055B8A33DE89F42FC8075D2212BF9FD5BD3F7069AADC16B39"
                   "497AB15915A6BA85936B5D0EA9F6851CC60C14D4D3F883D0AB94420695C76DEB2C7552")
    assert tag == h("CF5D656F40C34F5C46E8BB0E29FCDB4C")

    key = h("99AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF88")
    ct, tag = mgm(k, key, nonce, h("01" * 16), b"", 16, True)
    assert ct == b"" and tag == h("7901E9EA2085CD247ED249695F9F8A85")

    m = GOST34122015Magma
    key = h("FFEEDDCCBBAA99887766554433221100F0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF")
    aad = h("01" * 8 + "02" * 8 + "03" * 8 + "04" * 8 + "05" * 8 + "EA")
    pt = h("FFEEDDCCBBAA998811223344556677008899AABBCCEEFF0A0011223344556677"
           "99AABBCCEEFF0A001122334455667788AABBCCEEFF0A00112233445566778899AABBCC")
    ct, tag = mgm(m, key, h("12DEF06B3C130A59"), aad, pt, 8, True)
    assert ct == h("C795066C5F9EA03B85113342459185AE1F2E00D6BF2B785D940470B8BB9C8E7D"
                   "9A5DD3731F7DDC70EC27CB0ACE6FA57670F65C646ABB75D547AA37C3BCB5C34E03BB9C")
    assert tag == h("A7928069AA10FD10")

    key = h("99AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF88")
    ct, tag = mgm(m, key, h("0077665544332211"), b"", h("22334455667700FF"), 8, True)
    assert ct == h("6A95E1426B259D4E") and tag == h("334EE270450BEC9E")


def generate(cipher_type, seed: int, tag_lengths, lengths, path: Path):
    rng = random.Random(seed)
    block = cipher_type(bytearray(32)).block_size
    cases = []
    for pt_len in lengths:
        for aad_len in lengths:
            if pt_len == 0 and aad_len == 0:
                continue
            if rng.random() > 0.4:
                continue
            tag_len = rng.choice(tag_lengths)
            key = rng.randbytes(32)
            nonce = bytearray(rng.randbytes(block))
            nonce[0] &= 0x7F
            aad = rng.randbytes(aad_len)
            pt = rng.randbytes(pt_len)
            ct, tag = mgm(cipher_type, key, bytes(nonce), aad, pt, tag_len, True)
            cases.append({
                "key": key.hex().upper(), "nonce": bytes(nonce).hex().upper(),
                "aad": aad.hex().upper(), "pt": pt.hex().upper(),
                "ct": ct.hex().upper(), "tag": tag.hex().upper(),
            })
    name = "Kuznyechik" if block == 16 else "Magma"
    doc = {
        "source": f"scripts/generate-mgm-vectors.py: RFC 9058 MGM over gostcrypto 1.2.5 {name}, seed {seed}",
        "tests": cases,
    }
    path.parent.mkdir(parents=True, exist_ok=True)
    with gzip.GzipFile(path, "wb", mtime=0) as f:
        f.write(json.dumps(doc, indent=1).encode())
    print(f"{len(cases)} cases -> {path}")


def main():
    check_rfc9058()
    generate(GOST34122015Kuznechik, 9058, [4, 8, 12, 16], [0, 1, 15, 16, 17, 31, 32, 33, 64, 100],
             TEST_DATA / "mgm-kuznyechik.json.gz")
    generate(GOST34122015Magma, 8891, [4, 6, 8], [0, 1, 7, 8, 9, 15, 16, 17, 32, 100],
             TEST_DATA / "mgm-magma.json.gz")


if __name__ == "__main__":
    main()
