| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 128B         |     674.4 ns |     4.30 ns |     4.02 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 128B         |     743.1 ns |     6.02 ns |     5.63 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 137B         |     670.5 ns |     3.15 ns |     2.95 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 137B         |     748.1 ns |     5.53 ns |     5.17 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 1KB          |   3,572.5 ns |    12.27 ns |    11.48 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 1KB          |   4,052.7 ns |    51.90 ns |    48.54 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 1025B        |   3,614.8 ns |    17.09 ns |    15.98 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 1025B        |   4,039.4 ns |    43.51 ns |    40.70 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 8KB          |  26,697.9 ns |   130.30 ns |   121.89 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 8KB          |  30,418.0 ns |   192.35 ns |   170.51 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 128KB        | 426,187.9 ns | 1,260.65 ns | 1,179.22 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 128KB        | 482,028.7 ns | 5,289.68 ns | 4,417.12 ns |      96 B |