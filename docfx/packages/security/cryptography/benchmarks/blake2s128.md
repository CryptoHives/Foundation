| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 128B         |     186.6 ns |     0.46 ns |     0.43 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 128B         |     187.7 ns |     0.70 ns |     0.62 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 128B         |     187.9 ns |     0.64 ns |     0.60 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 128B         |     192.8 ns |     0.37 ns |     0.35 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 128B         |     620.9 ns |     2.90 ns |     2.71 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 137B         |     259.5 ns |     0.70 ns |     0.66 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 137B         |     265.5 ns |     1.15 ns |     1.02 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 137B         |     272.1 ns |     0.83 ns |     0.74 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 137B         |     274.5 ns |     1.06 ns |     0.99 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 137B         |     908.8 ns |     4.08 ns |     3.19 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 1KB          |   1,246.1 ns |     5.93 ns |     5.55 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 1KB          |   1,251.2 ns |     3.33 ns |     2.96 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 1KB          |   1,259.1 ns |     4.91 ns |     4.59 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 1KB          |   1,277.8 ns |     3.55 ns |     3.32 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 1KB          |   4,691.7 ns |    19.41 ns |    17.20 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 1025B        |   1,322.6 ns |     5.20 ns |     4.86 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 1025B        |   1,328.2 ns |     4.24 ns |     3.96 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 1025B        |   1,333.0 ns |     1.76 ns |     1.47 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 1025B        |   1,359.8 ns |     1.52 ns |     1.35 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 1025B        |   4,972.3 ns |    16.37 ns |    13.67 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 8KB          |   9,691.1 ns |    36.64 ns |    34.28 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 8KB          |   9,699.6 ns |    36.94 ns |    34.55 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 8KB          |   9,742.5 ns |    31.84 ns |    28.22 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 8KB          |   9,981.8 ns |    16.76 ns |    14.86 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 8KB          |  37,134.6 ns |   169.58 ns |   141.61 ns |      80 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 128KB        | 154,764.1 ns |   760.03 ns |   634.66 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 128KB        | 154,915.1 ns |   768.17 ns |   718.55 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 128KB        | 155,451.8 ns |   353.70 ns |   330.85 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 128KB        | 167,296.3 ns |   625.97 ns |   585.53 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 128KB        | 593,459.9 ns | 1,839.67 ns | 1,720.83 ns |      80 B |