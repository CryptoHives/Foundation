| Description                                          | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|-------------:|----------:|
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 128B         |     674.8 ns |     4.62 ns |      4.32 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 128B         |     767.8 ns |    15.39 ns |     17.11 ns |      96 B |
|                                                      |              |              |             |              |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 137B         |     678.8 ns |     7.56 ns |      6.70 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 137B         |     748.6 ns |     5.65 ns |      4.72 ns |      96 B |
|                                                      |              |              |             |              |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 1KB          |   3,577.9 ns |    20.53 ns |     19.20 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 1KB          |   4,157.3 ns |    79.39 ns |     91.42 ns |      96 B |
|                                                      |              |              |             |              |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 1025B        |   3,585.1 ns |    16.66 ns |     15.58 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 1025B        |   4,053.0 ns |    38.27 ns |     35.80 ns |      96 B |
|                                                      |              |              |             |              |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 8KB          |  27,220.6 ns |   541.96 ns |    556.55 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 8KB          |  30,951.5 ns |   613.18 ns |    775.47 ns |      96 B |
|                                                      |              |              |             |              |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 128KB        | 438,442.6 ns | 8,652.50 ns | 12,950.65 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 128KB        | 489,356.9 ns | 9,392.06 ns | 10,439.25 ns |      96 B |