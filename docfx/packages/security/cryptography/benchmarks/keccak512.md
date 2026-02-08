| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · Managed      | 128B         |     406.4 ns |     2.48 ns |     2.32 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 128B         |     552.2 ns |     1.86 ns |     1.55 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 128B         |     571.5 ns |     3.93 ns |     3.28 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 128B         |     627.5 ns |     3.43 ns |     3.21 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 137B         |     402.7 ns |     2.12 ns |     1.98 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 137B         |     547.9 ns |     1.95 ns |     1.82 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 137B         |     565.3 ns |     2.31 ns |     2.05 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 137B         |     624.7 ns |     1.71 ns |     1.51 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 1KB          |   2,948.8 ns |    10.55 ns |     9.87 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 1KB          |   4,085.2 ns |    15.22 ns |    14.23 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 1KB          |   4,173.2 ns |     9.73 ns |     8.62 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 1KB          |   4,544.3 ns |    21.30 ns |    19.92 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 1025B        |   2,955.5 ns |    17.80 ns |    16.65 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 1025B        |   4,069.9 ns |    19.67 ns |    17.44 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 1025B        |   4,188.4 ns |    17.53 ns |    16.40 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 1025B        |   4,650.5 ns |    18.33 ns |    17.14 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 8KB          |  22,229.7 ns |    76.58 ns |    67.89 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 8KB          |  30,721.5 ns |    81.37 ns |    72.13 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 8KB          |  31,494.8 ns |   128.92 ns |   120.59 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 8KB          |  34,352.5 ns |   179.65 ns |   159.26 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 128KB        | 356,747.8 ns | 2,437.57 ns | 2,160.84 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 128KB        | 490,205.2 ns |   846.67 ns |   750.55 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 128KB        | 502,474.1 ns | 1,659.39 ns | 1,552.19 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 128KB        | 549,974.8 ns | 2,689.78 ns | 2,516.03 ns |         - |