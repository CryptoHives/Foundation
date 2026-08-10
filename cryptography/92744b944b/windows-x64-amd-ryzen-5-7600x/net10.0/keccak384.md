| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     438.8 ns |     0.81 ns |     0.68 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     583.3 ns |     2.73 ns |     2.42 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     602.2 ns |     1.42 ns |     1.18 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     625.0 ns |     1.14 ns |     1.07 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     434.1 ns |     1.27 ns |     1.19 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     578.6 ns |     2.36 ns |     1.97 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     604.0 ns |     9.00 ns |     8.42 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     626.8 ns |     2.13 ns |     1.99 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   1,977.8 ns |    11.26 ns |    10.53 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   2,691.4 ns |     5.28 ns |     4.68 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   2,760.4 ns |     7.42 ns |     5.79 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,044.7 ns |    11.79 ns |    11.03 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   1,980.8 ns |     7.23 ns |     6.77 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,690.8 ns |     6.72 ns |     5.96 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   2,763.6 ns |     6.21 ns |     5.51 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,045.7 ns |     9.51 ns |     8.89 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  15,434.8 ns |    54.08 ns |    50.59 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  21,043.6 ns |    68.89 ns |    61.07 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  21,643.9 ns |    75.08 ns |    70.23 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  23,896.4 ns |    37.14 ns |    34.74 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 246,538.3 ns | 1,240.47 ns | 1,099.64 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 336,208.6 ns |   571.74 ns |   477.43 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 344,599.3 ns |   534.16 ns |   446.05 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 381,226.2 ns |   781.21 ns |   730.74 ns |         - |