| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · Managed      | 128B         |     250.4 ns |     1.40 ns |     1.24 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 128B         |     326.6 ns |     0.81 ns |     0.68 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 128B         |     331.3 ns |     2.13 ns |     1.89 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 128B         |     332.5 ns |     1.76 ns |     1.47 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 128B         |     355.5 ns |     2.69 ns |     2.52 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 137B         |     504.5 ns |     5.16 ns |     4.83 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 137B         |     590.2 ns |     2.69 ns |     2.51 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 137B         |     628.1 ns |     2.39 ns |     2.23 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 137B         |     653.0 ns |     2.00 ns |     1.87 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 137B         |     678.2 ns |     1.19 ns |     1.00 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 1KB          |   1,655.1 ns |    10.38 ns |     9.71 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 1KB          |   1,992.3 ns |     8.17 ns |     7.24 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 1KB          |   2,243.3 ns |     5.24 ns |     4.64 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 1KB          |   2,301.7 ns |     7.64 ns |     6.78 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 1KB          |   2,460.0 ns |    10.76 ns |    10.07 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 1025B        |   1,658.6 ns |    13.45 ns |    11.92 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 1025B        |   1,999.7 ns |    21.58 ns |    19.13 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 1025B        |   2,245.7 ns |    11.51 ns |    10.20 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 1025B        |   2,305.9 ns |     4.19 ns |     3.71 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 1025B        |   2,522.9 ns |    11.34 ns |    10.61 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 8KB          |  12,251.7 ns |    57.35 ns |    50.84 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 8KB          |  14,402.5 ns |    72.91 ns |    68.20 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 8KB          |  16,495.4 ns |    47.78 ns |    44.70 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 8KB          |  16,925.4 ns |    44.77 ns |    39.69 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 8KB          |  18,488.5 ns |    47.01 ns |    41.68 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 128KB        | 189,474.0 ns |   932.69 ns |   826.80 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 128KB        | 226,085.8 ns | 1,248.89 ns | 1,168.21 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 128KB        | 259,193.5 ns |   452.91 ns |   401.49 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 128KB        | 265,761.5 ns |   727.08 ns |   680.11 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 128KB        | 293,178.7 ns |   671.83 ns |   524.52 ns |         - |