| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · Managed      | 128B         |     430.3 ns |     2.36 ns |     2.09 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 128B         |     580.3 ns |     1.96 ns |     1.64 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 128B         |     597.5 ns |     3.81 ns |     3.56 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 128B         |     647.4 ns |     4.74 ns |     4.44 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 137B         |     428.2 ns |     2.19 ns |     2.05 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 137B         |     576.1 ns |     3.52 ns |     2.75 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 137B         |     593.4 ns |     2.59 ns |     2.30 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 137B         |     630.0 ns |     2.22 ns |     1.96 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 1KB          |   1,983.2 ns |    16.85 ns |    15.76 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 1KB          |   2,719.8 ns |    16.92 ns |    15.00 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 1KB          |   2,796.4 ns |    11.25 ns |     9.97 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 1KB          |   3,064.3 ns |    20.65 ns |    19.32 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 1025B        |   1,984.5 ns |    15.56 ns |    14.55 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 1025B        |   2,702.0 ns |    12.04 ns |    11.26 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 1025B        |   2,791.0 ns |    10.95 ns |    10.24 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 1025B        |   3,064.2 ns |    20.09 ns |    18.79 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 8KB          |  15,606.2 ns |   106.96 ns |   100.05 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 8KB          |  21,298.2 ns |   101.57 ns |    95.01 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 8KB          |  21,887.7 ns |    70.37 ns |    58.76 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 8KB          |  23,872.7 ns |    92.86 ns |    82.31 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 128KB        | 247,027.5 ns | 1,793.77 ns | 1,590.13 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 128KB        | 338,885.8 ns | 1,885.22 ns | 1,671.20 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 128KB        | 350,174.1 ns | 1,253.74 ns | 1,172.75 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 128KB        | 381,565.5 ns | 2,382.09 ns | 2,228.21 ns |         - |