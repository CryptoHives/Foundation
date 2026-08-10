| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (BouncyCastle) | 128B         |     188.8 ns |     0.38 ns |     0.34 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSSE3)        | 128B         |     189.3 ns |     0.48 ns |     0.42 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (AVX2)         | 128B         |     189.8 ns |     1.21 ns |     1.07 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSE2)         | 128B         |     194.2 ns |     0.79 ns |     0.74 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (Managed)      | 128B         |     625.1 ns |     3.07 ns |     2.87 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (BouncyCastle) | 137B         |     261.6 ns |     0.66 ns |     0.62 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (AVX2)         | 137B         |     267.5 ns |     0.98 ns |     0.87 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSSE3)        | 137B         |     271.5 ns |     0.56 ns |     0.47 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSE2)         | 137B         |     275.8 ns |     1.01 ns |     0.94 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (Managed)      | 137B         |     913.0 ns |     4.84 ns |     4.53 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (AVX2)         | 1KB          |   1,245.1 ns |     6.16 ns |     5.76 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSSE3)        | 1KB          |   1,251.9 ns |     3.29 ns |     3.08 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (BouncyCastle) | 1KB          |   1,260.6 ns |     5.69 ns |     5.32 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSE2)         | 1KB          |   1,283.9 ns |     1.92 ns |     1.70 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (Managed)      | 1KB          |   4,690.0 ns |    17.32 ns |    16.20 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (AVX2)         | 1025B        |   1,323.6 ns |     4.96 ns |     4.40 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSSE3)        | 1025B        |   1,332.8 ns |     2.92 ns |     2.73 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSE2)         | 1025B        |   1,363.0 ns |     3.23 ns |     2.86 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (BouncyCastle) | 1025B        |   1,363.3 ns |     5.98 ns |     5.59 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (Managed)      | 1025B        |   4,976.3 ns |    23.97 ns |    22.43 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (AVX2)         | 8KB          |   9,663.7 ns |    26.07 ns |    21.77 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (BouncyCastle) | 8KB          |   9,714.6 ns |    47.93 ns |    42.49 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSSE3)        | 8KB          |   9,742.4 ns |    22.32 ns |    20.88 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSE2)         | 8KB          |   9,977.1 ns |    31.96 ns |    29.90 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (Managed)      | 8KB          |  37,396.1 ns |   106.53 ns |    99.65 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (AVX2)         | 128KB        | 154,811.1 ns |   747.23 ns |   698.96 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (BouncyCastle) | 128KB        | 154,888.6 ns |   611.93 ns |   572.40 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSSE3)        | 128KB        | 155,336.6 ns |   283.70 ns |   265.37 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (SSE2)         | 128KB        | 159,032.3 ns |   303.32 ns |   283.72 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BLAKE2s-256 (Managed)      | 128KB        | 595,401.3 ns | 3,979.41 ns | 3,722.34 ns |     112 B |