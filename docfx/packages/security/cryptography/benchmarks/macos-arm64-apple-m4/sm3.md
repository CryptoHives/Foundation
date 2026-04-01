| Description                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · BouncyCastle | 128B         |     605.7 ns |     3.01 ns |     2.82 ns |         - |
| TryComputeHash · SM3 · Managed      | 128B         |     611.1 ns |     3.74 ns |     3.13 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 137B         |     604.2 ns |     2.26 ns |     1.89 ns |         - |
| TryComputeHash · SM3 · Managed      | 137B         |     612.7 ns |     3.05 ns |     2.71 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 1KB          |   3,292.2 ns |    10.86 ns |    10.15 ns |         - |
| TryComputeHash · SM3 · Managed      | 1KB          |   3,461.9 ns |    15.16 ns |    13.44 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 1025B        |   3,290.7 ns |    10.11 ns |     9.46 ns |         - |
| TryComputeHash · SM3 · Managed      | 1025B        |   3,463.2 ns |    20.92 ns |    19.57 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 8KB          |  24,702.3 ns |    68.42 ns |    64.00 ns |         - |
| TryComputeHash · SM3 · Managed      | 8KB          |  26,546.9 ns |   354.59 ns |   331.69 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 128KB        | 393,976.3 ns | 1,102.63 ns |   977.45 ns |         - |
| TryComputeHash · SM3 · Managed      | 128KB        | 421,592.7 ns | 6,234.71 ns | 5,831.96 ns |         - |