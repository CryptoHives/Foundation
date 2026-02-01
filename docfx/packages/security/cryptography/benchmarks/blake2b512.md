| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 128B         |     129.6 ns |     0.43 ns |     0.40 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 128B         |     135.6 ns |     1.24 ns |     1.16 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 128B         |     395.4 ns |     1.94 ns |     1.72 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 137B         |     209.6 ns |     0.56 ns |     0.52 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 137B         |     238.2 ns |     1.06 ns |     0.99 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 137B         |     747.9 ns |     4.89 ns |     4.57 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 1KB          |     749.8 ns |     1.30 ns |     1.08 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 1KB          |     814.7 ns |     2.11 ns |     1.98 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 1KB          |   2,890.2 ns |    19.05 ns |    16.89 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 1025B        |     833.1 ns |     3.14 ns |     2.45 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 1025B        |     917.9 ns |     3.23 ns |     3.02 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 1025B        |   3,235.2 ns |    12.38 ns |    10.98 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 8KB          |   5,635.7 ns |    14.18 ns |    12.57 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 8KB          |   6,295.7 ns |    50.59 ns |    47.32 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 8KB          |  22,596.8 ns |   141.86 ns |   125.76 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 128KB        |  89,224.1 ns |   240.98 ns |   213.62 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 128KB        | 100,040.5 ns |   379.68 ns |   336.57 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 128KB        | 360,331.6 ns | 1,381.95 ns | 1,225.06 ns |     176 B |