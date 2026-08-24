| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     216.6 ns |     0.31 ns |     0.26 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     284.8 ns |     0.88 ns |     0.78 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     295.9 ns |     0.99 ns |     0.93 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     331.6 ns |     0.77 ns |     0.69 ns |   8,045 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     368.4 ns |     0.60 ns |     0.50 ns |   3,253 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     419.7 ns |     0.71 ns |     0.59 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     556.9 ns |     1.44 ns |     1.28 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     572.9 ns |     1.03 ns |     0.80 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     609.4 ns |     3.60 ns |     3.37 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     633.7 ns |     1.31 ns |     1.16 ns |   9,280 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,639.9 ns |     3.97 ns |     3.32 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,074.3 ns |     8.78 ns |     7.33 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,175.6 ns |     6.13 ns |     5.44 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,234.9 ns |     6.80 ns |     6.36 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,522.1 ns |     3.49 ns |     3.27 ns |   9,350 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,636.7 ns |     1.70 ns |     1.42 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,069.0 ns |     5.07 ns |     4.74 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,177.2 ns |    11.55 ns |    10.24 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,233.7 ns |     8.05 ns |     7.14 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,525.2 ns |    11.45 ns |     8.94 ns |   9,350 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  12,515.5 ns |    21.60 ns |    18.03 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  14,872.5 ns |    18.81 ns |    16.68 ns |   3,265 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  16,543.0 ns |    96.17 ns |    80.31 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  16,938.6 ns |    57.43 ns |    50.91 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  19,023.4 ns |    50.01 ns |    44.33 ns |   9,307 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 195,765.2 ns |   437.85 ns |   365.63 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 233,116.9 ns |   340.37 ns |   284.23 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 260,439.2 ns |   519.92 ns |   486.34 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 267,689.9 ns | 2,317.77 ns | 1,809.56 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 301,020.1 ns |   687.94 ns |   609.84 ns |   9,308 B |         - |