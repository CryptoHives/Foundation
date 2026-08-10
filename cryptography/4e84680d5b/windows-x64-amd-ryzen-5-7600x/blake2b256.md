| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 128B         |     127.2 ns |     0.72 ns |     0.64 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 128B         |     139.4 ns |     0.88 ns |     0.78 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 128B         |     396.2 ns |     2.63 ns |     2.46 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 137B         |     224.8 ns |     1.08 ns |     0.96 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 137B         |     241.7 ns |     1.69 ns |     1.58 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 137B         |     746.4 ns |     8.33 ns |     7.80 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 1KB          |     743.7 ns |     3.50 ns |     2.92 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 1KB          |     874.6 ns |    13.94 ns |    13.04 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 1KB          |   2,867.4 ns |    26.55 ns |    24.83 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 1025B        |     831.2 ns |     5.93 ns |     4.95 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 1025B        |     985.5 ns |    16.09 ns |    15.05 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 1025B        |   3,266.3 ns |    24.76 ns |    21.95 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 8KB          |   5,672.9 ns |    40.11 ns |    35.56 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 8KB          |   6,993.9 ns |    22.86 ns |    21.39 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 8KB          |  22,639.6 ns |   198.96 ns |   186.11 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 128KB        |  88,963.3 ns |   496.03 ns |   463.99 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 128KB        | 111,855.9 ns |   558.15 ns |   522.10 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 128KB        | 363,069.1 ns | 3,679.32 ns | 3,441.63 ns |     112 B |