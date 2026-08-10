| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 128B         |     185.2 ns |     0.33 ns |     0.29 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 128B         |     188.2 ns |     0.52 ns |     0.49 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 128B         |     189.1 ns |     0.88 ns |     0.78 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 128B         |     190.0 ns |     0.70 ns |     0.65 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 128B         |     617.7 ns |     2.14 ns |     2.01 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 137B         |     259.0 ns |     0.89 ns |     0.84 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 137B         |     266.6 ns |     1.58 ns |     1.40 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 137B         |     273.5 ns |     0.35 ns |     0.31 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 137B         |     274.0 ns |     1.19 ns |     1.05 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 137B         |     907.7 ns |     3.20 ns |     2.99 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 1KB          |   1,240.3 ns |     2.56 ns |     2.14 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 1KB          |   1,249.9 ns |     2.77 ns |     2.59 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 1KB          |   1,262.1 ns |     4.24 ns |     3.54 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 1KB          |   1,277.6 ns |     3.70 ns |     3.28 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 1KB          |   4,687.2 ns |    10.66 ns |     8.90 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 1025B        |   1,322.1 ns |     4.17 ns |     3.70 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 1025B        |   1,332.4 ns |     2.71 ns |     2.41 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 1025B        |   1,339.4 ns |     5.88 ns |     4.59 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 1025B        |   1,362.2 ns |     3.89 ns |     3.64 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 1025B        |   4,978.9 ns |    21.45 ns |    20.06 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 8KB          |   9,706.4 ns |    35.15 ns |    29.35 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 8KB          |   9,706.6 ns |    41.63 ns |    38.94 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 8KB          |   9,740.7 ns |    24.91 ns |    20.80 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 8KB          |   9,970.2 ns |    18.40 ns |    17.21 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 8KB          |  37,202.3 ns |   148.88 ns |   131.98 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 128KB        | 154,876.1 ns |   629.93 ns |   526.02 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 128KB        | 155,219.3 ns |   384.45 ns |   359.61 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 128KB        | 155,625.9 ns |   766.55 ns |   679.52 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 128KB        | 159,011.4 ns |   473.53 ns |   419.77 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 128KB        | 593,407.0 ns | 2,079.24 ns | 1,944.92 ns |      80 B |