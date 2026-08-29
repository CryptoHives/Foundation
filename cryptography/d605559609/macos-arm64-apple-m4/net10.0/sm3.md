| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     627.6 ns |     7.93 ns |     7.42 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     630.4 ns |     1.67 ns |     1.30 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     629.7 ns |     8.45 ns |     7.90 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     634.6 ns |     2.16 ns |     1.91 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,377.1 ns |     5.43 ns |     4.24 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,605.3 ns |    35.30 ns |    31.29 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,419.7 ns |    53.38 ns |    49.93 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,589.0 ns |    12.39 ns |    10.98 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,632.4 ns |   438.02 ns |   388.29 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  27,382.5 ns |   340.74 ns |   318.72 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 407,612.3 ns | 6,704.25 ns | 5,943.14 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 435,713.7 ns | 5,185.10 ns | 4,850.15 ns |         - |