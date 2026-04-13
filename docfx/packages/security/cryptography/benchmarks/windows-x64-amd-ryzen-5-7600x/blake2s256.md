| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128B         |     157.0 ns |     0.85 ns |     0.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128B         |     158.0 ns |     1.53 ns |     1.43 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 128B         |     159.8 ns |     1.32 ns |     1.24 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 128B         |     160.2 ns |     0.74 ns |     0.69 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128B         |     162.5 ns |     0.99 ns |     0.93 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128B         |     163.8 ns |     2.77 ns |     2.59 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 137B         |     233.8 ns |     0.85 ns |     0.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 137B         |     236.4 ns |     1.50 ns |     1.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 137B         |     238.6 ns |     1.76 ns |     1.56 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 137B         |     239.4 ns |     4.80 ns |     5.90 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 137B         |     241.5 ns |     1.47 ns |     1.38 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 137B         |     243.8 ns |     3.80 ns |     3.55 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1KB          |   1,141.8 ns |     4.57 ns |     4.05 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1KB          |   1,213.6 ns |     6.10 ns |     5.70 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 1KB          |   1,216.6 ns |     8.65 ns |     7.67 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1KB          |   1,218.0 ns |    21.59 ns |    20.19 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 1KB          |   1,236.2 ns |     7.72 ns |     7.22 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1KB          |   1,243.1 ns |    10.28 ns |     9.11 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1025B        |   1,212.5 ns |     5.21 ns |     4.87 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1025B        |   1,293.0 ns |    24.29 ns |    23.86 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1025B        |   1,293.1 ns |     4.02 ns |     3.76 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 1025B        |   1,299.1 ns |     8.59 ns |     8.04 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1025B        |   1,309.9 ns |     2.87 ns |     2.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 1025B        |   1,321.1 ns |    11.18 ns |    10.46 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 8KB          |   9,035.6 ns |    72.49 ns |    67.81 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 8KB          |   9,661.3 ns |    65.41 ns |    61.18 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 8KB          |   9,670.0 ns |   156.54 ns |   138.77 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 8KB          |   9,689.1 ns |    53.23 ns |    49.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 8KB          |   9,737.8 ns |    90.75 ns |    84.89 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 8KB          |   9,883.6 ns |    70.53 ns |    62.52 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128KB        | 143,924.9 ns |   579.04 ns |   541.64 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128KB        | 153,604.6 ns | 1,720.20 ns | 1,524.91 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128KB        | 154,070.9 ns |   640.69 ns |   599.31 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128KB        | 154,800.2 ns | 1,174.45 ns | 1,098.58 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 128KB        | 155,750.5 ns |   925.71 ns |   865.91 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 128KB        | 157,817.8 ns | 1,178.39 ns | 1,044.62 ns |         - |