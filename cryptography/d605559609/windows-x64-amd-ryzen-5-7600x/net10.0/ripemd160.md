| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     653.5 ns |     3.14 ns |     2.94 ns |  11,276 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     732.8 ns |     3.37 ns |     2.63 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     658.1 ns |     7.43 ns |     7.95 ns |  11,282 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     735.6 ns |     2.47 ns |     2.19 ns |   5,918 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   3,578.0 ns |    11.03 ns |     9.78 ns |  11,288 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,108.1 ns |    20.06 ns |    17.78 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   3,575.3 ns |     8.55 ns |     7.58 ns |  11,288 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,112.1 ns |    25.87 ns |    25.41 ns |   5,923 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  27,037.4 ns |   101.10 ns |    78.94 ns |  11,136 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  31,145.9 ns |   107.38 ns |    95.19 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 429,674.6 ns |   740.25 ns |   618.15 ns |  11,249 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 493,431.3 ns | 2,387.38 ns | 2,116.35 ns |   5,940 B |         - |