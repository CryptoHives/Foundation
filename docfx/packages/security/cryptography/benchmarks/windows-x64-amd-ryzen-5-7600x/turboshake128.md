| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     119.1 ns |   0.72 ns |   0.63 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     154.8 ns |   0.44 ns |   0.39 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     163.1 ns |   0.45 ns |   0.37 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     119.4 ns |   0.89 ns |   0.83 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     154.4 ns |   0.69 ns |   0.61 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     163.2 ns |   0.46 ns |   0.41 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     762.8 ns |   5.62 ns |   4.98 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,000.7 ns |   4.06 ns |   3.60 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,038.3 ns |   3.47 ns |   2.90 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     763.5 ns |   3.03 ns |   2.83 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,002.0 ns |   5.25 ns |   4.38 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,033.4 ns |   2.88 ns |   2.55 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   5,289.0 ns |  29.19 ns |  27.30 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   6,923.6 ns |   8.63 ns |   7.65 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,105.6 ns |  15.76 ns |  13.97 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  84,106.8 ns | 750.98 ns | 627.10 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 110,095.9 ns | 203.00 ns | 189.88 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 112,980.3 ns | 293.98 ns | 274.99 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     119.9 ns |   0.84 ns |   0.70 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     155.3 ns |   0.27 ns |   0.25 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     164.3 ns |   0.47 ns |   0.44 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     120.6 ns |   0.93 ns |   0.87 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     155.9 ns |   0.65 ns |   0.54 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     162.8 ns |   0.51 ns |   0.43 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     764.3 ns |   3.38 ns |   3.16 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,016.8 ns |   2.50 ns |   2.34 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,034.5 ns |   2.38 ns |   2.23 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     768.2 ns |   8.98 ns |   7.50 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,000.6 ns |   1.28 ns |   1.07 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,034.6 ns |   2.25 ns |   2.11 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   5,291.0 ns |  27.63 ns |  24.50 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   6,940.7 ns |  18.42 ns |  15.38 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,114.8 ns |  12.38 ns |  11.58 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  84,065.2 ns | 286.24 ns | 267.75 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 110,253.2 ns | 224.19 ns | 198.74 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 113,255.5 ns | 167.26 ns | 148.27 ns |         - |