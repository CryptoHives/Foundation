| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-256 · Managed      | 128B         |     213.5 ns |     1.31 ns |     1.22 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 128B         |     282.0 ns |     1.53 ns |     1.35 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 128B         |     292.7 ns |     1.09 ns |     1.02 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128B         |     333.3 ns |     1.63 ns |     1.53 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 137B         |     453.1 ns |     2.80 ns |     2.62 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 137B         |     602.4 ns |     3.60 ns |     3.01 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 137B         |     620.8 ns |     2.61 ns |     2.32 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 137B         |     633.5 ns |     4.92 ns |     4.36 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 1KB          |   1,624.9 ns |    14.25 ns |    13.33 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 1KB          |   2,194.7 ns |     9.66 ns |     9.04 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 1KB          |   2,285.1 ns |    14.78 ns |    13.82 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 1KB          |   2,470.1 ns |    15.19 ns |    13.47 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 1025B        |   1,615.7 ns |     9.63 ns |     9.01 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 1025B        |   2,196.0 ns |    10.66 ns |     9.45 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 1025B        |   2,282.7 ns |    10.88 ns |     9.64 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 1025B        |   2,475.7 ns |    16.62 ns |    15.55 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 8KB          |  12,131.0 ns |    63.71 ns |    56.48 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 8KB          |  16,584.2 ns |    73.86 ns |    69.08 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 8KB          |  17,156.7 ns |    88.30 ns |    78.27 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 8KB          |  18,707.4 ns |   117.44 ns |   109.86 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 128KB        | 191,539.7 ns | 1,166.38 ns | 1,091.03 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 128KB        | 260,709.2 ns | 1,400.91 ns | 1,310.41 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 128KB        | 272,530.8 ns | 1,257.79 ns | 1,176.53 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128KB        | 295,694.9 ns | 1,786.60 ns | 1,671.19 ns |         - |