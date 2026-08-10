| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 128B         |     127.1 ns |     1.05 ns |     0.98 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 128B         |     133.9 ns |     1.20 ns |     1.12 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 128B         |     395.6 ns |     3.57 ns |     3.34 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 137B         |     206.2 ns |     1.54 ns |     1.44 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 137B         |     230.5 ns |     1.47 ns |     1.37 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 137B         |     748.0 ns |     5.38 ns |     5.03 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 1KB          |     749.3 ns |     8.72 ns |     7.73 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 1KB          |     815.2 ns |     5.69 ns |     5.32 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 1KB          |   2,869.4 ns |    17.38 ns |    16.26 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 1025B        |     833.2 ns |     5.66 ns |     5.29 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 1025B        |     919.0 ns |     6.70 ns |     6.27 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 1025B        |   3,206.3 ns |    16.39 ns |    15.33 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 8KB          |   5,635.1 ns |    32.75 ns |    30.63 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 8KB          |   6,333.5 ns |    89.94 ns |    84.13 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 8KB          |  22,774.6 ns |   216.77 ns |   202.76 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 128KB        |  89,382.3 ns |   746.88 ns |   623.68 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 128KB        | 101,568.6 ns | 1,969.44 ns | 2,022.47 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 128KB        | 360,903.9 ns | 1,559.19 ns | 1,301.99 ns |     112 B |