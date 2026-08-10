| Description                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | SM3 | SM3 (Managed)      | 128B         |     734.1 ns |    14.33 ns |    14.08 ns |     112 B |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 128B         |     826.9 ns |    16.09 ns |    15.80 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash | SM3 | SM3 (Managed)      | 137B         |     727.0 ns |     8.38 ns |     7.43 ns |     112 B |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 137B         |     831.8 ns |    16.39 ns |    15.33 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash | SM3 | SM3 (Managed)      | 1KB          |   3,966.1 ns |    78.17 ns |    83.64 ns |     112 B |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 1KB          |   4,554.5 ns |    89.94 ns |    99.97 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash | SM3 | SM3 (Managed)      | 1025B        |   3,911.5 ns |    15.93 ns |    14.13 ns |     112 B |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 1025B        |   4,448.3 ns |    13.39 ns |    12.53 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash | SM3 | SM3 (Managed)      | 8KB          |  29,261.4 ns |    73.38 ns |    65.05 ns |     112 B |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 8KB          |  32,898.1 ns |    63.04 ns |    49.21 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash | SM3 | SM3 (Managed)      | 128KB        | 464,236.4 ns | 1,744.02 ns | 1,546.02 ns |     112 B |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 128KB        | 527,316.0 ns | 4,831.64 ns | 4,283.13 ns |     112 B |