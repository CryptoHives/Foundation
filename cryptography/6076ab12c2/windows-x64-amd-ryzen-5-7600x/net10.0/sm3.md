| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     811.1 ns |   4.44 ns |   4.15 ns |   2,987 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     928.5 ns |   4.72 ns |   4.42 ns |   3,578 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     816.1 ns |   4.40 ns |   4.12 ns |   2,974 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     929.2 ns |   5.02 ns |   4.69 ns |   3,591 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   4,534.4 ns |  28.10 ns |  26.29 ns |   2,987 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   5,073.7 ns |   3.03 ns |   2.69 ns |   3,593 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   4,524.7 ns |   4.33 ns |   4.05 ns |   2,977 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   5,147.3 ns |   3.97 ns |   3.52 ns |   3,599 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  34,175.7 ns |  19.20 ns |  17.02 ns |   2,987 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  38,312.1 ns |  48.12 ns |  45.01 ns |   3,444 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 542,567.8 ns | 545.19 ns | 509.97 ns |   2,997 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 609,189.8 ns | 683.37 ns | 639.22 ns |   3,574 B |         - |