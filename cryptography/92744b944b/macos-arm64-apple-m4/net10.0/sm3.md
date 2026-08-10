| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     623.4 ns |     2.59 ns |     2.16 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     632.7 ns |     2.70 ns |     2.11 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     621.9 ns |     2.89 ns |     2.41 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     633.3 ns |     0.61 ns |     0.51 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,386.9 ns |     6.40 ns |     4.99 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,601.3 ns |    33.47 ns |    31.31 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,386.3 ns |     2.66 ns |     2.08 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,603.7 ns |    34.73 ns |    32.49 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,408.9 ns |     8.73 ns |     6.81 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  27,330.3 ns |   217.07 ns |   192.43 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 406,164.3 ns | 2,889.33 ns | 2,702.68 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 437,306.0 ns | 5,152.02 ns | 4,819.21 ns |         - |