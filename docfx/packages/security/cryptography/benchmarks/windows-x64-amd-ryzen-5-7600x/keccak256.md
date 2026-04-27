| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     207.3 ns |     1.00 ns |     0.88 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     278.6 ns |     0.95 ns |     0.89 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     287.7 ns |     1.10 ns |     0.97 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     330.7 ns |     1.15 ns |     0.96 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     404.1 ns |     1.75 ns |     1.64 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     547.3 ns |     1.67 ns |     1.39 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     568.8 ns |     1.17 ns |     1.10 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     628.7 ns |     2.51 ns |     2.35 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,588.9 ns |     8.10 ns |     7.58 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,158.9 ns |     3.37 ns |     2.82 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,220.1 ns |     5.94 ns |     5.27 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,466.2 ns |    16.58 ns |    15.51 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,590.1 ns |     7.34 ns |     6.50 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,159.4 ns |     6.35 ns |     5.94 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,217.5 ns |     7.56 ns |     6.31 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,463.8 ns |    13.38 ns |    11.18 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  12,088.7 ns |    80.06 ns |    74.89 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  16,392.5 ns |    42.23 ns |    39.50 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  16,825.6 ns |    41.71 ns |    39.02 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  18,612.4 ns |    91.00 ns |    85.12 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 190,579.1 ns | 1,239.67 ns | 1,035.18 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 259,048.9 ns |   601.92 ns |   563.03 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 265,689.8 ns |   771.76 ns |   721.90 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 293,571.9 ns | 1,607.29 ns | 1,424.82 ns |         - |