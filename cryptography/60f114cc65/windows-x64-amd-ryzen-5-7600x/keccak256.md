| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-256 · Managed      | 128B         |     211.8 ns |     1.44 ns |     1.35 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 128B         |     281.1 ns |     0.71 ns |     0.63 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 128B         |     289.9 ns |     0.87 ns |     0.82 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128B         |     335.3 ns |     2.35 ns |     2.20 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 137B         |     456.0 ns |     1.86 ns |     1.55 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 137B         |     611.8 ns |     1.68 ns |     1.40 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 137B         |     631.0 ns |     1.39 ns |     1.30 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 137B         |     636.5 ns |     3.84 ns |     3.21 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 1KB          |   1,645.9 ns |     8.59 ns |     7.61 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 1KB          |   2,199.9 ns |     7.11 ns |     6.65 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 1KB          |   2,261.8 ns |     9.28 ns |     8.68 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 1KB          |   2,481.8 ns |    23.66 ns |    22.14 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 1025B        |   1,638.0 ns |     9.71 ns |     8.61 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 1025B        |   2,215.0 ns |    23.45 ns |    19.59 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 1025B        |   2,260.2 ns |     5.70 ns |     5.33 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 1025B        |   2,491.0 ns |    20.78 ns |    19.43 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 8KB          |  12,221.9 ns |    77.34 ns |    68.56 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 8KB          |  16,493.7 ns |    52.47 ns |    49.08 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 8KB          |  16,937.9 ns |    66.23 ns |    58.71 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 8KB          |  18,763.3 ns |    80.87 ns |    75.64 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 128KB        | 192,860.6 ns | 1,529.18 ns | 1,430.40 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 128KB        | 259,955.5 ns |   667.94 ns |   592.11 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 128KB        | 266,454.2 ns |   802.36 ns |   750.53 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128KB        | 296,993.8 ns | 2,138.99 ns | 2,000.81 ns |         - |