| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · Managed      | 128B         |     427.2 ns |     1.25 ns |     1.11 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 128B         |     579.3 ns |     2.15 ns |     1.91 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 128B         |     596.4 ns |     1.72 ns |     1.53 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 128B         |     622.4 ns |     1.59 ns |     1.24 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 137B         |     423.5 ns |     1.15 ns |     0.96 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 137B         |     579.5 ns |     1.31 ns |     1.23 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 137B         |     592.1 ns |     1.38 ns |     1.29 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 137B         |     624.8 ns |     2.31 ns |     1.93 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 1KB          |   1,966.5 ns |    12.97 ns |    12.14 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 1KB          |   2,706.6 ns |     6.45 ns |     6.03 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 1KB          |   2,780.6 ns |     8.18 ns |     7.65 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 1KB          |   3,067.9 ns |    12.27 ns |    11.48 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 1025B        |   1,969.1 ns |     7.49 ns |     7.01 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 1025B        |   2,698.2 ns |     3.58 ns |     3.18 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 1025B        |   2,777.3 ns |     3.40 ns |     3.18 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 1025B        |   3,038.3 ns |     5.97 ns |     4.98 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 8KB          |  15,424.2 ns |    57.98 ns |    54.24 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 8KB          |  21,243.9 ns |    46.84 ns |    43.81 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 8KB          |  21,837.4 ns |    65.96 ns |    58.47 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 8KB          |  23,770.6 ns |    49.33 ns |    43.73 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 128KB        | 246,315.5 ns | 2,286.23 ns | 2,026.68 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 128KB        | 337,710.0 ns |   573.88 ns |   536.81 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 128KB        | 348,988.1 ns |   647.17 ns |   573.70 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 128KB        | 379,818.2 ns |   800.01 ns |   709.19 ns |         - |