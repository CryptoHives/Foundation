| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · Managed      | 128B         |     407.2 ns |     2.00 ns |     1.87 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 128B         |     557.8 ns |     1.28 ns |     1.07 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 128B         |     578.5 ns |     1.17 ns |     1.09 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 128B         |     623.1 ns |     3.62 ns |     3.38 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 137B         |     400.4 ns |     1.51 ns |     1.34 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 137B         |     547.9 ns |     2.74 ns |     2.29 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 137B         |     560.5 ns |     1.21 ns |     1.13 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 137B         |     623.0 ns |     2.13 ns |     1.78 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 1KB          |   2,937.7 ns |    10.70 ns |    10.01 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 1KB          |   4,023.0 ns |     8.55 ns |     8.00 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 1KB          |   4,152.0 ns |     7.25 ns |     5.66 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 1KB          |   4,498.2 ns |    17.91 ns |    15.88 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 1025B        |   2,939.5 ns |    10.52 ns |     9.33 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 1025B        |   4,033.4 ns |    10.35 ns |     9.68 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 1025B        |   4,153.4 ns |     7.77 ns |     7.27 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 1025B        |   4,494.8 ns |    13.88 ns |    11.59 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 8KB          |  22,062.7 ns |    75.81 ns |    67.20 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 8KB          |  30,350.5 ns |    66.48 ns |    55.51 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 8KB          |  31,273.0 ns |    51.39 ns |    48.07 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 8KB          |  34,214.6 ns |   120.30 ns |   112.53 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 128KB        | 352,953.2 ns | 1,994.76 ns | 1,865.90 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 128KB        | 484,018.5 ns | 1,079.69 ns | 1,009.94 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 128KB        | 499,250.8 ns | 1,355.89 ns | 1,268.30 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 128KB        | 545,445.9 ns | 2,698.10 ns | 2,523.81 ns |         - |