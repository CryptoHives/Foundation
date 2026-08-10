| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 128B         |     188.2 ns |     0.47 ns |     0.44 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 128B         |     188.9 ns |     1.16 ns |     1.03 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 128B         |     190.1 ns |     0.41 ns |     0.37 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 128B         |     193.8 ns |     0.99 ns |     0.88 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 128B         |     618.8 ns |     1.83 ns |     1.71 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 137B         |     262.1 ns |     0.45 ns |     0.42 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 137B         |     267.8 ns |     1.04 ns |     0.97 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 137B         |     272.7 ns |     0.57 ns |     0.53 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 137B         |     275.6 ns |     1.02 ns |     0.90 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 137B         |     911.3 ns |     2.55 ns |     2.26 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 1KB          |   1,243.9 ns |     3.83 ns |     3.59 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 1KB          |   1,251.8 ns |     1.92 ns |     1.60 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 1KB          |   1,260.8 ns |     6.31 ns |     4.93 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 1KB          |   1,281.7 ns |     4.90 ns |     4.34 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 1KB          |   4,682.3 ns |    19.48 ns |    18.22 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 1025B        |   1,322.4 ns |     4.82 ns |     4.27 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 1025B        |   1,333.9 ns |     2.22 ns |     1.97 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 1025B        |   1,336.2 ns |     4.35 ns |     3.63 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 1025B        |   1,365.6 ns |     3.03 ns |     2.83 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 1025B        |   4,969.2 ns |    18.61 ns |    16.50 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 8KB          |   9,680.2 ns |    43.33 ns |    38.41 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 8KB          |   9,721.8 ns |    20.89 ns |    18.52 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 8KB          |   9,741.9 ns |    19.80 ns |    17.55 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 8KB          |   9,979.4 ns |    18.39 ns |    17.20 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 8KB          |  37,197.1 ns |   109.71 ns |   102.63 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 128KB        | 154,473.3 ns |   426.17 ns |   355.87 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 128KB        | 154,507.9 ns |   437.25 ns |   409.00 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 128KB        | 155,312.1 ns |   263.31 ns |   246.30 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 128KB        | 158,827.5 ns |   520.73 ns |   487.10 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 128KB        | 594,329.1 ns | 1,830.37 ns | 1,622.58 ns |     112 B |