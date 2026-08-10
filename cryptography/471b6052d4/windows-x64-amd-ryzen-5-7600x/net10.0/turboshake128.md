| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · Managed | 128B         |     152.9 ns |   0.54 ns |   0.45 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 128B         |     179.6 ns |   0.58 ns |   0.55 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 128B         |     183.8 ns |   0.45 ns |   0.42 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 137B         |     151.1 ns |   0.58 ns |   0.52 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 137B         |     179.3 ns |   0.87 ns |   0.81 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 137B         |     181.0 ns |   0.27 ns |   0.25 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 1KB          |     836.3 ns |   3.34 ns |   3.12 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 1KB          |   1,081.2 ns |   4.23 ns |   3.96 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 1KB          |   1,127.3 ns |   3.86 ns |   3.61 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 1025B        |     838.2 ns |   4.13 ns |   3.87 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 1025B        |   1,080.4 ns |   3.88 ns |   3.63 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 1025B        |   1,131.9 ns |   3.78 ns |   3.35 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 8KB          |   5,300.1 ns |  20.54 ns |  17.15 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 8KB          |   6,973.4 ns |   9.20 ns |   7.68 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 8KB          |   7,322.5 ns |  10.40 ns |   9.73 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 128KB        |  84,326.7 ns | 541.44 ns | 479.97 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 128KB        | 110,936.0 ns | 283.17 ns | 264.87 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 128KB        | 117,818.0 ns | 207.08 ns | 193.71 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 128B         |     173.3 ns |   0.61 ns |   0.54 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 128B         |     199.4 ns |   0.52 ns |   0.49 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 128B         |     204.0 ns |   0.85 ns |   0.80 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 137B         |     170.6 ns |   0.59 ns |   0.52 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 137B         |     196.2 ns |   0.54 ns |   0.51 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 137B         |     201.9 ns |   0.59 ns |   0.56 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 1KB          |     857.8 ns |   3.37 ns |   3.15 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 1KB          |   1,099.8 ns |   2.02 ns |   1.69 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 1KB          |   1,148.5 ns |   3.49 ns |   3.09 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 1025B        |     858.5 ns |   3.47 ns |   3.07 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 1025B        |   1,101.1 ns |   3.63 ns |   3.39 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 1025B        |   1,171.8 ns |   3.04 ns |   2.84 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 8KB          |   5,327.8 ns |  18.23 ns |  16.16 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 8KB          |   7,018.7 ns |  13.11 ns |  12.26 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 8KB          |   7,339.8 ns |  11.86 ns |  11.09 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 128KB        |  84,230.5 ns | 525.58 ns | 491.63 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 128KB        | 110,918.1 ns | 275.68 ns | 215.23 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 128KB        | 117,827.9 ns | 201.75 ns | 178.84 ns |         - |