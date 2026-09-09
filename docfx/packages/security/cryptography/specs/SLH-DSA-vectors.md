# SLH-DSA Test Vectors

## Source

NIST ACVP (Automated Cryptographic Validation Protocol) validation vector sets for FIPS 205:

- [**SLH-DSA-keyGen-FIPS205**](https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/SLH-DSA-keyGen-FIPS205)
- [**SLH-DSA-sigGen-FIPS205**](https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/SLH-DSA-sigGen-FIPS205)
- [**SLH-DSA-sigVer-FIPS205**](https://github.com/usnistgov/ACVP-Server/tree/master/gen-val/json-files/SLH-DSA-sigVer-FIPS205)

The vectors are stored in **NIST's own ACVP JSON schema** in
`tests/Security/Cryptography/TestData/slhdsa-acvp-fips205.json.gz`, and read at run time by
`SlhDsaAcvpVectors` with `System.Text.Json` — the same arrangement as
[ML-DSA](ML-DSA-vectors.md) and [ML-KEM](ML-KEM-vectors.md). The file holds the upstream keyGen,
sigGen and sigVer documents with their `testGroups` and `tests` arrays exactly as published,
behind a small envelope recording provenance. Every NUnit case is named after its parameter set
and the `tcId` of the original ACVP vector file, so a failure traces straight back to the NIST
source. Regenerate it with `scripts/fetch-slhdsa-acvp-vectors.py`, which zeroes the gzip mtime so
regenerating unchanged vectors produces a byte-identical file rather than a spurious diff.

Only the **external-interface, pure SLH-DSA** groups are kept — the ones the library implements.
The ACVP files also carry pre-hash (HashSLH-DSA) and internal-interface groups; skipping them
takes 1,248 cases down to 456.

### Why this one is stratified, and how to run everything

For ML-KEM and ML-DSA the interface filter is the whole story: everything runnable is committed.
SLH-DSA cannot work that way. Its signatures are **7,856 to 49,856 bytes each**, so those 456
cases are 20.6 MB of JSON, gzipping to **11.8 MB** — a permanent binary blob several times the
size of the entire rest of the test data.

What ships instead is a **stratified 180-case selection (~2.15 MB)**, chosen by rule rather than
by cap:

| Mode | Kept | Rationale |
|------|------|-----------|
| keyGen | **all 120 cases**, all 12 sets | Keys are seeds, not signatures — the whole document is 0.02 MB gzipped |
| sigGen | **1 case per group** = 24 | 12 sets × {deterministic, hedged}: every set byte-exact in both variants |
| sigVer | **36 cases** | One valid case for every set, plus all 7 failure reasons on four representative sets |

The four sets carrying the full failure matrix are `SLH-DSA-SHA2-128f`, `SLH-DSA-SHAKE-128f`,
`SLH-DSA-SHA2-192s` and `SLH-DSA-SHAKE-256f` — between them they span both hash instantiations,
both speed variants, all three security categories, and the SHA-512 split that `SlhDsaHash`
applies for categories 3 and 5.

**Nothing is unreachable.** Run the script with the full profile and the loader picks the result
up automatically:

```bash
python scripts/fetch-slhdsa-acvp-vectors.py --profile full
dotnet test tests/Security/Cryptography/Cryptography.Tests.csproj --filter "FullyQualifiedName~SlhDsaAcvp"
```

`SlhDsaAcvpVectors` resolves its source in order: the `CRYPTOHIVES_SLHDSA_ACVP_VECTORS`
environment variable, then `slhdsa-acvp-fips205.full.json.gz` at its default path in the
repository (gitignored), then the embedded stratified resource. It writes which one it used to
the run log, and `VectorFile_CoversAtLeastTheStratifiedSelection` fails if an override ever
carries *fewer* cases than the committed file — a truncated download must not quietly shrink the
suite. The `.github/workflows/acvp-full-vectors.yml` job does all of this weekly.

---

## Coverage

External interface, pure SLH-DSA (no pre-hash), for all 12 parameter sets:

| Operation | Cases (stratified / full) | What is verified |
|-----------|--------------------------|------------------|
| Key generation (AFT) | 120 / 120 | (SK.seed, SK.prf, PK.seed) → byte-exact pk and sk |
| Deterministic signing (AFT) | 12 / 84 | (sk, message, context, opt_rand = PK.seed) → byte-exact signature |
| Hedged signing (AFT) | 12 / 84 | (sk, message, context, ACVP `additionalRandomness`) → byte-exact signature |
| Verification (AFT) | 36 / 168 | Valid signatures accepted; *modified signature — R / SIGFORS / SIGHT*, *modified message*, and *signature too large / too small* cases rejected |

Each operation runs through **both** paths, as ML-DSA does: the internal `SlhDsaCore` for
byte-exactness, and the key-holding `SlhDsa` API that mirrors the in-box type. Cases for the `s`
parameter sets are categorized `Slow`, so `--filter "TestCategory!=Slow"` gives a fast pass; they
run by default.

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

The key layout is visible directly: pk = PK.seed ‖ PK.root and sk = SK.seed ‖ SK.prf ‖ PK.seed ‖ PK.root, where PK.root (66578F…) is the recomputed hypertree root. Signatures run to 7.8–49.9 KB; see the data file for complete sigGen/sigVer vectors.

---

## Regenerating the Vectors

```bash
python scripts/fetch-slhdsa-acvp-vectors.py                 # stratified, overwrites the committed file
python scripts/fetch-slhdsa-acvp-vectors.py --profile full  # complete set, gitignored
python scripts/fetch-slhdsa-acvp-vectors.py --limit 2       # ad-hoc: additionally cap cases per group
```

The script downloads the three `internalProjection.json` files listed above (~69 MB in total; the
sigGen file alone is 38 MB and carries the `additionalRandomness` values for the hedged cases),
applies the `signatureInterface: external` / `preHash: pure` filter, applies the profile's
selection rule, and writes deterministic gzip. Because the stored schema is the upstream one,
enabling a currently skipped group later is a change to the script's filter rather than to the
file format.

## Usage

These test vectors are used by the unit tests in `tests/Security/Cryptography/Dsa/SlhDsa/` to verify FIPS 205 conformance of the SLH-DSA implementation against known good values from official sources.

## License

The test vectors are derived from the public NIST ACVP-Server repository. See the ACVP-Server license (NIST software is public domain) for terms.
