| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     124.2 ns |   0.28 ns |   0.25 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     156.1 ns |   0.42 ns |   0.40 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     164.5 ns |   0.47 ns |   0.37 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     124.0 ns |   0.37 ns |   0.29 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     156.7 ns |   0.62 ns |   0.55 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     165.4 ns |   0.72 ns |   0.67 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     788.2 ns |   2.12 ns |   1.88 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,009.0 ns |   3.70 ns |   3.46 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,040.5 ns |   3.61 ns |   3.20 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     786.4 ns |   1.37 ns |   1.14 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,007.7 ns |   3.23 ns |   3.03 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,041.6 ns |   3.87 ns |   3.23 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   5,430.7 ns |   9.60 ns |   8.02 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   6,941.6 ns |  15.71 ns |  14.69 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,175.2 ns |  25.40 ns |  19.83 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  86,447.1 ns | 187.13 ns | 165.89 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 110,606.7 ns | 283.12 ns | 236.42 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 113,725.4 ns | 183.89 ns | 153.56 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     126.1 ns |   0.22 ns |   0.18 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     156.9 ns |   0.59 ns |   0.55 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     165.4 ns |   0.58 ns |   0.48 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     124.7 ns |   0.13 ns |   0.11 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     157.2 ns |   0.47 ns |   0.41 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     165.9 ns |   1.75 ns |   1.55 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     786.0 ns |   0.88 ns |   0.74 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,003.1 ns |   4.15 ns |   3.46 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,039.1 ns |   5.32 ns |   4.98 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     787.5 ns |   1.52 ns |   1.35 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,006.5 ns |   5.05 ns |   4.48 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,061.8 ns |   5.22 ns |   4.88 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   5,523.5 ns |   8.14 ns |   6.35 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   6,934.4 ns |  30.18 ns |  26.75 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,170.0 ns |  19.44 ns |  16.24 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  86,365.9 ns | 279.35 ns | 247.64 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 110,480.4 ns | 244.80 ns | 191.13 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 113,939.9 ns | 240.28 ns | 213.01 ns |         - |