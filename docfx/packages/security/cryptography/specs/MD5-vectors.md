# MD5 Test Vectors (RFC 1321)

## ⚠️ Security Warning

**MD5 is cryptographically broken and should NOT be used for security purposes.**

MD5 is provided only for:
- Legacy system compatibility
- Non-cryptographic checksums
- Historical reference

For security applications, use SHA-256 or stronger algorithms.

## Test Vectors from RFC 1321

| Input | Output (Hex) |
|-------|--------------|
| "" | `d41d8cd98f00b204e9800998ecf8427e` |
| "a" | `0cc175b9c0f1b6a831c399e269772661` |
| "abc" | `900150983cd24fb0d6963f7d28e17f72` |
| "message digest" | `f96b697d7cb7938d525a2f31aaf161d0` |
| "abcdefghijklmnopqrstuvwxyz" | `c3fcd3d76192e4007dfb496cca67e13b` |
| "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789" | `d174ab98d277d9f5a5611c2c9f419d9f` |
| "12345678901234567890123456789012345678901234567890123456789012345678901234567890" | `57edf4a22be3c955ac49da2e2107b67a` |

## Algorithm Details

- **Output Size:** 128 bits (16 bytes)
- **Block Size:** 512 bits (64 bytes)
- **Rounds:** 64
- **Endianness:** Little-endian

## References

- RFC 1321: https://www.ietf.org/rfc/rfc1321.txt
- BouncyCastle MD5Digest: Used as reference implementation

## Known Vulnerabilities

1. **Collision Attacks:** Practical collision attacks exist (2004)
2. **Chosen-Prefix Attacks:** Enables creating files with identical MD5 hashes
3. **Length Extension Attacks:** Vulnerable to length extension attacks

Do not use MD5 for:
- Password hashing
- Digital signatures
- Certificate verification
- Any security-critical application
