| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE128 · Managed      | 128B         |     243.3 ns |     1.52 ns |     1.42 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 128B         |     317.9 ns |     1.20 ns |     1.13 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 128B         |     325.2 ns |     0.87 ns |     0.73 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 128B         |     331.8 ns |     1.10 ns |     1.03 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 128B         |     354.4 ns |     1.74 ns |     1.62 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 137B         |     240.6 ns |     1.34 ns |     1.25 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 137B         |     314.4 ns |     1.22 ns |     1.08 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 137B         |     321.9 ns |     1.00 ns |     0.83 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 137B         |     333.2 ns |     1.60 ns |     1.50 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 137B         |     354.0 ns |     2.20 ns |     2.06 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 1KB          |   1,471.4 ns |     5.88 ns |     5.50 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 1KB          |   1,768.1 ns |     5.01 ns |     4.18 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 1KB          |   1,993.4 ns |     4.13 ns |     3.86 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 1KB          |   2,054.2 ns |     9.13 ns |     8.09 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 1KB          |   2,165.8 ns |     9.74 ns |     9.11 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 1025B        |   1,468.1 ns |     3.61 ns |     3.38 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 1025B        |   1,777.8 ns |     6.86 ns |     5.73 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 1025B        |   1,996.3 ns |     4.95 ns |     4.13 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 1025B        |   2,054.6 ns |     4.20 ns |     3.72 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 1025B        |   2,156.4 ns |     5.25 ns |     4.65 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 8KB          |   9,779.0 ns |    61.98 ns |    54.94 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 8KB          |  11,695.4 ns |    45.73 ns |    42.78 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 8KB          |  13,367.5 ns |    32.63 ns |    30.52 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 8KB          |  13,814.3 ns |    25.33 ns |    23.69 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 8KB          |  15,055.3 ns |    40.13 ns |    37.54 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 128KB        | 154,375.6 ns |   334.52 ns |   261.17 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 128KB        | 184,826.8 ns |   798.23 ns |   746.66 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 128KB        | 212,691.9 ns |   592.29 ns |   525.05 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 128KB        | 223,661.3 ns | 1,270.36 ns | 1,060.81 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 128KB        | 237,677.5 ns |   852.16 ns |   797.11 ns |         - |