| Description                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · Managed      | 128B         |     692.4 ns |     1.45 ns |     1.21 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 128B         |     789.1 ns |     1.95 ns |     1.82 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 137B         |     694.5 ns |     0.81 ns |     0.63 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 137B         |     791.0 ns |     3.94 ns |     3.69 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 1KB          |   3,866.0 ns |    12.26 ns |    10.87 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 1KB          |   4,415.2 ns |    14.34 ns |    12.71 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 1025B        |   3,867.0 ns |     8.47 ns |     7.93 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 1025B        |   4,411.8 ns |    14.19 ns |    12.58 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 8KB          |  29,290.8 ns |    76.41 ns |    67.74 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 8KB          |  32,932.9 ns |   150.48 ns |   133.40 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 128KB        | 463,188.4 ns | 1,546.12 ns | 1,446.24 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 128KB        | 528,446.4 ns | 1,621.63 ns | 1,437.53 ns |         - |