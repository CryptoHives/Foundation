| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE128 · Managed      | 128B         |     247.4 ns |     1.82 ns |     1.71 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 128B         |     317.0 ns |     1.06 ns |     0.89 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 128B         |     324.0 ns |     0.68 ns |     0.60 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 128B         |     336.9 ns |     2.21 ns |     1.84 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 128B         |     357.4 ns |     1.62 ns |     1.51 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 137B         |     243.7 ns |     2.29 ns |     1.91 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 137B         |     313.3 ns |     1.87 ns |     1.75 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 137B         |     320.7 ns |     1.57 ns |     1.39 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 137B         |     336.9 ns |     2.19 ns |     2.05 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 137B         |     360.3 ns |     2.72 ns |     2.55 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 1KB          |   1,499.6 ns |    13.76 ns |    12.88 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 1KB          |   1,808.6 ns |     9.14 ns |     8.55 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 1KB          |   1,996.3 ns |     8.52 ns |     7.12 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 1KB          |   2,043.3 ns |     5.86 ns |     5.48 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 1KB          |   2,188.1 ns |    13.31 ns |    11.80 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 1025B        |   1,518.6 ns |    24.97 ns |    20.85 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 1025B        |   1,803.3 ns |    13.42 ns |    12.55 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 1025B        |   1,995.4 ns |     4.65 ns |     3.88 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 1025B        |   2,048.1 ns |     9.38 ns |     7.83 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 1025B        |   2,184.4 ns |    17.74 ns |    14.81 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 8KB          |   9,933.0 ns |    95.42 ns |    89.26 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 8KB          |  11,876.1 ns |    70.84 ns |    62.80 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 8KB          |  13,312.3 ns |    27.91 ns |    26.11 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 8KB          |  13,609.7 ns |    33.44 ns |    29.65 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 8KB          |  15,199.7 ns |    67.32 ns |    59.68 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 128KB        | 156,778.3 ns | 1,127.35 ns |   999.36 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 128KB        | 187,637.4 ns | 1,208.23 ns | 1,130.18 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 128KB        | 211,420.1 ns |   408.31 ns |   361.96 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 128KB        | 216,188.8 ns |   623.52 ns |   583.24 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 128KB        | 242,281.1 ns | 1,203.73 ns | 1,125.97 ns |         - |