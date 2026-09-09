# ML-DSA Test Vectors

## Source

NIST ACVP (Automated Cryptographic Validation Protocol) validation vector sets for FIPS 204:

- [**ML-DSA-keyGen-FIPS204**](https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/ML-DSA-keyGen-FIPS204)
- [**ML-DSA-sigGen-FIPS204**](https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/ML-DSA-sigGen-FIPS204)
- [**ML-DSA-sigVer-FIPS204**](https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/ML-DSA-sigVer-FIPS204)

The vectors are stored in **NIST's own ACVP JSON schema** in
`tests/Security/Cryptography/TestData/mldsa-acvp-fips204.json.gz`, and read at run time by
`MLDsaAcvpVectors` with `System.Text.Json`. The file holds the upstream keyGen, sigGen and sigVer
documents with their `testGroups` and `tests` arrays exactly as published, behind a small envelope
recording provenance. Every NUnit case is named after its parameter set and the `tcId` of the
original ACVP vector file, so a failure traces straight back to the NIST source.

It is a data file rather than C# literals because ACVP messages run to several kilobytes each and
an ML-DSA-87 signature is 4.6 KB per case — inline they added up to 448 KB of test source that
dwarfed the tests themselves. It is gzipped because the JSON is ~4.4 MB, compressing to ~2.5 MB.
Regenerate it with `scripts/fetch-mldsa-acvp-vectors.py`, which zeroes the gzip mtime so
regenerating unchanged vectors produces a byte-identical file rather than a spurious diff.

Only the **external-interface, pure ML-DSA** groups are kept — the ones the library implements.
The ACVP files also carry pre-hash (HashML-DSA), internal-interface and external-μ groups;
skipping them takes sigGen from 360 cases to 90 and sigVer from 180 to 45. Every case that can
actually be run is included, so there is no curated subset to revisit — and because the stored
schema is the upstream one, enabling a skipped group later is a one-line change to the script's
filter rather than a change to the file format.

---

## Coverage

For **each** of ML-DSA-44, ML-DSA-65, and ML-DSA-87 (external interface, pure ML-DSA — no pre-hash, no external μ):

| Operation | ACVP group | Cases | What is verified |
|-----------|-----------|-------|------------------|
| Key generation (AFT) | keyGen | 25 | Seed ξ → byte-exact pk and sk |
| Deterministic signing (AFT) | sigGen, deterministic = true | 15 | (sk, message, context) → byte-exact signature |
| Hedged signing (AFT) | sigGen, deterministic = false | 15 | (sk, message, context, ACVP-provided rnd) → byte-exact signature, exercised through the internal interface |
| Verification (AFT) | sigVer | 15 | Valid signatures accepted; *modified signature — commitment*, *modified signature — z*, *modified signature — hint*, and *modified message* cases rejected |

The sigVer *modified hint* cases exercise the strict HintBitPack validation required for strong unforgeability.

### Both API levels

Each operation is exercised twice where the API allows it: once through the stateless `IDsa`
interface and once through the key-holding `MLDsa` API that mirrors
`System.Security.Cryptography.MLDsa`. 420 test cases in total.

One asymmetry is deliberate. Reproducing a sigGen vector byte for byte needs either
deterministic signing (rnd = 0³²) or an injected `rnd`, and `MLDsa` signs hedged-only —
matching the in-box type, which exposes no deterministic mode either. Byte-exact sigGen
therefore lives on the `IDsa` path; what the `MLDsa` pass adds is that the key-holding API
agrees with NIST about which signatures are *valid*, over a key imported from an expanded
private key.

## Cross-Validation (Interop)

`MLDsaInteropTests` cross-validates against independent implementations on every target framework:

