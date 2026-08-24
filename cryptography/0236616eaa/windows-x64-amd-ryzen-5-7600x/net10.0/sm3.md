| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     698.3 ns |     1.26 ns |     1.12 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     805.7 ns |     1.30 ns |     1.22 ns |   5,395 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     705.3 ns |     1.59 ns |     1.48 ns |   4,700 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     796.6 ns |     0.88 ns |     0.82 ns |   5,380 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,922.0 ns |     5.38 ns |     4.20 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   4,450.3 ns |     8.89 ns |     7.88 ns |   5,385 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,930.9 ns |    10.02 ns |     8.37 ns |   4,703 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   4,451.5 ns |    10.29 ns |     8.59 ns |   5,386 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  29,688.7 ns |    45.34 ns |    40.19 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  34,681.4 ns |    72.80 ns |    64.53 ns |   5,397 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 471,969.6 ns |   554.47 ns |   491.52 ns |   4,723 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 541,462.3 ns | 1,234.58 ns | 1,094.42 ns |   5,355 B |         - |