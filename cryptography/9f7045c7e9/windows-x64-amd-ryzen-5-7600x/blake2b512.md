| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 128B         |     130.0 ns |     0.56 ns |     0.50 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 128B         |     135.9 ns |     0.69 ns |     0.54 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 128B         |     400.8 ns |     0.97 ns |     0.86 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 137B         |     209.1 ns |     0.55 ns |     0.49 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 137B         |     232.1 ns |     0.55 ns |     0.52 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 137B         |     749.5 ns |     2.81 ns |     2.63 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 1KB          |     748.5 ns |     5.52 ns |     4.61 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 1KB          |     814.0 ns |     2.31 ns |     2.16 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 1KB          |   2,859.3 ns |    11.13 ns |    10.41 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 1025B        |     833.9 ns |     2.06 ns |     1.83 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 1025B        |     918.1 ns |     1.95 ns |     1.82 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 1025B        |   3,229.9 ns |    16.71 ns |    15.63 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 8KB          |   5,631.0 ns |    19.24 ns |    18.00 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 8KB          |   6,291.8 ns |    33.77 ns |    28.20 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 8KB          |  22,625.1 ns |    79.06 ns |    70.09 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 128KB        |  89,024.8 ns |   269.60 ns |   210.49 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 128KB        | 100,577.4 ns |   885.76 ns |   785.20 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 128KB        | 369,019.0 ns | 2,771.83 ns | 2,592.77 ns |     176 B |