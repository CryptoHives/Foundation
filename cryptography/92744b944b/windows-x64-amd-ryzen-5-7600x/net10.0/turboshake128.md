| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     151.7 ns |   0.94 ns |   0.83 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     176.8 ns |   0.61 ns |   0.54 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     182.4 ns |   0.78 ns |   0.69 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     149.9 ns |   0.95 ns |   0.89 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     173.0 ns |   0.27 ns |   0.22 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     178.7 ns |   0.81 ns |   0.68 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     845.6 ns |   3.66 ns |   3.05 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,080.8 ns |   2.94 ns |   2.75 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,109.9 ns |   2.67 ns |   2.36 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     845.4 ns |   3.18 ns |   2.48 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,081.5 ns |   2.38 ns |   2.11 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,114.2 ns |  12.40 ns |   9.68 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   5,347.6 ns |  24.86 ns |  19.41 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   6,913.9 ns |  15.77 ns |  13.98 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,095.9 ns |   8.43 ns |   7.47 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  84,307.3 ns | 603.65 ns | 564.65 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 109,448.8 ns | 202.59 ns | 179.59 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 112,349.2 ns | 239.13 ns | 199.68 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     173.6 ns |   1.18 ns |   0.99 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     196.2 ns |   0.35 ns |   0.29 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     201.4 ns |   0.63 ns |   0.59 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     170.9 ns |   1.29 ns |   1.21 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     193.4 ns |   0.82 ns |   0.73 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     198.3 ns |   0.71 ns |   0.67 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     875.4 ns |   8.60 ns |   7.62 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,111.0 ns |  16.54 ns |  14.66 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,134.6 ns |   4.07 ns |   3.61 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     872.2 ns |   5.83 ns |   5.17 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,110.3 ns |  13.94 ns |  11.64 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,144.5 ns |  12.68 ns |  11.86 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   5,425.2 ns |  97.28 ns |  91.00 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   6,942.0 ns |  24.53 ns |  22.94 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,144.5 ns |  17.04 ns |  15.10 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  84,421.0 ns | 563.16 ns | 470.26 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 109,878.2 ns | 486.09 ns | 405.91 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 112,573.5 ns | 491.35 ns | 410.30 ns |         - |