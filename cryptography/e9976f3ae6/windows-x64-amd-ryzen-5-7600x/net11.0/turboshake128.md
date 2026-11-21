| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     139.6 ns |   0.27 ns |   0.22 ns |  16,290 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     175.0 ns |   0.26 ns |   0.25 ns |  15,921 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     185.1 ns |   0.40 ns |   0.37 ns |   8,460 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     145.8 ns |   0.44 ns |   0.39 ns |  16,281 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     182.3 ns |   0.18 ns |   0.16 ns |  15,781 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     195.3 ns |   0.16 ns |   0.15 ns |  14,804 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     887.9 ns |   3.04 ns |   2.84 ns |  16,286 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,124.4 ns |   1.01 ns |   0.90 ns |   9,442 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,171.1 ns |   0.57 ns |   0.48 ns |  14,800 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     884.9 ns |   0.96 ns |   0.80 ns |   9,951 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,126.7 ns |   2.15 ns |   2.01 ns |  15,777 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,172.5 ns |   0.81 ns |   0.72 ns |   8,465 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   6,110.8 ns |  29.25 ns |  25.93 ns |  16,286 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   7,697.4 ns |  19.64 ns |  17.41 ns |   9,433 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   8,013.6 ns |  15.01 ns |  14.04 ns |  14,990 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  97,133.8 ns | 305.47 ns | 238.49 ns |  16,476 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 122,181.4 ns |  89.45 ns |  83.67 ns |   9,442 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 126,937.3 ns | 177.94 ns | 148.59 ns |   6,020 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     146.5 ns |   0.35 ns |   0.31 ns |   9,905 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     191.8 ns |   0.31 ns |   0.28 ns |   9,437 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     195.6 ns |   0.30 ns |   0.28 ns |  14,804 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     145.6 ns |   0.27 ns |   0.24 ns |  16,480 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     185.6 ns |   0.41 ns |   0.38 ns |   9,396 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     195.4 ns |   0.49 ns |   0.41 ns |  14,804 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     886.6 ns |   1.94 ns |   1.52 ns |  16,286 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,115.1 ns |   2.12 ns |   1.98 ns |  15,777 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,171.8 ns |   2.44 ns |   2.29 ns |  14,791 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     886.3 ns |   2.14 ns |   1.67 ns |  16,476 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,127.4 ns |   1.74 ns |   1.54 ns |   9,442 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,174.0 ns |   0.91 ns |   0.76 ns |   8,465 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   6,097.4 ns |  14.03 ns |  12.43 ns |   9,951 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   7,707.9 ns |  10.79 ns |  10.09 ns |  15,967 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   8,078.0 ns |   9.45 ns |   8.38 ns |  14,990 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  96,842.9 ns | 160.86 ns | 142.60 ns |   9,951 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 122,203.0 ns | 129.51 ns | 121.14 ns |   9,442 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 127,300.6 ns | 116.30 ns | 103.10 ns |  14,990 B |         - |