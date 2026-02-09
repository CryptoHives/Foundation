| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-256 · Managed      | 128B         |     209.6 ns |     0.47 ns |     0.41 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 128B         |     280.6 ns |     0.63 ns |     0.59 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 128B         |     291.3 ns |     0.91 ns |     0.85 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128B         |     330.6 ns |     1.21 ns |     1.01 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 137B         |     450.5 ns |     1.77 ns |     1.65 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 137B         |     599.2 ns |     2.09 ns |     1.95 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 137B         |     618.0 ns |     1.62 ns |     1.44 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 137B         |     627.8 ns |     2.70 ns |     2.52 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 1KB          |   1,603.2 ns |     3.09 ns |     2.58 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 1KB          |   2,187.7 ns |     6.83 ns |     6.39 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 1KB          |   2,280.9 ns |     6.47 ns |     6.05 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 1KB          |   2,452.6 ns |     7.81 ns |     7.31 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 1025B        |   1,603.6 ns |     9.09 ns |     8.51 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 1025B        |   2,188.2 ns |     6.32 ns |     5.91 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 1025B        |   2,275.6 ns |     5.25 ns |     4.91 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 1025B        |   2,456.8 ns |     9.22 ns |     8.17 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 8KB          |  12,068.1 ns |    29.65 ns |    24.76 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 8KB          |  16,474.6 ns |    43.59 ns |    38.64 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 8KB          |  17,112.5 ns |    35.77 ns |    29.87 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 8KB          |  18,558.5 ns |    56.69 ns |    50.26 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 128KB        | 189,304.2 ns |   471.95 ns |   368.47 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 128KB        | 260,115.2 ns |   716.76 ns |   635.39 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 128KB        | 270,612.5 ns | 1,132.29 ns | 1,059.14 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128KB        | 292,417.8 ns |   931.83 ns |   778.12 ns |         - |