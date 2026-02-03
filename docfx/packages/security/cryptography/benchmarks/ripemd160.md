| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 128B         |     668.7 ns |     2.56 ns |     2.39 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 128B         |     739.6 ns |     5.54 ns |     5.18 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 137B         |     667.6 ns |     2.81 ns |     2.62 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 137B         |     740.3 ns |     5.22 ns |     4.36 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 1KB          |   3,547.9 ns |     8.46 ns |     7.91 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 1KB          |   3,994.5 ns |    29.45 ns |    22.99 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 1025B        |   3,598.0 ns |     6.13 ns |     5.12 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 1025B        |   4,029.8 ns |    25.11 ns |    22.26 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 8KB          |  26,565.7 ns |    65.66 ns |    58.21 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 8KB          |  30,116.5 ns |   156.76 ns |   138.96 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 128KB        | 423,864.7 ns |   862.51 ns |   720.23 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 128KB        | 476,214.8 ns | 3,100.19 ns | 2,899.92 ns |      96 B |