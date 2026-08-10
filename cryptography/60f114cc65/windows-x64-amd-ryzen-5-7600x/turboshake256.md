| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · Managed | 128B         |     162.4 ns |   1.69 ns |   1.58 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 128B         |     187.0 ns |   0.98 ns |   0.87 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 128B         |     190.4 ns |   0.55 ns |   0.52 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 137B         |     324.8 ns |   2.76 ns |   2.58 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 137B         |     375.8 ns |   1.05 ns |   0.93 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 137B         |     389.4 ns |   1.00 ns |   0.93 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 1KB          |     937.5 ns |   3.47 ns |   2.89 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 1KB          |   1,208.0 ns |   4.79 ns |   4.25 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 1KB          |   1,247.9 ns |   3.07 ns |   2.72 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 1025B        |     937.7 ns |   6.80 ns |   6.02 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 1025B        |   1,204.4 ns |   4.49 ns |   3.98 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 1025B        |   1,250.1 ns |   3.52 ns |   3.29 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 8KB          |   6,607.2 ns |  27.63 ns |  23.07 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 8KB          |   8,623.2 ns |  43.91 ns |  38.93 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 8KB          |   8,903.8 ns |  28.77 ns |  26.91 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · Managed | 128KB        | 102,710.1 ns | 560.30 ns | 524.10 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX2    | 128KB        | 134,472.9 ns | 611.62 ns | 542.18 ns |         - |
| TryComputeHash · TurboSHAKE256 · AVX512F | 128KB        | 139,561.4 ns | 573.05 ns | 508.00 ns |         - |