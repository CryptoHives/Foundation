| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · Managed | 128B         |     159.1 ns |   1.12 ns |   1.05 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 128B         |     185.8 ns |   0.39 ns |   0.33 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 128B         |     189.8 ns |   0.32 ns |   0.28 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 137B         |     320.7 ns |   1.72 ns |   1.61 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 137B         |     375.3 ns |   0.92 ns |   0.81 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 137B         |     388.2 ns |   1.22 ns |   1.15 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 1KB          |     927.5 ns |   6.68 ns |   6.25 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 1KB          |   1,205.3 ns |   3.79 ns |   3.54 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 1KB          |   1,244.8 ns |   3.23 ns |   3.03 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 1025B        |     923.7 ns |   4.80 ns |   4.49 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 1025B        |   1,202.0 ns |   4.87 ns |   4.56 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 1025B        |   1,244.2 ns |   4.86 ns |   4.06 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 8KB          |   6,543.2 ns |  38.09 ns |  35.63 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 8KB          |   8,599.4 ns |  18.75 ns |  17.54 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 8KB          |   8,911.2 ns |  19.66 ns |  17.43 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 128KB        | 101,215.2 ns | 338.83 ns | 300.36 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 128KB        | 134,094.9 ns | 360.29 ns | 319.39 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 128KB        | 139,133.1 ns | 514.02 ns | 455.66 ns |         - |