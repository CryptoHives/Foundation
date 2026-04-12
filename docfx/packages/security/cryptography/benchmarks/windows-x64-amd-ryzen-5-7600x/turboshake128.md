| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · Managed | 128B         |     153.6 ns |   0.82 ns |   0.76 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 128B         |     177.7 ns |   0.94 ns |   0.88 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 128B         |     182.5 ns |   1.01 ns |   0.94 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 137B         |     150.5 ns |   1.42 ns |   1.33 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 137B         |     174.7 ns |   0.90 ns |   0.84 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 137B         |     178.9 ns |   0.94 ns |   0.88 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 1KB          |     856.5 ns |   5.58 ns |   5.22 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 1KB          |   1,091.6 ns |   3.82 ns |   3.58 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 1KB          |   1,123.0 ns |   3.41 ns |   2.66 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 1025B        |     855.3 ns |   4.25 ns |   3.98 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 1025B        |   1,091.0 ns |   4.25 ns |   3.77 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 1025B        |   1,123.5 ns |   1.98 ns |   1.66 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 8KB          |   5,371.5 ns |  26.28 ns |  23.30 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 8KB          |   6,999.0 ns |  14.02 ns |  13.11 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 8KB          |   7,165.9 ns |  13.65 ns |  12.77 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · Managed | 128KB        |  84,581.3 ns | 656.27 ns | 581.76 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX2    | 128KB        | 110,439.0 ns | 239.37 ns | 223.90 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · AVX512F | 128KB        | 113,394.7 ns | 104.80 ns |  92.90 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 128B         |     174.7 ns |   0.91 ns |   0.80 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 128B         |     198.6 ns |   1.08 ns |   1.01 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 128B         |     203.3 ns |   1.06 ns |   0.94 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 137B         |     171.5 ns |   1.30 ns |   1.21 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 137B         |     197.5 ns |   0.92 ns |   0.86 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 137B         |     199.0 ns |   0.95 ns |   0.89 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 1KB          |     874.4 ns |   5.84 ns |   5.46 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 1KB          |   1,113.8 ns |   3.42 ns |   3.03 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 1KB          |   1,146.3 ns |   2.77 ns |   2.31 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 1025B        |     875.4 ns |   4.82 ns |   4.51 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 1025B        |   1,113.4 ns |   3.24 ns |   3.03 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 1025B        |   1,161.1 ns |   3.68 ns |   3.26 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 8KB          |   5,383.5 ns |  33.22 ns |  29.45 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 8KB          |   7,004.5 ns |  25.55 ns |  22.65 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 8KB          |   7,197.1 ns |  11.85 ns |   9.89 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · Managed | 128KB        |  84,848.1 ns | 722.24 ns | 640.25 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX2    | 128KB        | 111,009.9 ns | 225.00 ns | 210.46 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · AVX512F | 128KB        | 113,380.0 ns | 147.59 ns | 138.06 ns |         - |