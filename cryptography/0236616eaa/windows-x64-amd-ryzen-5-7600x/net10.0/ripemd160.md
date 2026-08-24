| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     650.5 ns |     0.98 ns |     0.81 ns |  11,277 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     725.2 ns |     1.46 ns |     1.37 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     653.8 ns |     3.60 ns |     3.01 ns |  11,282 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     729.4 ns |     1.81 ns |     1.51 ns |   5,918 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   3,560.7 ns |     6.88 ns |     5.74 ns |  11,281 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,061.0 ns |    11.79 ns |    10.45 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   3,565.0 ns |     7.56 ns |     7.07 ns |  11,289 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,061.4 ns |     6.31 ns |     5.27 ns |   5,923 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  26,815.3 ns |    34.50 ns |    28.81 ns |  11,136 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  30,719.0 ns |    70.21 ns |    54.81 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 426,853.6 ns | 1,926.95 ns | 1,708.20 ns |  11,249 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 487,614.7 ns | 1,307.65 ns | 1,020.93 ns |   5,940 B |         - |