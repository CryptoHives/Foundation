| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · Managed | 128B         |     161.2 ns |   0.70 ns |   0.62 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 128B         |     188.6 ns |   0.50 ns |   0.46 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 128B         |     194.2 ns |   0.37 ns |   0.34 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 137B         |     309.6 ns |   0.98 ns |   0.82 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 137B         |     365.9 ns |   1.14 ns |   1.01 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 137B         |     376.5 ns |   0.40 ns |   0.31 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 1KB          |     919.7 ns |   2.81 ns |   2.62 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 1KB          |   1,192.4 ns |   2.74 ns |   2.56 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 1KB          |   1,260.5 ns |   2.00 ns |   1.87 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 1025B        |     920.8 ns |   2.55 ns |   2.39 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 1025B        |   1,201.0 ns |   3.81 ns |   3.56 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 1025B        |   1,259.6 ns |   3.46 ns |   3.06 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 8KB          |   6,582.2 ns |  19.69 ns |  17.45 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 8KB          |   8,677.5 ns |  20.60 ns |  19.27 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 8KB          |   9,131.7 ns |  19.32 ns |  17.12 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 128KB        | 102,694.7 ns | 484.86 ns | 453.54 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 128KB        | 135,525.7 ns | 261.62 ns | 204.25 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 128KB        | 142,204.0 ns | 251.94 ns | 235.66 ns |         - |