| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · Managed      | 128B         |     250.7 ns |     0.95 ns |     0.79 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 128B         |     325.5 ns |     0.75 ns |     0.63 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 128B         |     331.2 ns |     1.35 ns |     1.26 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 128B         |     334.4 ns |     0.76 ns |     0.71 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 128B         |     353.8 ns |     1.79 ns |     1.59 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 137B         |     490.8 ns |     3.37 ns |     2.99 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 137B         |     584.5 ns |     2.57 ns |     2.28 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 137B         |     630.8 ns |     3.04 ns |     2.84 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 137B         |     644.1 ns |     2.63 ns |     2.33 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 137B         |     661.2 ns |     2.16 ns |     1.91 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 1KB          |   1,646.4 ns |     5.66 ns |     5.29 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 1KB          |   1,996.0 ns |    11.77 ns |    11.01 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 1KB          |   2,242.4 ns |     9.64 ns |     8.54 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 1KB          |   2,333.4 ns |     8.33 ns |     6.95 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 1KB          |   2,461.3 ns |    11.18 ns |    10.46 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 1025B        |   1,647.7 ns |    11.64 ns |    10.88 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 1025B        |   1,996.2 ns |     8.98 ns |     7.50 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 1025B        |   2,238.2 ns |     7.19 ns |     6.72 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 1025B        |   2,333.1 ns |    11.64 ns |     9.72 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 1025B        |   2,458.6 ns |    14.03 ns |    13.13 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 8KB          |  12,077.2 ns |    59.41 ns |    52.67 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 8KB          |  14,425.6 ns |    47.02 ns |    41.68 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 8KB          |  16,630.6 ns |    78.02 ns |    72.98 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 8KB          |  17,326.6 ns |    32.39 ns |    27.05 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 8KB          |  18,545.6 ns |   106.21 ns |    99.35 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 128KB        | 190,319.3 ns | 1,036.22 ns |   918.59 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 128KB        | 226,637.2 ns |   856.63 ns |   801.29 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 128KB        | 263,413.7 ns |   946.41 ns |   885.27 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 128KB        | 272,233.7 ns | 1,263.61 ns | 1,120.16 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 128KB        | 292,723.1 ns | 1,196.37 ns | 1,060.55 ns |         - |