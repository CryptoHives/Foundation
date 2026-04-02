| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE128 · Managed      | 128B         |     244.1 ns |     1.31 ns |     1.10 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 128B         |     315.8 ns |     0.92 ns |     0.86 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 128B         |     324.6 ns |     0.87 ns |     0.82 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 128B         |     334.0 ns |     1.54 ns |     1.44 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 128B         |     358.6 ns |     1.62 ns |     1.52 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 137B         |     241.7 ns |     1.52 ns |     1.35 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 137B         |     312.8 ns |     0.63 ns |     0.55 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 137B         |     320.6 ns |     1.04 ns |     0.98 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 137B         |     333.0 ns |     1.64 ns |     1.53 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 137B         |     358.8 ns |     2.54 ns |     2.37 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 1KB          |   1,485.8 ns |     4.89 ns |     4.33 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 1KB          |   1,777.4 ns |     4.11 ns |     3.43 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 1KB          |   1,996.8 ns |     7.95 ns |     7.44 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 1KB          |   2,042.9 ns |     5.80 ns |     5.14 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 1KB          |   2,170.9 ns |     7.58 ns |     6.72 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 1025B        |   1,485.0 ns |    10.08 ns |     9.43 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 1025B        |   1,773.7 ns |     6.55 ns |     6.12 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 1025B        |   1,992.2 ns |     5.76 ns |     5.39 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 1025B        |   2,043.4 ns |     3.80 ns |     3.55 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 1025B        |   2,161.2 ns |     9.79 ns |     8.68 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 8KB          |   9,773.8 ns |    52.26 ns |    48.89 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 8KB          |  11,695.0 ns |    39.91 ns |    35.38 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 8KB          |  13,288.0 ns |    17.78 ns |    15.76 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 8KB          |  13,611.2 ns |    22.10 ns |    19.59 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 8KB          |  14,992.4 ns |    50.70 ns |    47.42 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 128KB        | 155,257.5 ns | 1,757.42 ns | 1,643.89 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 128KB        | 184,993.6 ns | 1,302.82 ns | 1,218.66 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 128KB        | 211,627.5 ns |   490.62 ns |   458.93 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 128KB        | 215,844.5 ns |   401.85 ns |   375.89 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 128KB        | 239,279.5 ns |   951.13 ns |   889.69 ns |         - |