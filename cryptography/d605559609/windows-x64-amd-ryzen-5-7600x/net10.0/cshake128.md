| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     223.0 ns |     1.88 ns |     1.57 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     289.9 ns |     1.13 ns |     1.00 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     299.0 ns |     0.80 ns |     0.71 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     336.9 ns |     1.17 ns |     1.04 ns |   9,111 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     221.2 ns |     0.60 ns |     0.50 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     288.4 ns |     0.73 ns |     0.61 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     299.2 ns |     0.93 ns |     0.87 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     335.8 ns |     1.21 ns |     1.01 ns |   9,111 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,466.7 ns |     6.81 ns |     5.32 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   1,928.5 ns |     5.63 ns |     5.26 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   1,975.2 ns |     9.73 ns |     7.60 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,216.2 ns |     6.96 ns |     6.17 ns |   9,689 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,471.8 ns |    19.81 ns |    15.47 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   1,928.1 ns |     9.60 ns |     8.98 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   1,973.2 ns |     5.78 ns |     4.51 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,216.8 ns |     6.26 ns |     5.23 ns |   9,691 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  10,194.7 ns |    44.01 ns |    41.17 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  13,399.0 ns |    31.43 ns |    26.25 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  13,726.5 ns |   131.61 ns |   102.75 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  15,411.4 ns |    35.43 ns |    33.14 ns |   9,695 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 162,400.1 ns |   673.89 ns |   562.73 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 213,622.6 ns |   849.74 ns |   794.85 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 220,030.1 ns | 3,426.90 ns | 4,079.48 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 245,906.6 ns |   730.40 ns |   570.25 ns |   9,683 B |         - |