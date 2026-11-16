| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     139.7 ns |     1.43 ns |     1.20 ns |   5,606 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     177.1 ns |     0.38 ns |     0.35 ns |   5,097 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     183.1 ns |     0.32 ns |     0.30 ns |   4,110 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     139.4 ns |     0.44 ns |     0.34 ns |   5,606 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     173.2 ns |     0.09 ns |     0.07 ns |   5,081 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     182.7 ns |     0.62 ns |     0.55 ns |   4,094 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     885.1 ns |     4.23 ns |     3.75 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,118.5 ns |     1.90 ns |     1.78 ns |   5,065 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,155.1 ns |     1.04 ns |     0.92 ns |   4,076 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     894.3 ns |    16.75 ns |    15.67 ns |   5,574 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,131.2 ns |    13.02 ns |    12.18 ns |   5,065 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,155.9 ns |     2.17 ns |     2.03 ns |   4,078 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   6,109.1 ns |    25.38 ns |    22.49 ns |   5,578 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   7,774.0 ns |    18.66 ns |    15.59 ns |   5,069 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,936.4 ns |    12.94 ns |    11.47 ns |   4,082 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  97,731.5 ns | 1,148.63 ns | 1,074.43 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 123,011.0 ns |   100.57 ns |    89.15 ns |   5,063 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 126,418.7 ns |   164.71 ns |   128.59 ns |   4,076 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     139.3 ns |     0.59 ns |     0.52 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     173.3 ns |     0.33 ns |     0.30 ns |   5,080 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     181.8 ns |     0.32 ns |     0.30 ns |   4,093 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     139.7 ns |     1.14 ns |     1.01 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     174.9 ns |     1.39 ns |     1.23 ns |   5,080 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     182.5 ns |     0.35 ns |     0.33 ns |   4,093 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     896.8 ns |     9.77 ns |     8.66 ns |   5,570 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,116.8 ns |     1.11 ns |     0.92 ns |   5,061 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,155.1 ns |     1.84 ns |     1.72 ns |   4,074 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     886.1 ns |     5.83 ns |     5.17 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,116.9 ns |     0.80 ns |     0.67 ns |   5,063 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,151.2 ns |     1.49 ns |     1.24 ns |   4,076 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   6,122.6 ns |    43.09 ns |    33.64 ns |   5,573 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   7,741.5 ns |    18.44 ns |    16.35 ns |   5,064 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,944.3 ns |    11.80 ns |    11.04 ns |   4,077 B |         - |
|                                                         |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  98,717.5 ns |   916.10 ns |   812.10 ns |   5,570 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 122,967.3 ns |   144.67 ns |   128.25 ns |   5,061 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 126,058.1 ns |   111.48 ns |    93.09 ns |   4,074 B |         - |