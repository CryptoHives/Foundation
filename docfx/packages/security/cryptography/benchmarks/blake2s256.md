| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 128B         |     192.1 ns |     2.50 ns |     2.34 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 128B         |     192.1 ns |     1.95 ns |     1.53 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 128B         |     196.8 ns |     3.80 ns |     3.55 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 128B         |     197.2 ns |     3.76 ns |     3.70 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 128B         |     638.6 ns |    12.52 ns |    12.29 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 137B         |     263.1 ns |     0.77 ns |     0.64 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 137B         |     273.1 ns |     5.47 ns |     5.11 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 137B         |     276.8 ns |     3.66 ns |     3.42 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 137B         |     284.9 ns |     5.59 ns |     5.49 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 137B         |     946.7 ns |    10.52 ns |     9.33 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 1KB          |   1,256.0 ns |     4.04 ns |     3.78 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 1KB          |   1,259.7 ns |     8.03 ns |     7.51 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 1KB          |   1,266.6 ns |     7.14 ns |     6.33 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 1KB          |   1,305.2 ns |    21.79 ns |    20.38 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 1KB          |   4,731.1 ns |    33.17 ns |    25.90 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 1025B        |   1,342.7 ns |     2.44 ns |     2.04 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 1025B        |   1,350.4 ns |    14.08 ns |    12.48 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 1025B        |   1,352.4 ns |    16.69 ns |    15.61 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 1025B        |   1,392.6 ns |    17.54 ns |    16.41 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 1025B        |   5,069.5 ns |    49.53 ns |    46.33 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 8KB          |   9,766.7 ns |    87.82 ns |    82.14 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 8KB          |   9,806.3 ns |    76.36 ns |    71.42 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 8KB          |   9,890.5 ns |   118.27 ns |   110.63 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 8KB          |  10,027.5 ns |    50.10 ns |    41.84 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 8KB          |  38,198.6 ns |   611.34 ns |   571.85 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 128KB        | 154,547.5 ns | 1,139.57 ns |   951.59 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 128KB        | 157,158.2 ns | 1,193.69 ns | 1,058.17 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 128KB        | 157,578.7 ns | 1,834.25 ns | 1,715.75 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 128KB        | 161,735.9 ns | 1,726.49 ns | 1,614.96 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 128KB        | 605,377.0 ns | 5,110.04 ns | 4,779.94 ns |     112 B |