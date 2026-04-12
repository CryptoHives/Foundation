| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · Managed      | 128B         |     442.6 ns |     2.73 ns |     2.55 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 128B         |     588.2 ns |     1.80 ns |     1.69 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 128B         |     608.0 ns |     2.19 ns |     2.05 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 128B         |     631.3 ns |     4.65 ns |     4.35 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 137B         |     439.6 ns |     3.12 ns |     2.92 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 137B         |     585.0 ns |     1.35 ns |     1.20 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 137B         |     603.1 ns |     2.00 ns |     1.77 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 137B         |     633.0 ns |     3.29 ns |     3.08 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 1KB          |   1,996.7 ns |     9.25 ns |     7.72 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 1KB          |   2,717.7 ns |     8.91 ns |     7.90 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 1KB          |   2,788.3 ns |     6.08 ns |     5.69 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 1KB          |   3,093.4 ns |    17.50 ns |    16.37 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 1025B        |   1,997.4 ns |    17.70 ns |    16.55 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 1025B        |   2,711.9 ns |     5.98 ns |     5.30 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 1025B        |   2,792.6 ns |     9.93 ns |     9.29 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 1025B        |   3,073.5 ns |    12.25 ns |    10.86 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 8KB          |  15,663.1 ns |   154.43 ns |   144.45 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 8KB          |  21,233.2 ns |    58.27 ns |    51.66 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 8KB          |  21,798.1 ns |    61.26 ns |    57.30 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 8KB          |  24,122.7 ns |   126.21 ns |   118.06 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · Managed      | 128KB        | 249,539.3 ns | 1,864.45 ns | 1,744.01 ns |         - |
| TryComputeHash · Keccak-384 · AVX2         | 128KB        | 339,100.9 ns |   715.32 ns |   669.11 ns |         - |
| TryComputeHash · Keccak-384 · AVX512F      | 128KB        | 347,450.1 ns |   695.03 ns |   580.38 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle | 128KB        | 384,284.9 ns | 1,949.17 ns | 1,823.25 ns |         - |