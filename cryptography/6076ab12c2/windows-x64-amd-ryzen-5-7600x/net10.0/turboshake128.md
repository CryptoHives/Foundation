| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     138.3 ns |   0.32 ns |   0.28 ns |   5,590 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     176.3 ns |   0.24 ns |   0.23 ns |   5,099 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     192.1 ns |   0.09 ns |   0.09 ns |   4,094 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     138.3 ns |   0.39 ns |   0.34 ns |   5,606 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     175.8 ns |   0.12 ns |   0.10 ns |   5,115 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     190.8 ns |   0.22 ns |   0.20 ns |   4,110 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     880.9 ns |   0.99 ns |   0.93 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,117.2 ns |   0.94 ns |   0.88 ns |   5,081 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,209.4 ns |   1.13 ns |   1.05 ns |   4,076 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     880.1 ns |   0.89 ns |   0.83 ns |   5,574 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,116.4 ns |   0.81 ns |   0.76 ns |   5,083 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,210.2 ns |   0.46 ns |   0.41 ns |   4,078 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   6,075.5 ns |   9.03 ns |   7.54 ns |   5,578 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   7,694.7 ns |  11.03 ns |  10.32 ns |   5,087 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   8,330.2 ns |   6.19 ns |   5.49 ns |   4,082 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  96,653.8 ns | 151.13 ns | 141.36 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 122,364.7 ns |  60.68 ns |  53.79 ns |   5,081 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 132,487.2 ns | 104.15 ns |  97.42 ns |   4,076 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     139.4 ns |   0.35 ns |   0.33 ns |   5,589 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     177.6 ns |   0.23 ns |   0.20 ns |   5,096 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     191.8 ns |   0.17 ns |   0.15 ns |   4,094 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     138.8 ns |   0.24 ns |   0.23 ns |   5,589 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     177.3 ns |   0.15 ns |   0.14 ns |   5,098 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     192.5 ns |   0.15 ns |   0.14 ns |   4,089 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     881.7 ns |   1.13 ns |   1.00 ns |   5,570 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,118.3 ns |   0.86 ns |   0.80 ns |   5,079 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,208.5 ns |   0.89 ns |   0.83 ns |   4,074 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     881.2 ns |   0.97 ns |   0.91 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,116.7 ns |   0.58 ns |   0.54 ns |   5,081 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,207.3 ns |   1.26 ns |   1.17 ns |   4,076 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   6,075.4 ns |   9.16 ns |   8.57 ns |   5,577 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   7,735.9 ns |   9.84 ns |   9.20 ns |   5,082 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   8,337.4 ns |  10.87 ns |  10.16 ns |   4,077 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  96,482.9 ns | 161.45 ns | 151.02 ns |   5,570 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 122,337.1 ns |  87.30 ns |  81.66 ns |   5,079 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 132,382.8 ns |  83.79 ns |  74.28 ns |   4,074 B |         - |