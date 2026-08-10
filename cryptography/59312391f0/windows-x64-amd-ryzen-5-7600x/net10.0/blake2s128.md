| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (BouncyCastle) | 128B         |     184.6 ns |     0.32 ns |     0.29 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSSE3)        | 128B         |     187.1 ns |     0.36 ns |     0.34 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (AVX2)         | 128B         |     188.1 ns |     0.51 ns |     0.45 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSE2)         | 128B         |     190.2 ns |     0.69 ns |     0.65 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (Managed)      | 128B         |     623.3 ns |     1.93 ns |     1.71 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (BouncyCastle) | 137B         |     259.4 ns |     0.61 ns |     0.57 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (AVX2)         | 137B         |     265.7 ns |     0.94 ns |     0.79 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSSE3)        | 137B         |     271.2 ns |     1.10 ns |     0.98 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSE2)         | 137B         |     273.9 ns |     0.66 ns |     0.58 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (Managed)      | 137B         |     909.4 ns |     4.98 ns |     4.66 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (AVX2)         | 1KB          |   1,245.8 ns |     6.82 ns |     6.05 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSSE3)        | 1KB          |   1,247.8 ns |     2.10 ns |     1.96 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (BouncyCastle) | 1KB          |   1,260.9 ns |     5.46 ns |     4.56 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSE2)         | 1KB          |   1,279.8 ns |     2.92 ns |     2.59 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (Managed)      | 1KB          |   4,688.4 ns |    12.38 ns |    11.58 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (AVX2)         | 1025B        |   1,320.0 ns |     3.12 ns |     2.92 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (BouncyCastle) | 1025B        |   1,333.1 ns |     3.92 ns |     3.48 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSSE3)        | 1025B        |   1,333.4 ns |     3.07 ns |     2.88 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSE2)         | 1025B        |   1,364.4 ns |     2.67 ns |     2.50 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (Managed)      | 1025B        |   4,983.5 ns |    29.57 ns |    27.66 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (AVX2)         | 8KB          |   9,687.6 ns |    56.66 ns |    53.00 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (BouncyCastle) | 8KB          |   9,729.1 ns |    37.89 ns |    35.45 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSSE3)        | 8KB          |   9,749.5 ns |    22.60 ns |    21.14 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSE2)         | 8KB          |   9,983.9 ns |    20.74 ns |    18.39 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (Managed)      | 8KB          |  37,155.8 ns |   175.57 ns |   164.23 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (BouncyCastle) | 128KB        | 154,524.3 ns |   366.88 ns |   325.23 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (AVX2)         | 128KB        | 154,595.6 ns |   617.45 ns |   547.35 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSSE3)        | 128KB        | 155,417.4 ns |   427.00 ns |   378.52 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (SSE2)         | 128KB        | 158,906.9 ns |   265.88 ns |   235.69 ns |      80 B |
| ComputeHash | BLAKE2s-128 | BLAKE2s-128 (Managed)      | 128KB        | 595,930.8 ns | 2,135.31 ns | 1,997.37 ns |      80 B |