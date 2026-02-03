| Description                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SM3 · SM3 (Managed)      | 128B         |     714.5 ns |     1.59 ns |     1.41 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 128B         |     805.9 ns |     2.85 ns |     2.53 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 137B         |     721.6 ns |     2.40 ns |     2.13 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 137B         |     808.3 ns |     2.83 ns |     2.65 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 1KB          |   3,902.2 ns |    13.28 ns |    11.78 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 1KB          |   4,441.3 ns |    19.29 ns |    18.05 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 1025B        |   3,888.8 ns |    10.59 ns |     9.38 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 1025B        |   4,477.8 ns |     7.28 ns |     5.68 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 8KB          |  29,207.8 ns |    96.72 ns |    85.74 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 8KB          |  32,884.5 ns |    69.73 ns |    58.22 ns |     112 B |
|                                        |              |              |             |             |           |
| ComputeHash · SM3 · SM3 (Managed)      | 128KB        | 463,283.4 ns | 1,974.84 ns | 1,847.27 ns |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 128KB        | 522,317.0 ns | 1,813.21 ns | 1,696.08 ns |     112 B |