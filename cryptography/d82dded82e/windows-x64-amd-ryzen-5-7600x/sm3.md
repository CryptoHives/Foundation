| Description                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · Managed      | 128B         |     692.6 ns |     2.28 ns |     2.14 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 128B         |     782.8 ns |     6.58 ns |     5.14 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 137B         |     698.3 ns |     3.23 ns |     3.02 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 137B         |     782.5 ns |     3.93 ns |     3.49 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 1KB          |   3,876.5 ns |    21.10 ns |    19.74 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 1KB          |   4,387.0 ns |    32.79 ns |    27.38 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 1025B        |   3,896.0 ns |    24.37 ns |    22.80 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 1025B        |   4,372.0 ns |    28.28 ns |    26.45 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 8KB          |  29,382.2 ns |   136.44 ns |   113.93 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 8KB          |  33,101.4 ns |   311.18 ns |   275.85 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 128KB        | 465,447.6 ns | 3,096.12 ns | 2,744.63 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 128KB        | 523,842.6 ns | 2,370.73 ns | 2,101.59 ns |         - |