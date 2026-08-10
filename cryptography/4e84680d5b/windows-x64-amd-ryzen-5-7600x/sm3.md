| Description                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SM3 · SM3 (Managed)      | 128B         |     724.0 ns |     3.17 ns |     2.97 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 128B         |     821.6 ns |     2.85 ns |     2.38 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 137B         |     727.2 ns |     5.07 ns |     4.75 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 137B         |     816.3 ns |     2.43 ns |     2.27 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 1KB          |   3,949.4 ns |    32.87 ns |    30.75 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 1KB          |   4,488.3 ns |    22.41 ns |    20.96 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 1025B        |   3,907.7 ns |    33.40 ns |    29.61 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 1025B        |   4,491.4 ns |    31.75 ns |    24.79 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 8KB          |  29,462.0 ns |   122.61 ns |   108.69 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 8KB          |  33,205.3 ns |    96.80 ns |    80.83 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 128KB        | 466,461.4 ns | 1,708.26 ns | 1,597.91 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 128KB        | 525,441.8 ns | 2,153.65 ns | 1,909.15 ns |     112 B |