| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 128B         |     101.2 ns |     0.40 ns |     0.37 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 128B         |     121.2 ns |     0.98 ns |     0.92 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 128B         |     378.8 ns |     2.76 ns |     2.58 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 137B         |     184.2 ns |     2.19 ns |     2.05 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 137B         |     216.9 ns |     1.76 ns |     1.65 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 137B         |     741.3 ns |    14.10 ns |    13.19 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 1KB          |     715.2 ns |     2.15 ns |     2.01 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 1KB          |     818.0 ns |    15.79 ns |    22.13 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 1KB          |   2,909.2 ns |    53.10 ns |    44.34 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 1025B        |     800.7 ns |     1.90 ns |     1.69 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 1025B        |     897.4 ns |     6.00 ns |     5.01 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 1025B        |   3,223.0 ns |    41.31 ns |    36.62 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 8KB          |   5,645.8 ns |    93.75 ns |    87.70 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 8KB          |   6,400.6 ns |   124.77 ns |   170.79 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 8KB          |  22,623.6 ns |   148.15 ns |   138.58 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 128KB        |  92,037.9 ns | 1,794.39 ns | 3,095.24 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 128KB        | 101,625.6 ns | 1,342.75 ns | 1,190.31 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 128KB        | 366,554.2 ns | 4,273.47 ns | 3,568.54 ns |         - |