| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     216.3 ns |     1.40 ns |     1.31 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     287.6 ns |     3.03 ns |     2.83 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     297.4 ns |     3.61 ns |     3.38 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     339.7 ns |     1.65 ns |     1.46 ns |   8,832 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     418.9 ns |     3.27 ns |     2.90 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     558.7 ns |     4.71 ns |     4.41 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     577.1 ns |     6.37 ns |     5.65 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     644.3 ns |     5.48 ns |     4.85 ns |   9,335 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,632.3 ns |    15.92 ns |    14.89 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,196.6 ns |    26.39 ns |    24.69 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,239.7 ns |    24.06 ns |    21.33 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,530.0 ns |    14.99 ns |    13.29 ns |   9,302 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,631.0 ns |     7.92 ns |     7.02 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,200.7 ns |    30.17 ns |    26.75 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,246.9 ns |    21.68 ns |    20.28 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,533.7 ns |    16.77 ns |    15.69 ns |   9,306 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  12,361.5 ns |    89.84 ns |    75.02 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  16,597.5 ns |   170.03 ns |   159.05 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  17,012.7 ns |   190.55 ns |   178.24 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  19,049.2 ns |    92.86 ns |    86.87 ns |   9,317 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 195,478.3 ns |   982.78 ns |   871.21 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 262,341.6 ns | 2,553.85 ns | 2,263.92 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 268,708.4 ns | 3,692.59 ns | 3,083.48 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 301,701.4 ns | 2,635.66 ns | 2,465.40 ns |   9,319 B |         - |