| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     794.6 ns |     0.90 ns |     0.84 ns |   2,977 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     919.4 ns |     1.15 ns |     1.02 ns |   3,578 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     797.8 ns |     0.47 ns |     0.44 ns |   2,964 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     923.3 ns |     0.72 ns |     0.60 ns |   3,591 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   4,438.0 ns |     7.56 ns |     7.07 ns |   2,977 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   5,080.6 ns |     9.92 ns |     9.28 ns |   3,593 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   4,440.8 ns |     8.34 ns |     7.80 ns |   2,967 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   5,084.3 ns |     7.92 ns |     7.02 ns |   3,599 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  33,545.6 ns |    71.51 ns |    63.39 ns |   2,977 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  38,969.5 ns |    64.47 ns |    60.31 ns |   3,612 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 532,275.1 ns | 1,084.38 ns | 1,014.33 ns |   2,987 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 609,856.1 ns | 1,245.75 ns | 1,040.26 ns |   3,574 B |         - |