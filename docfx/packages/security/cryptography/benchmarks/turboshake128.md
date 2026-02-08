| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · Managed | 128B         |     153.2 ns |   1.09 ns |   1.02 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 128B         |     180.1 ns |   0.37 ns |   0.35 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 128B         |     184.1 ns |   0.67 ns |   0.63 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 137B         |     150.6 ns |   1.09 ns |   1.02 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 137B         |     176.4 ns |   0.48 ns |   0.42 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 137B         |     181.6 ns |   0.75 ns |   0.70 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 1KB          |     847.2 ns |   5.31 ns |   4.97 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 1KB          |   1,088.5 ns |   2.21 ns |   1.85 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 1KB          |   1,132.7 ns |   2.01 ns |   1.88 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 1025B        |     838.1 ns |   4.91 ns |   4.59 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 1025B        |   1,089.9 ns |   4.33 ns |   4.05 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 1025B        |   1,138.4 ns |   4.80 ns |   4.49 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 8KB          |   5,317.0 ns |  19.36 ns |  17.16 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 8KB          |   7,049.3 ns |  13.79 ns |  11.52 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 8KB          |   7,349.9 ns |  14.96 ns |  13.26 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 128KB        |  84,294.0 ns | 411.74 ns | 385.14 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 128KB        | 111,349.5 ns | 254.70 ns | 225.78 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 128KB        | 118,593.3 ns | 408.76 ns | 382.36 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 128B         |     174.3 ns |   0.97 ns |   0.91 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 128B         |     200.8 ns |   0.60 ns |   0.57 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 128B         |     206.9 ns |   0.35 ns |   0.29 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 137B         |     171.7 ns |   1.20 ns |   1.13 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 137B         |     196.2 ns |   0.72 ns |   0.67 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 137B         |     201.1 ns |   0.48 ns |   0.43 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 1KB          |     857.4 ns |   2.56 ns |   2.39 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 1KB          |   1,105.8 ns |   2.47 ns |   2.06 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 1KB          |   1,153.4 ns |   3.05 ns |   2.71 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 1025B        |     857.7 ns |   3.98 ns |   3.32 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 1025B        |   1,107.2 ns |   4.90 ns |   4.59 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 1025B        |   1,158.3 ns |   3.52 ns |   3.29 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 8KB          |   5,358.5 ns |  36.01 ns |  33.68 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 8KB          |   7,056.3 ns |  18.94 ns |  15.81 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 8KB          |   7,393.6 ns |  25.93 ns |  22.98 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 128KB        | 101,937.7 ns | 415.72 ns | 388.86 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 128KB        | 111,490.8 ns | 292.73 ns | 228.54 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 128KB        | 118,387.7 ns | 343.02 ns | 320.86 ns |         - |