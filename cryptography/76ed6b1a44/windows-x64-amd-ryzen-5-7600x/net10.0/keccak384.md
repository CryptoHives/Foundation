| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     400.7 ns |     2.29 ns |     2.03 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     547.7 ns |     1.14 ns |     0.96 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     565.8 ns |     1.13 ns |     0.88 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     627.7 ns |     3.96 ns |     3.71 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     400.0 ns |     1.08 ns |     0.84 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     549.2 ns |     1.54 ns |     1.36 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     563.6 ns |     2.29 ns |     2.14 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     625.6 ns |     2.29 ns |     2.03 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   1,966.6 ns |    10.57 ns |     9.88 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   2,695.1 ns |     5.58 ns |     5.22 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   2,760.5 ns |     7.78 ns |     6.90 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,045.1 ns |    14.42 ns |    13.49 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   1,969.1 ns |    11.76 ns |     9.82 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,694.6 ns |     5.51 ns |     4.89 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   2,764.8 ns |     7.08 ns |     6.28 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,049.8 ns |    14.23 ns |    12.61 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  15,463.0 ns |    62.33 ns |    52.05 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  21,126.8 ns |    66.80 ns |    62.48 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  21,779.2 ns |    49.21 ns |    46.03 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  24,081.4 ns |   366.22 ns |   342.56 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 247,297.5 ns | 1,927.22 ns | 1,802.72 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 337,419.3 ns |   845.70 ns |   791.07 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 347,540.7 ns |   784.89 ns |   655.42 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 389,063.2 ns | 1,985.22 ns | 1,856.98 ns |         - |