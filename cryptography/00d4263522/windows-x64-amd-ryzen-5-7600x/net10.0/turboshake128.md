| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     126.6 ns |   0.67 ns |   0.59 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     166.1 ns |   1.94 ns |   1.62 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     167.5 ns |   0.74 ns |   0.69 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     128.9 ns |   1.37 ns |   1.28 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     160.6 ns |   2.14 ns |   2.00 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     167.6 ns |   2.85 ns |   2.38 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     811.2 ns |   4.98 ns |   4.42 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,026.8 ns |  18.32 ns |  16.24 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,069.5 ns |  20.95 ns |  18.57 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     808.6 ns |   4.08 ns |   3.82 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,022.4 ns |   9.72 ns |   9.09 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,051.9 ns |   8.18 ns |   7.25 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   5,595.0 ns |  37.50 ns |  35.08 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   7,081.3 ns |  76.10 ns |  67.46 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,254.0 ns |  38.39 ns |  35.91 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  89,032.7 ns | 456.90 ns | 427.38 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 112,134.2 ns | 621.52 ns | 581.37 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 115,253.1 ns | 773.38 ns | 723.42 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     128.9 ns |   0.55 ns |   0.49 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     160.0 ns |   1.07 ns |   1.00 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     165.9 ns |   1.20 ns |   1.01 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     129.4 ns |   0.73 ns |   0.65 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     159.7 ns |   1.19 ns |   0.99 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     167.2 ns |   0.91 ns |   0.80 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     812.5 ns |   4.52 ns |   4.23 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,024.4 ns |   7.81 ns |   7.31 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,054.8 ns |   9.46 ns |   7.90 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     801.0 ns |   2.16 ns |   1.80 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,012.6 ns |   3.33 ns |   3.12 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,060.6 ns |   3.50 ns |   3.27 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   5,524.2 ns |  16.49 ns |  14.62 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   6,981.5 ns |  27.45 ns |  24.33 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,181.9 ns |  21.20 ns |  19.83 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  87,687.7 ns | 216.76 ns | 169.23 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 111,194.0 ns | 300.71 ns | 266.57 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 114,221.3 ns | 380.57 ns | 355.98 ns |         - |