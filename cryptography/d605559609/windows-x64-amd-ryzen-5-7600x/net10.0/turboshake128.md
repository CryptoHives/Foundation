| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     131.1 ns |   0.79 ns |   0.74 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     156.9 ns |   0.97 ns |   0.81 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     165.3 ns |   0.54 ns |   0.42 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     125.4 ns |   1.07 ns |   0.89 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     157.4 ns |   0.55 ns |   0.46 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     165.0 ns |   0.35 ns |   0.31 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     795.3 ns |   2.71 ns |   2.26 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,010.5 ns |   8.01 ns |   7.10 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,044.6 ns |   4.74 ns |   5.26 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     793.1 ns |   3.73 ns |   3.12 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,007.5 ns |   3.52 ns |   3.12 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,054.7 ns |  20.15 ns |  26.20 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   5,451.4 ns |   8.04 ns |   7.13 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,177.5 ns |  21.39 ns |  17.86 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   7,203.0 ns | 139.69 ns | 143.46 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  86,741.1 ns | 351.73 ns | 311.80 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 110,980.1 ns | 716.97 ns | 559.76 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 114,193.8 ns | 533.80 ns | 473.20 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     125.2 ns |   0.31 ns |   0.27 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     158.3 ns |   0.45 ns |   0.42 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     165.9 ns |   0.71 ns |   0.59 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     125.9 ns |   0.35 ns |   0.31 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     157.6 ns |   0.67 ns |   0.63 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     166.2 ns |   1.83 ns |   1.43 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     812.3 ns |   1.51 ns |   1.34 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,018.4 ns |  18.65 ns |  22.20 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,047.6 ns |  10.97 ns |   9.72 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     791.5 ns |   2.73 ns |   2.55 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,023.6 ns |  20.37 ns |  28.56 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,043.4 ns |   4.06 ns |   3.80 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   5,458.7 ns |  23.16 ns |  21.66 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   6,962.5 ns |  14.48 ns |  12.84 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,175.8 ns |  21.15 ns |  19.79 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  87,097.5 ns | 240.38 ns | 224.85 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 111,037.1 ns | 351.62 ns | 328.91 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 114,711.3 ns | 651.91 ns | 508.97 ns |         - |