| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 128B         |     128.8 ns |     1.73 ns |     1.62 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 128B         |     133.5 ns |     1.63 ns |     1.36 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 128B         |     396.4 ns |     3.47 ns |     3.25 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 137B         |     208.9 ns |     1.11 ns |     1.04 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 137B         |     229.9 ns |     1.08 ns |     0.90 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 137B         |     753.0 ns |     6.73 ns |     5.97 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 1KB          |     749.5 ns |     5.83 ns |     4.87 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 1KB          |     811.7 ns |     4.60 ns |     4.08 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 1KB          |   2,892.6 ns |    35.57 ns |    33.27 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 1025B        |     832.0 ns |     4.32 ns |     3.61 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 1025B        |     916.6 ns |     3.88 ns |     3.63 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 1025B        |   3,216.2 ns |    21.30 ns |    19.93 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 8KB          |   5,649.2 ns |    43.15 ns |    36.04 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 8KB          |   6,315.6 ns |   104.67 ns |    92.78 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 8KB          |  22,644.1 ns |   175.44 ns |   164.11 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 128KB        |  89,413.9 ns |   697.46 ns |   582.41 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 128KB        | 101,177.3 ns | 1,850.39 ns | 1,730.86 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 128KB        | 362,582.3 ns | 3,052.03 ns | 2,854.88 ns |     112 B |