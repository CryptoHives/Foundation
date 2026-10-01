| Description                               | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|-------------:|----------:|
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     625.7 ns |    10.30 ns |      9.63 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     633.5 ns |     7.92 ns |      7.02 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     622.8 ns |     5.74 ns |      4.79 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     633.7 ns |     3.87 ns |      3.02 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,389.3 ns |    29.44 ns |     24.58 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,556.0 ns |    12.89 ns |     10.06 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,372.8 ns |     6.33 ns |      4.94 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,570.7 ns |    38.59 ns |     34.21 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,325.2 ns |    34.06 ns |     28.44 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  27,342.4 ns |   461.84 ns |    432.00 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 411,424.4 ns | 8,046.92 ns | 10,742.41 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 431,528.4 ns | 7,026.25 ns |  6,572.35 ns |         - |