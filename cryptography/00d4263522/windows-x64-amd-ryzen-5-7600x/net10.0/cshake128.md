| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     224.5 ns |   0.66 ns |   0.62 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     288.3 ns |   1.43 ns |   1.33 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     319.3 ns |   1.67 ns |   1.48 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     335.9 ns |   0.42 ns |   0.35 ns |   9,120 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     223.4 ns |   0.75 ns |   0.62 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     287.6 ns |   1.62 ns |   1.44 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     299.4 ns |   1.99 ns |   1.66 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     339.8 ns |   0.68 ns |   0.57 ns |   9,120 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,471.6 ns |   4.98 ns |   4.41 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   1,927.8 ns |  10.84 ns |  10.14 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   1,967.5 ns |   5.53 ns |   4.90 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,233.6 ns |   3.06 ns |   2.39 ns |   9,698 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,470.7 ns |   5.28 ns |   4.68 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   1,927.1 ns |   5.79 ns |   5.41 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   1,973.6 ns |  10.77 ns |   9.00 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,238.6 ns |   5.02 ns |   3.92 ns |   9,683 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  10,228.7 ns |  50.02 ns |  46.79 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  13,414.1 ns |  47.73 ns |  44.64 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  13,684.3 ns |  70.76 ns |  59.09 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  15,562.9 ns |  19.37 ns |  16.17 ns |   9,743 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 162,001.1 ns | 217.38 ns | 203.34 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 213,488.7 ns | 852.04 ns | 755.31 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 217,236.6 ns | 884.13 ns | 827.01 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 244,689.0 ns | 406.20 ns | 360.08 ns |   9,691 B |         - |