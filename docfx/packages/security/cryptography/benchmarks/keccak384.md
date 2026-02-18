| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · Managed      | 128B         |     437.3 ns |     2.76 ns |     2.58 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 128B         |     586.9 ns |     1.48 ns |     1.39 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 128B         |     607.4 ns |     1.44 ns |     1.20 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 128B         |     623.6 ns |     4.38 ns |     4.10 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 137B         |     435.5 ns |     1.82 ns |     1.70 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 137B         |     584.1 ns |     1.46 ns |     1.29 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 137B         |     603.1 ns |     1.45 ns |     1.35 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 137B         |     624.4 ns |     4.46 ns |     4.18 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 1KB          |   1,973.0 ns |    11.79 ns |    10.46 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 1KB          |   2,704.9 ns |     5.92 ns |     5.54 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 1KB          |   2,781.8 ns |     5.02 ns |     4.19 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 1KB          |   3,041.5 ns |     9.73 ns |     8.63 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 1025B        |   1,971.5 ns |    17.73 ns |    16.59 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 1025B        |   2,695.8 ns |     4.47 ns |     3.97 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 1025B        |   2,790.1 ns |    11.88 ns |    10.53 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 1025B        |   3,042.1 ns |    17.61 ns |    16.48 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 8KB          |  15,399.7 ns |    66.96 ns |    59.36 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 8KB          |  21,194.1 ns |    36.02 ns |    33.70 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 8KB          |  21,797.6 ns |    44.02 ns |    39.03 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 8KB          |  23,814.0 ns |    63.91 ns |    56.65 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 128KB        | 245,553.5 ns | 1,417.93 ns | 1,256.96 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 128KB        | 336,844.7 ns | 1,001.68 ns |   887.96 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 128KB        | 347,933.4 ns |   944.25 ns |   837.06 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 128KB        | 381,363.7 ns | 2,875.67 ns | 2,401.32 ns |         - |