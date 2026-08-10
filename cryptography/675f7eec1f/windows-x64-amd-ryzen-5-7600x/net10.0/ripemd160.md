| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     655.5 ns |     1.52 ns |     1.35 ns |  11,277 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     723.1 ns |     3.81 ns |     3.38 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     658.0 ns |     1.89 ns |     1.67 ns |  11,284 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     727.0 ns |     5.00 ns |     4.18 ns |   5,918 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   3,599.5 ns |    12.69 ns |    11.25 ns |  11,288 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,058.5 ns |    35.14 ns |    32.87 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   3,602.1 ns |     9.27 ns |     8.22 ns |  11,286 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,063.7 ns |    37.01 ns |    34.61 ns |   5,923 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  27,086.8 ns |    80.28 ns |    75.10 ns |  11,136 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  30,614.1 ns |   240.88 ns |   225.32 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 430,999.5 ns | 1,697.61 ns | 1,504.88 ns |  11,249 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 488,041.3 ns | 2,731.75 ns | 2,421.62 ns |   5,940 B |         - |