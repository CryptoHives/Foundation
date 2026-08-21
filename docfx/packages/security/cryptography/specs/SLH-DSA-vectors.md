# SLH-DSA Test Vectors

## Source

NIST ACVP (Automated Cryptographic Validation Protocol) validation vector sets for FIPS 205:

- **SLH-DSA-keyGen-FIPS205** — https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/SLH-DSA-keyGen-FIPS205
- **SLH-DSA-sigGen-FIPS205** — https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/SLH-DSA-sigGen-FIPS205
- **SLH-DSA-sigVer-FIPS205** — https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/SLH-DSA-sigVer-FIPS205

The curated vectors are embedded as hex constants in
`tests/Security/Cryptography/Dsa/SlhDsa/SlhDsaAcvpTests.cs`; each test case references
the `tcId` of the original ACVP vector file so it can be traced back to the NIST source.

---

## Coverage

External interface, pure SLH-DSA (no pre-hash). Because the `s` (small) sets sign slowly by design, they are sampled sparsely to keep the default test runtime reasonable:

| Operation | Sets covered | What is verified |
|-----------|-------------|------------------|
| Key generation (AFT) | all 12 (2 vectors per f set, 1 per s set) | (SK.seed, SK.prf, PK.seed) → byte-exact pk and sk |
| Deterministic signing (AFT) | all 6 f sets + both 128s sets | (sk, message, context, opt_rand = PK.seed) → byte-exact signature |
| Hedged signing (AFT) | both 128f sets | (sk, message, context, ACVP `additionalRandomness`) → byte-exact signature |
| Verification (AFT) | 128f pairs (broad), SHAKE-192f, SHAKE-128s | Valid signatures accepted; *modified signature — R / SIGFORS / SIGHT*, *modified message*, and *wrong-length* cases rejected |

The keyGen vectors for all 12 sets exercise both hash instantiations end-to-end — including the SHA-2 compressed-ADRS addressing, MGF1-based H_msg, HMAC-based PRF_msg, and the SHA-256/SHA-512 split for categories 3 and 5 — because PK.root is the root of a full XMSS treehash.

## Cross-Validation (Interop)

`SlhDsaInteropTests` cross-validates against independent implementations on every target framework (fast sets):

| Peer | Tests |
|------|-------|
| **BouncyCastle 2.6+** | Hedged sign ↔ verify round-trips in both directions; a BouncyCastle-generated secret key imported into our `SlhDsa` produces signatures BouncyCastle verifies |
| **.NET 10 `System.Security.Cryptography.SlhDsa`** (where OS-supported) | Cross sign/verify in both directions including context binding |

---

## Sample Vector

### Key Generation (SLH-DSA-SHAKE-128f, ACVP keyGen tcId 31)

```
skSeed = 3956AB391B4D22FC907AF0740326D061
skPrf  = AB0EB206436F2B86EBE086D77739B3E4
pkSeed = 56505C229F4E7FA6B201714C7DCC9DA3
pk     = 56505C229F4E7FA6B201714C7DCC9DA366578F1F24C3FE371C97C14CE0E79CDC
sk     = 3956AB391B4D22FC907AF0740326D061AB0EB206436F2B86EBE086D77739B3E4
         56505C229F4E7FA6B201714C7DCC9DA366578F1F24C3FE371C97C14CE0E79CDC
```

The key layout is visible directly: pk = PK.seed ‖ PK.root and sk = SK.seed ‖ SK.prf ‖ PK.seed ‖ PK.root, where PK.root (66578F…) is the recomputed hypertree root. Signatures run to 7.8–49.9 KB; see the test file for complete sigGen/sigVer vectors.

---

## Regenerating / Extending the Vectors

1. Download `internalProjection.json` from the ACVP vector folders listed above (the sigGen file is ~38 MB; it includes the `additionalRandomness` values for hedged cases).
2. Filter to `signatureInterface: external`, `preHash: pure` groups for the standard API surface.
3. Keep the ACVP `tcId` in the generated comment so vectors remain traceable.

## Usage

These test vectors are used by the unit tests in `tests/Security/Cryptography/Dsa/SlhDsa/` to verify FIPS 205 conformance of the SLH-DSA implementation against known good values from official sources.

## License

The test vectors are derived from the public NIST ACVP-Server repository. See the ACVP-Server license (NIST software is public domain) for terms.
