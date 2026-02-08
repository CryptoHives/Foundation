| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128B         |     161.4 ns |     0.39 ns |     0.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128B         |     163.2 ns |     0.69 ns |     0.61 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128B         |     164.0 ns |     0.65 ns |     0.61 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128B         |     166.5 ns |     0.35 ns |     0.31 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128B         |     599.0 ns |     2.02 ns |     1.79 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 137B         |     246.0 ns |     0.96 ns |     0.90 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 137B         |     247.7 ns |     0.69 ns |     0.65 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 137B         |     253.0 ns |     0.90 ns |     0.84 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 137B         |     254.0 ns |     0.60 ns |     0.54 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 137B         |     887.6 ns |     2.16 ns |     2.02 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1KB          |   1,220.8 ns |     7.84 ns |     7.34 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1KB          |   1,227.1 ns |     3.16 ns |     2.95 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1KB          |   1,240.1 ns |     2.89 ns |     2.70 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1KB          |   1,276.9 ns |     2.44 ns |     2.28 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1KB          |   4,653.5 ns |    12.70 ns |    11.26 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1025B        |   1,300.5 ns |     5.58 ns |     5.22 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1025B        |   1,311.7 ns |     3.16 ns |     2.96 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1025B        |   1,313.2 ns |     3.23 ns |     2.70 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1025B        |   1,340.8 ns |     3.27 ns |     2.90 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1025B        |   5,182.4 ns |     6.69 ns |     5.93 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 8KB          |   9,664.3 ns |    37.70 ns |    33.42 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 8KB          |   9,676.9 ns |    38.32 ns |    32.00 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 8KB          |   9,731.0 ns |    24.88 ns |    23.28 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 8KB          |   9,981.2 ns |    23.34 ns |    20.69 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 8KB          |  36,999.3 ns |    64.77 ns |    57.42 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128KB        | 153,967.9 ns |   450.87 ns |   399.68 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128KB        | 154,466.4 ns |   820.32 ns |   767.33 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128KB        | 155,314.0 ns |   249.64 ns |   221.30 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128KB        | 159,053.3 ns |   400.55 ns |   355.08 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128KB        | 597,979.1 ns | 2,557.78 ns | 2,392.55 ns |         - |