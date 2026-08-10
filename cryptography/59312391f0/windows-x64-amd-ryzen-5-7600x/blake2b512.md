| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (BouncyCastle) | 128B         |     130.3 ns |     1.02 ns |     0.85 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (AVX2)         | 128B         |     142.3 ns |     1.16 ns |     1.02 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (Managed)      | 128B         |     398.9 ns |     3.07 ns |     2.87 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (BouncyCastle) | 137B         |     209.8 ns |     0.64 ns |     0.60 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (AVX2)         | 137B         |     245.4 ns |     1.07 ns |     1.00 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (Managed)      | 137B         |     759.8 ns |     5.68 ns |     5.04 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (BouncyCastle) | 1KB          |     749.6 ns |     2.33 ns |     1.95 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (AVX2)         | 1KB          |     862.7 ns |     3.42 ns |     3.03 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (Managed)      | 1KB          |   2,875.6 ns |    12.88 ns |    12.05 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (BouncyCastle) | 1025B        |     835.0 ns |     2.76 ns |     2.30 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (AVX2)         | 1025B        |     976.8 ns |     6.70 ns |     5.94 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (Managed)      | 1025B        |   3,224.0 ns |    14.05 ns |    13.15 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (BouncyCastle) | 8KB          |   5,626.2 ns |    20.42 ns |    17.05 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (AVX2)         | 8KB          |   7,003.2 ns |    28.95 ns |    27.08 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (Managed)      | 8KB          |  22,560.7 ns |    86.69 ns |    81.09 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (BouncyCastle) | 128KB        |  89,385.5 ns |   417.08 ns |   348.28 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (AVX2)         | 128KB        | 111,274.8 ns |   197.80 ns |   175.34 ns |     176 B |
| ComputeHash | BLAKE2b-512 | BLAKE2b-512 (Managed)      | 128KB        | 361,919.0 ns | 1,331.20 ns | 1,245.20 ns |     176 B |