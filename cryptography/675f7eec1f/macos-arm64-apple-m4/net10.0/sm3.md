| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     625.2 ns |     2.19 ns |     1.83 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     634.8 ns |     2.45 ns |     2.18 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     625.4 ns |     3.77 ns |     3.34 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     637.9 ns |     0.83 ns |     0.64 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,398.4 ns |     2.76 ns |     2.31 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,640.2 ns |    60.45 ns |    56.55 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,402.1 ns |     8.76 ns |     7.32 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,607.4 ns |     9.57 ns |     8.48 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,525.0 ns |    23.98 ns |    20.02 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  27,754.0 ns |   469.63 ns |   439.29 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 406,296.1 ns |   628.86 ns |   525.13 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 436,012.4 ns | 4,605.92 ns | 4,083.03 ns |         - |