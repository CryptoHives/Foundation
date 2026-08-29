| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     707.0 ns |    12.49 ns |     9.75 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     813.5 ns |     1.08 ns |     0.96 ns |   5,375 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     710.3 ns |     1.02 ns |     0.91 ns |   4,700 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     805.6 ns |    11.43 ns |    10.69 ns |   5,380 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,949.8 ns |    10.02 ns |     8.88 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   4,487.4 ns |     9.39 ns |     7.84 ns |   5,385 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,960.6 ns |    14.84 ns |    12.39 ns |   4,703 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   4,487.2 ns |    15.31 ns |    14.32 ns |   5,381 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  29,966.0 ns |    36.46 ns |    34.10 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  34,313.7 ns |   122.55 ns |   108.64 ns |   5,397 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 475,278.2 ns | 1,000.98 ns |   887.34 ns |   4,730 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 548,603.8 ns | 2,088.89 ns | 1,953.95 ns |   5,355 B |         - |