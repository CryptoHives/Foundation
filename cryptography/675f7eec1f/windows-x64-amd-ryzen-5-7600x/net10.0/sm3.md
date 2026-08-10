| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     698.5 ns |     2.00 ns |     1.87 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     802.4 ns |     3.24 ns |     2.88 ns |   5,375 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     704.3 ns |     2.25 ns |     2.11 ns |   4,700 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     805.2 ns |     5.15 ns |     4.82 ns |   5,377 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,919.9 ns |    22.47 ns |    21.01 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   4,487.4 ns |    27.19 ns |    25.43 ns |   5,385 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,926.1 ns |    27.08 ns |    22.62 ns |   4,703 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   4,487.4 ns |    23.49 ns |    20.83 ns |   5,386 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  29,600.1 ns |   124.10 ns |   116.09 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  33,529.9 ns |   153.84 ns |   143.90 ns |   5,397 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 471,113.4 ns | 2,697.61 ns | 2,523.34 ns |   4,723 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 530,577.4 ns | 1,417.66 ns | 1,183.81 ns |   5,355 B |         - |