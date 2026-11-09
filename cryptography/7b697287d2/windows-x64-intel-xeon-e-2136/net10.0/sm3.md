| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     916.0 ns |     1.20 ns |     1.06 ns |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |   1,226.1 ns |     3.38 ns |     3.16 ns |   3,584 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     924.9 ns |     4.08 ns |     3.61 ns |   2,982 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |   1,245.6 ns |     3.74 ns |     3.32 ns |   3,597 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   5,123.1 ns |     9.55 ns |     8.93 ns |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   6,708.9 ns |     7.70 ns |     6.01 ns |   3,593 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   5,120.4 ns |     8.47 ns |     7.92 ns |   2,985 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   6,596.7 ns |     8.94 ns |     8.36 ns |   3,605 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  38,352.4 ns |   102.26 ns |    95.65 ns |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  49,551.9 ns |    84.66 ns |    70.69 ns |   3,450 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 609,011.6 ns | 2,244.19 ns | 2,099.21 ns |   3,005 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 800,677.0 ns |   717.79 ns |   636.30 ns |   3,580 B |         - |