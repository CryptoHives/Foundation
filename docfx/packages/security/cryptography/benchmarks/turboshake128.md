| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · Managed | 128B         |     153.8 ns |   1.35 ns |   1.26 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 128B         |     177.1 ns |   0.88 ns |   0.78 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 128B         |     182.6 ns |   0.47 ns |   0.44 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 137B         |     149.6 ns |   1.14 ns |   1.01 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 137B         |     175.1 ns |   1.46 ns |   1.29 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 137B         |     179.4 ns |   1.22 ns |   1.08 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 1KB          |     844.5 ns |   2.38 ns |   2.22 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 1KB          |   1,090.5 ns |   4.94 ns |   4.62 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 1KB          |   1,128.0 ns |   7.23 ns |   6.41 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 1025B        |     847.1 ns |   4.36 ns |   3.64 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 1025B        |   1,089.0 ns |   3.26 ns |   2.89 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 1025B        |   1,122.8 ns |   3.56 ns |   2.97 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 8KB          |   5,316.5 ns |  33.30 ns |  31.15 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 8KB          |   6,959.3 ns |  10.06 ns |   9.41 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 8KB          |   7,174.9 ns |  16.49 ns |  15.42 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 128KB        |  83,788.8 ns | 288.72 ns | 255.94 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 128KB        | 110,369.2 ns | 219.84 ns | 183.57 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 128KB        | 113,634.3 ns | 162.63 ns | 144.17 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 128B         |     172.4 ns |   0.65 ns |   0.54 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 128B         |     197.8 ns |   0.69 ns |   0.54 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 128B         |     202.7 ns |   0.60 ns |   0.56 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 137B         |     171.9 ns |   1.61 ns |   1.35 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 137B         |     194.2 ns |   0.62 ns |   0.58 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 137B         |     198.7 ns |   0.28 ns |   0.25 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 1KB          |     864.2 ns |   3.93 ns |   3.68 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 1KB          |   1,110.7 ns |   4.08 ns |   3.61 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 1KB          |   1,147.3 ns |   4.06 ns |   3.60 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 1025B        |     865.2 ns |   3.31 ns |   2.93 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 1025B        |   1,111.6 ns |   5.86 ns |   5.48 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 1025B        |   1,147.2 ns |   6.65 ns |   5.19 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 8KB          |   5,314.3 ns |  18.66 ns |  15.58 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 8KB          |   6,983.6 ns |   7.02 ns |   6.22 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 8KB          |   7,187.0 ns |   7.60 ns |   6.35 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 128KB        |  83,521.0 ns | 307.33 ns | 272.44 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 128KB        | 110,149.1 ns | 120.24 ns |  93.88 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 128KB        | 113,535.2 ns | 214.85 ns | 179.41 ns |         - |