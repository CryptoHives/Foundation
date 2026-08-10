| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     123.5 ns |     0.36 ns |     0.34 ns |     123.5 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     156.9 ns |     0.53 ns |     0.49 ns |     156.9 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     165.3 ns |     0.56 ns |     0.47 ns |     165.3 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     124.0 ns |     0.27 ns |     0.24 ns |     123.9 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     158.9 ns |     2.42 ns |     2.14 ns |     158.2 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     164.9 ns |     0.41 ns |     0.37 ns |     165.0 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     784.9 ns |     1.70 ns |     1.51 ns |     784.8 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,006.0 ns |     2.10 ns |     1.86 ns |   1,005.8 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,040.6 ns |     4.29 ns |     3.58 ns |   1,041.0 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     786.3 ns |     2.81 ns |     2.63 ns |     786.1 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,006.6 ns |     3.56 ns |     3.33 ns |   1,006.8 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,042.3 ns |     3.40 ns |     3.18 ns |   1,041.8 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   5,420.1 ns |    14.39 ns |    12.76 ns |   5,418.4 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   6,941.7 ns |    17.25 ns |    15.29 ns |   6,939.3 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,161.9 ns |    21.60 ns |    19.15 ns |   7,163.3 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  86,812.0 ns |   209.11 ns |   185.37 ns |  86,806.6 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 113,960.1 ns |   222.77 ns |   186.03 ns | 113,938.7 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 116,064.7 ns | 2,327.31 ns | 6,862.11 ns | 111,637.2 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     124.8 ns |     0.33 ns |     0.29 ns |     124.8 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     157.4 ns |     0.39 ns |     0.37 ns |     157.5 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     164.9 ns |     0.82 ns |     0.64 ns |     165.1 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     124.7 ns |     0.23 ns |     0.19 ns |     124.7 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     157.5 ns |     0.41 ns |     0.36 ns |     157.5 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     164.7 ns |     0.50 ns |     0.47 ns |     164.6 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     785.2 ns |     1.83 ns |     1.71 ns |     785.3 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,008.2 ns |     3.21 ns |     3.00 ns |   1,006.9 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,040.1 ns |     4.15 ns |     3.46 ns |   1,039.9 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     784.2 ns |     2.10 ns |     1.86 ns |     784.1 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,007.6 ns |     3.62 ns |     3.38 ns |   1,006.9 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,038.8 ns |     3.60 ns |     3.20 ns |   1,038.9 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   5,401.3 ns |     9.86 ns |     8.23 ns |   5,398.9 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   6,963.5 ns |    17.32 ns |    15.35 ns |   6,966.4 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,147.5 ns |    16.62 ns |    13.88 ns |   7,148.9 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  86,408.9 ns |   951.30 ns |   843.30 ns |  85,991.0 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 110,731.6 ns |   339.17 ns |   283.22 ns | 110,739.1 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 114,050.9 ns |   852.07 ns |   755.34 ns | 113,831.3 ns |         - |