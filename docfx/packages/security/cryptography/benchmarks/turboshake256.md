| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · Managed | 128B         |     161.4 ns |   0.50 ns |   0.42 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 128B         |     187.3 ns |   0.33 ns |   0.28 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 128B         |     192.8 ns |   0.61 ns |   0.57 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 137B         |     314.3 ns |   2.12 ns |   1.98 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 137B         |     372.5 ns |   1.19 ns |   1.05 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 137B         |     377.4 ns |   1.25 ns |   1.17 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 1KB          |     923.4 ns |   4.42 ns |   3.69 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 1KB          |   1,200.0 ns |   4.10 ns |   3.63 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 1KB          |   1,266.0 ns |   5.62 ns |   4.99 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 1025B        |     925.9 ns |   6.86 ns |   6.42 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 1025B        |   1,204.7 ns |   5.59 ns |   4.96 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 1025B        |   1,269.3 ns |   4.86 ns |   4.54 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 8KB          |   6,563.6 ns |  36.08 ns |  31.99 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 8KB          |   8,661.4 ns |  29.39 ns |  24.54 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 8KB          |   9,180.7 ns |  48.94 ns |  45.78 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 128KB        | 102,570.0 ns | 610.48 ns | 571.04 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 128KB        | 136,320.5 ns | 348.10 ns | 325.62 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 128KB        | 142,142.7 ns | 429.06 ns | 401.34 ns |         - |