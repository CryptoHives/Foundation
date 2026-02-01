| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 128B         |     188.3 ns |     0.47 ns |     0.44 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 128B         |     188.6 ns |     0.58 ns |     0.54 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 128B         |     190.7 ns |     0.77 ns |     0.69 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 128B         |     191.8 ns |     0.72 ns |     0.64 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 128B         |     649.2 ns |     3.87 ns |     3.23 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 137B         |     261.6 ns |     0.69 ns |     0.65 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 137B         |     268.7 ns |     1.05 ns |     0.98 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 137B         |     272.0 ns |     1.71 ns |     1.60 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 137B         |     275.6 ns |     0.72 ns |     0.68 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 137B         |     913.6 ns |     3.35 ns |     2.97 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 1KB          |   1,248.9 ns |     4.89 ns |     4.57 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 1KB          |   1,249.9 ns |     2.99 ns |     2.79 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 1KB          |   1,261.8 ns |     3.24 ns |     2.87 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 1KB          |   1,280.6 ns |     3.28 ns |     3.07 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 1KB          |   4,671.9 ns |    14.82 ns |    11.57 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 1025B        |   1,327.4 ns |    10.10 ns |     9.45 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 1025B        |   1,335.1 ns |     4.04 ns |     3.58 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 1025B        |   1,336.9 ns |     1.44 ns |     1.35 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 1025B        |   1,366.5 ns |     3.03 ns |     2.69 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 1025B        |   4,965.8 ns |    19.03 ns |    16.87 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 8KB          |   9,679.2 ns |    29.05 ns |    25.76 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 8KB          |   9,701.1 ns |    14.75 ns |    12.32 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 8KB          |   9,749.2 ns |    17.14 ns |    16.03 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 8KB          |   9,970.5 ns |    22.32 ns |    19.78 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 8KB          |  37,114.9 ns |   127.73 ns |   119.47 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 128KB        | 154,305.1 ns |   455.48 ns |   403.77 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 128KB        | 154,821.9 ns |   837.42 ns |   783.32 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 128KB        | 155,363.3 ns |   439.38 ns |   389.50 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 128KB        | 158,899.9 ns |   443.26 ns |   414.62 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 128KB        | 594,460.2 ns | 2,672.09 ns | 2,086.19 ns |     112 B |