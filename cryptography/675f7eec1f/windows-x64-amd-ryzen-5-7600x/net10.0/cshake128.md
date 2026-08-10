| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     220.6 ns |     0.84 ns |     0.78 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     289.9 ns |     2.96 ns |     2.76 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     299.6 ns |     3.13 ns |     2.92 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     343.8 ns |     3.10 ns |     2.59 ns |   8,862 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     219.5 ns |     1.44 ns |     1.35 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     289.3 ns |     2.82 ns |     2.64 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     299.5 ns |     2.89 ns |     2.71 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     342.5 ns |     2.11 ns |     1.97 ns |   8,862 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,447.3 ns |     9.68 ns |     8.58 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   1,945.7 ns |    33.58 ns |    29.76 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   1,974.3 ns |    23.33 ns |    21.82 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,228.2 ns |    10.33 ns |     9.66 ns |   9,317 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,443.5 ns |     7.52 ns |     6.66 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   1,931.9 ns |    26.48 ns |    23.48 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   1,987.0 ns |    35.83 ns |    33.52 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,233.5 ns |    18.58 ns |    16.47 ns |   9,319 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  10,043.0 ns |    48.80 ns |    45.65 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  13,436.3 ns |   103.25 ns |    96.58 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  13,665.4 ns |    89.11 ns |    78.99 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  15,429.5 ns |    76.44 ns |    67.76 ns |   9,339 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 159,679.7 ns | 1,325.20 ns | 1,106.61 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 213,701.0 ns | 1,521.73 ns | 1,423.43 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 218,292.9 ns | 1,662.68 ns | 1,473.92 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 246,068.0 ns |   839.16 ns |   743.89 ns |   9,332 B |         - |