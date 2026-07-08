# ML-DSA Test Vectors

## Source

NIST ACVP (Automated Cryptographic Validation Protocol) validation vector sets for FIPS 204:

- **ML-DSA-keyGen-FIPS204** — https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/ML-DSA-keyGen-FIPS204
- **ML-DSA-sigGen-FIPS204** — https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/ML-DSA-sigGen-FIPS204
- **ML-DSA-sigVer-FIPS204** — https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/ML-DSA-sigVer-FIPS204

The curated vectors are embedded as hex constants in
`tests/Security/Cryptography/Dsa/MlDsa/MlDsaAcvpTests.cs`; each test case references the
`tcId` of the original ACVP vector file so it can be traced back to the NIST source.

---

## Coverage

For **each** of ML-DSA-44, ML-DSA-65, and ML-DSA-87 (external interface, pure ML-DSA — no pre-hash, no external μ):

| Operation | ACVP group | What is verified |
|-----------|-----------|------------------|
| Key generation (AFT) | keyGen | Seed ξ → byte-exact pk and sk |
| Deterministic signing (AFT) | sigGen, deterministic = true | (sk, message, context) → byte-exact signature |
| Hedged signing (AFT) | sigGen, deterministic = false | (sk, message, context, ACVP-provided rnd) → byte-exact signature, exercised through the internal interface |
| Verification (AFT) | sigVer | Valid signatures accepted; *modified signature — commitment*, *modified signature — z*, *modified signature — hint*, and *modified message* cases rejected |

The sigVer *modified hint* cases exercise the strict HintBitPack validation required for strong unforgeability.

## Cross-Validation (Interop)

`MlDsaInteropTests` cross-validates against independent implementations on every target framework:

| Peer | Tests |
|------|-------|
| **BouncyCastle 2.6+** | Same-seed key generation produces byte-identical pk and expanded sk (`MLDsaPrivateKeyParameters.FromSeed`); deterministic signatures match byte-for-byte (`MLDsaSigner(…, deterministic: true)`); hedged sign ↔ verify round-trips in both directions |
| **.NET 10 `System.Security.Cryptography.MLDsa`** (where OS-supported) | Same-seed keys match the CNG/OpenSSL implementation byte-for-byte (`ImportMLDsaPrivateSeed`); cross sign/verify in both directions including context binding |

---

## Sample Vectors

Complete vectors are thousands of hex characters; the samples below show short values in full and truncate keys/signatures (lengths noted). Full data: `MlDsaAcvpTests.cs` or the ACVP repository.

### Key Generation (ML-DSA-44, ACVP keyGen tcId 1)

```
seed = D71361C000F9A7BC99DFB425BCB6BB27C32C36AB444FF3708B2D93B4E66D5B5B
pk   = B845FA2881407A59183071629B08223128116014FB58FF6BB4C8C9FE19CF5B0B... (1312 bytes)
sk   = B845FA2881407A59183071629B08223128116014FB58FF6BB4C8C9FE19CF5B0B... (2560 bytes)
```

(pk and sk share the same 32-byte prefix because both encodings begin with ρ.)

### Deterministic Signing (ML-DSA-65, ACVP sigGen tcId 36)

```
message   = 8F (1 byte)
context   = E9E7AA56C7975DC9B4DDBA302B0045BB7A6DEA96E798C6911143 (26 bytes)
signature = FA681CF3153374D98C9F82ABC8691E5E8CE65CF2E8189732A5DE99B8B9159FCE... (3309 bytes)
```

The context string participates via the FIPS 204 message prefix 0x00 ‖ |ctx| ‖ ctx ‖ M, so these vectors also validate the external-interface domain separation.

---

## Regenerating / Extending the Vectors

1. Download `internalProjection.json` from the ACVP vector folders listed above (it contains both prompts and expected results, including the `rnd` values for hedged sigGen cases).
2. Filter to `signatureInterface: external`, `preHash: pure`, `externalMu: false` groups for the standard API surface.
3. Keep the ACVP `tcId` in the generated comment so vectors remain traceable.

## Usage

These test vectors are used by the unit tests in `tests/Security/Cryptography/Dsa/` to verify FIPS 204 conformance of the ML-DSA implementation against known good values from official sources.

## License

The test vectors are derived from the public NIST ACVP-Server repository. See the ACVP-Server license (NIST software is public domain) for terms.
