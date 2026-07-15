| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     622.0 ns |     3.14 ns |     2.63 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     630.5 ns |     0.88 ns |     0.74 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     618.5 ns |     0.82 ns |     0.69 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     633.6 ns |     1.35 ns |     1.20 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,372.4 ns |     1.15 ns |     0.90 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,584.2 ns |    10.39 ns |     8.11 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,373.5 ns |     0.78 ns |     0.65 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,583.0 ns |     8.20 ns |     7.67 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,336.1 ns |     8.77 ns |     7.33 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  27,159.5 ns |    72.91 ns |    56.92 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 403,898.9 ns |   776.57 ns |   606.30 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 434,674.7 ns | 5,649.12 ns | 5,284.19 ns |         - |