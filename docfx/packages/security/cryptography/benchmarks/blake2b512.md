| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 128B         |     104.1 ns |     0.83 ns |     0.70 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 128B         |     115.2 ns |     2.15 ns |     2.01 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 128B         |     388.4 ns |     7.31 ns |     7.51 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 137B         |     187.1 ns |     2.52 ns |     2.24 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 137B         |     216.5 ns |     3.51 ns |     3.28 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 137B         |     769.4 ns |    14.49 ns |    14.88 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 1KB          |     730.0 ns |    11.17 ns |     9.33 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 1KB          |     812.2 ns |    16.00 ns |    15.71 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 1KB          |   2,969.3 ns |    57.82 ns |    84.75 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 1025B        |     817.8 ns |    12.86 ns |    11.40 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 1025B        |     922.5 ns |    18.43 ns |    19.72 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 1025B        |   3,328.3 ns |    65.29 ns |    75.18 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 8KB          |   5,732.6 ns |   111.27 ns |   152.31 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 8KB          |   6,594.9 ns |   128.86 ns |   225.68 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 8KB          |  23,429.6 ns |   467.33 ns |   479.92 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 128KB        |  90,885.1 ns | 1,378.22 ns | 1,289.19 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 128KB        | 103,157.8 ns | 2,054.01 ns | 2,109.32 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 128KB        | 373,447.5 ns | 6,099.27 ns | 5,093.17 ns |         - |