| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     795.5 ns |     1.78 ns |     1.58 ns |   2,977 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     923.6 ns |     1.09 ns |     0.91 ns |   3,595 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     798.5 ns |     2.09 ns |     1.85 ns |   2,964 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     924.3 ns |     2.20 ns |     1.95 ns |   3,601 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   4,440.0 ns |    16.10 ns |    14.27 ns |   2,977 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   5,095.2 ns |    13.77 ns |    12.20 ns |   3,593 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   4,442.9 ns |     7.11 ns |     6.65 ns |   2,971 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   5,082.1 ns |    15.56 ns |    12.99 ns |   3,599 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  33,582.1 ns |    93.39 ns |    77.98 ns |   2,977 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  38,955.4 ns |    42.98 ns |    33.55 ns |   3,612 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 532,338.1 ns | 1,000.86 ns |   835.76 ns |   2,987 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 611,122.2 ns | 2,096.10 ns | 1,960.69 ns |   3,574 B |         - |