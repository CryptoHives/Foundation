| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · Managed      | 128B         |     252.5 ns |     1.78 ns |     1.48 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 128B         |     325.8 ns |     0.61 ns |     0.57 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 128B         |     331.9 ns |     0.94 ns |     0.83 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 128B         |     335.0 ns |     1.61 ns |     1.51 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 128B         |     357.9 ns |     2.97 ns |     2.64 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 137B         |     507.6 ns |     4.06 ns |     3.60 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 137B         |     597.8 ns |     2.80 ns |     2.48 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 137B         |     636.6 ns |     3.09 ns |     2.89 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 137B         |     655.7 ns |     1.76 ns |     1.56 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 137B         |     672.7 ns |     2.22 ns |     2.08 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 1KB          |   1,677.5 ns |     6.73 ns |     5.97 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 1KB          |   2,029.1 ns |    14.79 ns |    12.35 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 1KB          |   2,244.4 ns |     7.55 ns |     6.70 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 1KB          |   2,297.6 ns |     6.16 ns |     5.76 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 1KB          |   2,491.2 ns |    11.95 ns |    11.18 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 1025B        |   1,671.2 ns |     7.74 ns |     6.86 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 1025B        |   2,043.0 ns |    24.21 ns |    22.65 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 1025B        |   2,243.0 ns |     8.65 ns |     8.09 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 1025B        |   2,300.0 ns |    10.09 ns |     9.44 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 1025B        |   2,492.0 ns |    15.08 ns |    13.37 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 8KB          |  12,238.7 ns |    82.43 ns |    77.10 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 8KB          |  14,658.4 ns |    79.52 ns |    70.49 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 8KB          |  16,570.6 ns |    84.38 ns |    78.93 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 8KB          |  16,929.1 ns |    69.48 ns |    64.99 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 8KB          |  18,794.8 ns |   147.35 ns |   137.83 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE256 · Managed      | 128KB        | 191,514.5 ns | 2,024.14 ns | 1,690.24 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 128KB        | 228,912.7 ns | 2,252.61 ns | 1,996.88 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 128KB        | 259,999.4 ns | 1,347.95 ns | 1,260.87 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 128KB        | 266,239.3 ns | 1,215.30 ns | 1,014.83 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 128KB        | 295,785.2 ns | 1,704.66 ns | 1,594.54 ns |         - |