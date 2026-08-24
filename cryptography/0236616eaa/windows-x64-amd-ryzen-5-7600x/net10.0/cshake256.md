| Description                                      | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     216.7 ns |     0.27 ns |   0.23 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     284.9 ns |     1.14 ns |   1.07 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     295.5 ns |     1.19 ns |   1.00 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     333.6 ns |     1.01 ns |   0.90 ns |   9,090 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     420.6 ns |     1.26 ns |   1.12 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     558.7 ns |     3.24 ns |   2.70 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     572.8 ns |     2.07 ns |   1.94 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     635.6 ns |     1.10 ns |   0.92 ns |   9,740 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,638.3 ns |     3.81 ns |   3.38 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,178.9 ns |     7.11 ns |   6.66 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,232.2 ns |     8.69 ns |   7.25 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,512.5 ns |     5.82 ns |   4.86 ns |   9,768 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,640.3 ns |     2.96 ns |   2.63 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,180.8 ns |     7.87 ns |   6.98 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,240.8 ns |     9.77 ns |   8.16 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,514.7 ns |     2.34 ns |   1.82 ns |   9,744 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  12,420.5 ns |    30.37 ns |  26.92 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  16,513.8 ns |    47.59 ns |  39.74 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  16,913.4 ns |    81.80 ns |  63.86 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  18,983.6 ns |    22.28 ns |  20.84 ns |   9,712 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 196,326.9 ns |   696.70 ns | 617.61 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 260,490.6 ns | 1,068.42 ns | 947.13 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 266,619.4 ns |   777.15 ns | 688.92 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 307,521.5 ns |   428.28 ns | 400.61 ns |   9,713 B |         - |