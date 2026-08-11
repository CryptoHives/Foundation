| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     717.0 ns |   0.97 ns |   0.76 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     824.5 ns |   0.93 ns |   0.72 ns |   5,375 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     723.9 ns |   2.39 ns |   2.12 ns |   4,700 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     827.6 ns |   1.65 ns |   1.55 ns |   5,377 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   4,023.3 ns |   3.11 ns |   2.43 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   4,605.2 ns |   7.95 ns |   6.64 ns |   5,380 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   4,028.1 ns |   9.18 ns |   8.59 ns |   4,703 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   4,600.9 ns |   9.37 ns |   7.83 ns |   5,384 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  30,495.5 ns | 213.33 ns | 178.14 ns |   4,713 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  34,338.4 ns |  72.72 ns |  64.47 ns |   5,397 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 482,458.1 ns | 606.94 ns | 506.83 ns |   4,730 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 545,123.0 ns | 992.28 ns | 879.63 ns |   5,355 B |         - |