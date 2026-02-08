| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128B         |     160.6 ns |     2.32 ns |     2.17 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128B         |     161.4 ns |     0.52 ns |     0.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128B         |     164.6 ns |     0.44 ns |     0.41 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128B         |     166.2 ns |     0.40 ns |     0.38 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128B         |     594.5 ns |     1.91 ns |     1.69 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 137B         |     240.9 ns |     1.09 ns |     1.02 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 137B         |     243.3 ns |     2.50 ns |     2.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 137B         |     246.7 ns |     0.36 ns |     0.32 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 137B         |     254.0 ns |     0.65 ns |     0.57 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 137B         |     883.6 ns |     4.34 ns |     4.06 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1KB          |   1,217.7 ns |     3.26 ns |     2.89 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1KB          |   1,227.3 ns |     2.07 ns |     1.93 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1KB          |   1,229.4 ns |     3.90 ns |     3.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1KB          |   1,268.0 ns |     2.23 ns |     1.98 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1KB          |   4,650.4 ns |    12.48 ns |    11.06 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1025B        |   1,298.7 ns |     4.70 ns |     4.17 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1025B        |   1,307.8 ns |     2.87 ns |     2.68 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1025B        |   1,314.9 ns |     1.51 ns |     1.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1025B        |   1,340.4 ns |     1.64 ns |     1.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1025B        |   4,943.6 ns |    17.54 ns |    16.40 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 8KB          |   9,653.4 ns |    48.15 ns |    42.68 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 8KB          |   9,700.7 ns |    42.08 ns |    39.36 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 8KB          |   9,731.2 ns |    13.30 ns |    11.11 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 8KB          |   9,962.7 ns |    20.22 ns |    17.93 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 8KB          |  37,147.1 ns |   126.50 ns |   118.32 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128KB        | 154,169.6 ns |   366.26 ns |   324.68 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128KB        | 155,613.4 ns |   200.93 ns |   167.79 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128KB        | 159,270.8 ns |   280.93 ns |   234.59 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128KB        | 162,055.8 ns |   598.35 ns |   559.70 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128KB        | 595,243.1 ns | 2,102.28 ns | 1,966.48 ns |         - |