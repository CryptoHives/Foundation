| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128B         |     156.7 ns |     1.16 ns |     1.03 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128B         |     157.4 ns |     1.08 ns |     1.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 128B         |     159.2 ns |     0.92 ns |     0.86 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 128B         |     159.5 ns |     1.62 ns |     1.51 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128B         |     159.6 ns |     1.29 ns |     1.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128B         |     162.5 ns |     2.97 ns |     2.78 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 137B         |     229.0 ns |     1.01 ns |     0.89 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 137B         |     236.4 ns |     1.25 ns |     1.17 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 137B         |     237.9 ns |     2.56 ns |     2.40 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 137B         |     239.8 ns |     1.71 ns |     1.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 137B         |     240.7 ns |     1.03 ns |     0.92 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 137B         |     243.8 ns |     2.11 ns |     1.97 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1KB          |   1,138.0 ns |     5.07 ns |     4.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1KB          |   1,216.1 ns |    22.90 ns |    23.52 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1KB          |   1,219.0 ns |     5.37 ns |     5.02 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 1KB          |   1,220.2 ns |     4.58 ns |     4.06 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1KB          |   1,230.3 ns |     4.23 ns |     3.75 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 1KB          |   1,243.1 ns |     9.69 ns |     9.06 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1025B        |   1,212.1 ns |     5.59 ns |     5.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1025B        |   1,293.3 ns |    23.63 ns |    25.29 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1025B        |   1,294.4 ns |     7.20 ns |     6.74 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 1025B        |   1,302.1 ns |     8.93 ns |     7.92 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1025B        |   1,307.7 ns |     6.62 ns |     6.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 1025B        |   1,325.9 ns |     7.34 ns |     6.87 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 8KB          |   9,003.1 ns |    26.71 ns |    22.31 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 8KB          |   9,680.6 ns |   190.03 ns |   203.33 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 8KB          |   9,715.3 ns |    71.32 ns |    63.22 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 8KB          |   9,738.5 ns |    57.04 ns |    53.35 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 8KB          |   9,740.8 ns |    48.03 ns |    44.93 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 8KB          |   9,884.5 ns |    51.24 ns |    47.93 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128KB        | 143,827.0 ns |   553.69 ns |   462.36 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128KB        | 153,394.7 ns | 2,383.20 ns | 2,229.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128KB        | 154,605.9 ns | 1,004.92 ns |   890.84 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128KB        | 154,611.6 ns |   383.71 ns |   320.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 128KB        | 156,049.9 ns |   981.13 ns |   917.75 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 128KB        | 158,754.2 ns | 1,311.94 ns | 1,227.19 ns |         - |