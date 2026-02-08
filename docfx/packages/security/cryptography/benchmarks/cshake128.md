| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE128 · Managed      | 128B         |     248.3 ns |     1.13 ns |     1.01 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 128B         |     320.8 ns |     0.85 ns |     0.80 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 128B         |     328.4 ns |     1.25 ns |     1.11 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128B         |     335.4 ns |     1.08 ns |     0.96 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 137B         |     244.8 ns |     1.16 ns |     1.03 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 137B         |     318.1 ns |     0.91 ns |     0.85 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 137B         |     325.6 ns |     0.81 ns |     0.68 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 137B         |     336.7 ns |     1.53 ns |     1.43 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 1KB          |   1,492.5 ns |     9.20 ns |     8.61 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 1KB          |   2,004.7 ns |    12.13 ns |    10.13 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 1KB          |   2,049.1 ns |     6.12 ns |     5.73 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1KB          |   2,190.7 ns |    13.47 ns |    12.60 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 1025B        |   1,491.6 ns |     9.55 ns |     8.93 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 1025B        |   2,001.3 ns |    11.32 ns |    10.03 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 1025B        |   2,059.2 ns |    13.10 ns |    10.94 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1025B        |   2,179.8 ns |    12.23 ns |    10.84 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 8KB          |   9,834.3 ns |    80.09 ns |    74.92 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 8KB          |  13,390.5 ns |    30.07 ns |    26.66 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 8KB          |  13,785.4 ns |    32.52 ns |    28.83 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 8KB          |  15,170.0 ns |   112.25 ns |   105.00 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 128KB        | 156,000.1 ns | 1,044.26 ns |   872.00 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 128KB        | 213,446.5 ns | 1,940.84 ns | 1,620.69 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 128KB        | 218,815.7 ns | 1,509.58 ns | 1,338.21 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128KB        | 240,576.9 ns | 1,271.51 ns | 1,127.16 ns |         - |