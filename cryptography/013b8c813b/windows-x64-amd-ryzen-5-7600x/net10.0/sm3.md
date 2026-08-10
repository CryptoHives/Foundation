| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     697.5 ns |     1.34 ns |     1.18 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     792.5 ns |     1.11 ns |     0.92 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     701.6 ns |     0.90 ns |     0.85 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     798.3 ns |     1.65 ns |     1.46 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,910.8 ns |    10.35 ns |     9.18 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   4,508.6 ns |    12.65 ns |    11.83 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,916.5 ns |     6.95 ns |     6.51 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   4,454.2 ns |    11.44 ns |    10.15 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  29,571.1 ns |    56.39 ns |    49.99 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  34,023.5 ns |   113.90 ns |   100.97 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 472,506.7 ns | 4,988.79 ns | 4,422.43 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 545,242.1 ns | 4,404.06 ns | 3,904.09 ns |         - |