| Peer | Tests |
|------|-------|
| **BouncyCastle 2.6+** | Same-seed key generation produces byte-identical pk and expanded sk (`MLDsaPrivateKeyParameters.FromSeed`); deterministic signatures match byte-for-byte (`MLDsaSigner(…, deterministic: true)`); hedged sign ↔ verify round-trips in both directions |
| **.NET 10 `System.Security.Cryptography.MLDsa`** (where OS-supported) | Same-seed keys match the CNG/OpenSSL implementation byte-for-byte (`ImportMLDsaPrivateSeed`); cross sign/verify in both directions including context binding |

---

## Sample Vectors

Complete vectors are thousands of hex characters; the samples below show short values in full and truncate keys/signatures (lengths noted). Full data: `tests/Security/Cryptography/TestData/mldsa-acvp-fips204.json.gz` or the ACVP repository.

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

```bash
python scripts/fetch-mldsa-acvp-vectors.py
```

The script downloads `internalProjection.json` from the ACVP folders listed above (it contains both
prompts and expected results, including the `rnd` values for hedged sigGen cases), keeps the groups
matching `signatureInterface: external`, `preHash: pure`, `externalMu: false`, and writes the
gzipped result. Running it against unchanged upstream vectors produces a byte-identical file, so a
real diff means NIST published new vectors.

Pass `--limit N` to cap the cases per kept group — useful when iterating locally, but the committed
file is the complete runnable set. To take on external-μ later, widen `is_pure_external()` in the
script and teach `MLDsaAcvpVectors` the extra fields: because the stored schema is NIST's own,
neither is a file-format change.

---

## HashML-DSA (Pre-Hash) Vectors

The pre-hash groups (FIPS 204 §5.4) live in their own file,
`tests/Security/Cryptography/TestData/mldsa-prehash-acvp-fips204.json.gz`, loaded by
`MLDsaPreHashAcvpVectors` and exercised by `MLDsaPreHashAcvpTests`. They are kept separate from the
pure set rather than merged into it: the selection rule differs, and merging would rewrite an
already-committed 2.5 MB blob every time either set is regenerated.

```bash
python scripts/fetch-mldsa-acvp-vectors.py --profile prehash
```

The runnable pre-hash set is 135 cases and 2.11 MB gzipped — affordable, but the committed file is
a **57-case stratified selection (~0.88 MB)** chosen by rule rather than by cap:

| Mode | Kept | Rule |
|------|-----:|------|
| sigGen | 36 | Every (parameter set × pre-hash function) pair exactly once — 3 × 12. Even-indexed pre-hash functions are taken from the deterministic group and odd-indexed from the hedged one, so both signing modes are exercised for every set. |
| sigVer | 21 | One valid case per (set × pre-hash function), plus every failure reason: modified message, commitment, hint and z. |

All twelve approved pre-hash functions and all three parameter sets appear. The digest PH(M) is
**recomputed from the vector's message** by the tests rather than read from the file, so they also
cross-check the OID-to-hash binding end to end — a wrong OID table entry or a wrong SHAKE output
length fails there rather than silently signing the wrong prefix.

### Running the complete set

```bash
python scripts/fetch-mldsa-acvp-vectors.py --profile prehash-full
dotnet test tests/Security/Cryptography/Cryptography.Tests.csproj   --framework net10.0 --filter "FullyQualifiedName~MLDsaPreHashAcvpTests"
```

The script writes a gitignored `mldsa-prehash-acvp-fips204.full.json.gz`, which the loader prefers
automatically — it resolves `CRYPTOHIVES_MLDSA_PREHASH_ACVP_VECTORS` first, then that default path,
then the embedded resource, and logs which it used. `VectorFile_CoversAtLeastTheCommittedSelection`
fails if an override ever carries *fewer* cases, so a truncated download cannot quietly shrink the
suite. The weekly `acvp-full-vectors` workflow runs all 135 and checks the committed file still
regenerates byte-identically.

## Usage

These test vectors are used by the unit tests in `tests/Security/Cryptography/Dsa/` to verify FIPS 204 conformance of the ML-DSA implementation against known good values from official sources.

## License

The test vectors are derived from the public NIST ACVP-Server repository. See the ACVP-Server license (NIST software is public domain) for terms.
