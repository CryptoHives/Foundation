| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     139.5 ns |   0.30 ns |   0.27 ns |   5,590 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     172.1 ns |   0.14 ns |   0.13 ns |   5,081 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     181.5 ns |   0.13 ns |   0.12 ns |   4,110 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     139.0 ns |   0.26 ns |   0.24 ns |   5,606 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     172.7 ns |   0.18 ns |   0.17 ns |   5,097 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     181.8 ns |   0.09 ns |   0.09 ns |   4,110 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     880.7 ns |   1.65 ns |   1.46 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,116.2 ns |   0.76 ns |   0.71 ns |   5,063 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,152.7 ns |   0.90 ns |   0.85 ns |   4,076 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     882.3 ns |   1.04 ns |   0.97 ns |   5,574 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,117.2 ns |   0.61 ns |   0.54 ns |   5,065 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,153.3 ns |   0.52 ns |   0.46 ns |   4,078 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   6,083.4 ns |  12.84 ns |  12.01 ns |   5,578 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   7,723.0 ns |   7.43 ns |   6.95 ns |   5,069 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,921.1 ns |   4.83 ns |   4.28 ns |   4,082 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  96,639.8 ns | 177.06 ns | 165.62 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 122,839.2 ns |  97.15 ns |  90.87 ns |   5,063 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 126,260.2 ns | 107.04 ns | 100.13 ns |   4,076 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     139.1 ns |   0.37 ns |   0.35 ns |   5,589 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     177.1 ns |   0.15 ns |   0.14 ns |   5,080 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     181.1 ns |   0.21 ns |   0.20 ns |   4,094 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     138.8 ns |   0.27 ns |   0.24 ns |   5,589 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     173.1 ns |   0.09 ns |   0.08 ns |   5,078 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     181.0 ns |   0.19 ns |   0.18 ns |   4,094 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     881.6 ns |   1.06 ns |   0.99 ns |   5,570 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,115.2 ns |   0.69 ns |   0.61 ns |   5,061 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,151.3 ns |   0.94 ns |   0.88 ns |   4,074 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     881.0 ns |   0.99 ns |   0.83 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,114.6 ns |   0.33 ns |   0.26 ns |   5,063 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,151.5 ns |   0.96 ns |   0.90 ns |   4,076 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   6,087.9 ns |   9.48 ns |   8.87 ns |   5,573 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   7,722.1 ns |   6.00 ns |   5.61 ns |   5,064 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,928.3 ns |   8.29 ns |   7.75 ns |   4,077 B |         - |
|                                                         |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  96,700.9 ns | 196.69 ns | 183.99 ns |   5,570 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 122,833.2 ns | 122.56 ns | 108.64 ns |   5,061 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 126,216.5 ns | 121.35 ns | 113.51 ns |   4,074 B |         - |