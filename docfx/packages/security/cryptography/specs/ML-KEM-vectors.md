# ML-KEM Test Vectors

## Source

NIST ACVP (Automated Cryptographic Validation Protocol) validation vector sets for FIPS 203:

- [**ML-KEM-keyGen-FIPS203**](https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/ML-KEM-keyGen-FIPS203)
- [**ML-KEM-encapDecap-FIPS203**](https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/ML-KEM-encapDecap-FIPS203)

The vectors are stored in **NIST's own ACVP JSON schema** in
`tests/Security/Cryptography/TestData/mlkem-acvp-fips203.json.gz`, and read at run time by
`MLKemAcvpVectors` with `System.Text.Json`. Nothing is filtered — every ML-KEM group has an
implementation to test — so the file holds the upstream keyGen and encapDecap documents verbatim,
behind a small envelope recording provenance. Every NUnit case is named after its parameter set
and the `tcId` of the original ACVP vector file, so a failure traces straight back to the NIST
source.

It is a data file rather than C# literals because ML-KEM-1024 alone carries ~9.6 KB of hex per key
generation case, and gzipped because the JSON is ~2 MB, compressing to ~815 KB. Regenerate it with
`scripts/fetch-mlkem-acvp-vectors.py`, which zeroes the gzip mtime so regenerating unchanged
vectors produces a byte-identical file rather than a spurious diff.

---

## Coverage

For **each** of ML-KEM-512, ML-KEM-768, and ML-KEM-1024:

| Operation | ACVP group | What is verified |
|-----------|-----------|------------------|
| Key generation (AFT) | keyGen | Seed (d, z) → byte-exact ek and dk |
| Encapsulation (AFT) | encapsulation | (ek, m) → byte-exact ciphertext c and shared secret k, plus decapsulation of the same vector |
| Decapsulation (VAL) | decapsulation | (dk, c) → byte-exact k for *valid decapsulation* **and** *modified ciphertext* cases — the latter validate the implicit-rejection output K̄ = J(z ‖ c) exactly |
| Encapsulation key check (VAL) | encapsulationKeyCheck | FIPS 203 §7.2 modulus check accepts valid keys and rejects *"noisy linear system values too large"* keys |
| Decapsulation key check (VAL) | decapsulationKeyCheck | FIPS 203 §7.3 hash check accepts valid keys and rejects *"modified H"* keys |

## Cross-Validation (Interop)

In addition to the ACVP known-answer tests, `MLKemTests`/`MLKemInteropTests` cross-validate against independent implementations on every target framework:

| Peer | Tests |
|------|-------|
| **BouncyCastle 2.6+** | Same-seed key generation produces byte-identical ek and expanded dk (`MLKemPrivateKeyParameters.FromSeed`); encapsulate ↔ decapsulate round-trips in both directions; implicit-rejection outputs for tampered ciphertexts match byte-for-byte; randomized multi-trial round-trips |
| **.NET 10 `System.Security.Cryptography.MLKem`** (where OS-supported) | Same-seed keys match the CNG/OpenSSL implementation byte-for-byte (`ImportPrivateSeed`); cross-encapsulation in both directions; implicit-rejection outputs match |

---

## Sample Vectors

Complete vectors are thousands of hex characters; the samples below show the short values in full and truncate keys/ciphertexts (lengths noted). Full data: `tests/Security/Cryptography/TestData/mlkem-acvp-fips203.json.gz` or the ACVP repository.

### Key Generation (ML-KEM-512, ACVP keyGen tcId 1)

```
d  = 47B893474672BA92E4B12EE44FB32953AF8E8503B5FB471D1614FB8A021A660A
z  = 1F8CB39E9E30BC458A0DC5408884B1187FB217018DF760FA57317703B844A0A9
ek = 28266A088B3482439BCA01AFB7CA5C6136A979B5159985A9484B36B679A5F7B9... (800 bytes)
dk = 89C31D05611AAAB258F78BC2DE0A80D5914BF80C376A990D33CB97F4F2077CE1... (1632 bytes)
```

The implementation consumes the seed as the 64-byte concatenation d ‖ z.

### Encapsulation (ML-KEM-512, ACVP encapsulation tcId 1)

```
m = 19C44D35AB9EF31B1360F0BF33CF63D80E405962D698415C5888F0AF385DCFF4
c = A87953F9DC2996A8DD40BE55901417A933C3D36EC09ED8A6B81C684947086C23... (768 bytes)
k = 4B7B1514D1BC9808F80E3BEE7B528E13B753C99D153F7EA116A5887063BFCACF
```

### Implicit Rejection (ML-KEM-512, ACVP decapsulation tcId 77, "modified ciphertext")

```
k = 3DE98CA3A5795225FBB69C5C80277F9B5AC7D370A567A1FFD130D5C1FED0F588
```

The expected k for a modified ciphertext is the implicit-rejection output K̄ = J(z ‖ c); matching it byte-exactly proves the rejection path (not just "some different secret").

---

## Regenerating / Extending the Vectors

```bash
python scripts/fetch-mlkem-acvp-vectors.py
```

The script downloads `internalProjection.json` from the ACVP folders listed above (it contains both
prompts and expected results) and writes the gzipped result. Running it against unchanged upstream
vectors produces a byte-identical file, so a real diff means NIST published new vectors.

Pass `--limit N` to cap the cases per group — useful when iterating locally, but the committed file
is the complete set. Because the stored schema is NIST's own, `MLKemAcvpVectors` reads any field the
ACVP files carry; surfacing a new one is a change to the loader alone.

## Usage

These test vectors are used by the unit tests in `tests/Security/Cryptography/Kem/` to verify FIPS 203 conformance of the ML-KEM implementation against known good values from official sources.

## License

The test vectors are derived from the public NIST ACVP-Server repository. See the ACVP-Server license (NIST software is public domain) for terms.
