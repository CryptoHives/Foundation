| Description                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SM3 · SM3 (Managed)      | 128B         |     714.0 ns |     1.45 ns |     1.13 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 128B         |     806.3 ns |     3.01 ns |     2.81 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 137B         |     719.0 ns |     3.39 ns |     2.83 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 137B         |     805.2 ns |     2.72 ns |     2.27 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 1KB          |   3,889.7 ns |    13.87 ns |    12.29 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 1KB          |   4,432.6 ns |     8.82 ns |     7.37 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 1025B        |   3,891.2 ns |    15.36 ns |    14.37 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 1025B        |   4,449.9 ns |    21.32 ns |    19.95 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 8KB          |  29,194.3 ns |    93.16 ns |    87.14 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 8KB          |  32,854.5 ns |   109.18 ns |    96.79 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 128KB        | 462,354.5 ns |   700.09 ns |   654.86 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 128KB        | 523,469.3 ns | 1,818.36 ns | 1,518.41 ns |     112 B |