| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     220.5 ns |     0.44 ns |     0.37 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     287.0 ns |     1.04 ns |     0.93 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     295.6 ns |     1.22 ns |     1.14 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     335.6 ns |     0.57 ns |     0.47 ns |   9,099 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     426.7 ns |     1.40 ns |     1.17 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     559.0 ns |     1.68 ns |     1.57 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     575.6 ns |     2.19 ns |     2.05 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     642.3 ns |     0.88 ns |     0.68 ns |   9,685 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,659.0 ns |     4.22 ns |     3.74 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,221.4 ns |    10.21 ns |     9.05 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,235.8 ns |     5.90 ns |     5.52 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,564.8 ns |     8.44 ns |     7.90 ns |   9,764 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,657.1 ns |     3.49 ns |     3.26 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,187.4 ns |     5.94 ns |     5.27 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,237.7 ns |     5.86 ns |     5.19 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,553.4 ns |     3.91 ns |     3.46 ns |   9,764 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  12,549.5 ns |    36.84 ns |    34.46 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  16,603.2 ns |    71.09 ns |    66.49 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  16,950.2 ns |    55.04 ns |    51.48 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  19,233.3 ns |    28.47 ns |    25.23 ns |   9,712 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 197,901.0 ns |   563.22 ns |   499.28 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 261,985.1 ns | 1,494.70 ns | 1,325.01 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 267,233.5 ns | 1,094.03 ns |   913.57 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 305,452.6 ns | 1,222.61 ns | 1,083.81 ns |   9,755 B |         - |