| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     613.5 ns |     1.77 ns |     1.48 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     636.3 ns |     6.31 ns |     5.90 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     622.4 ns |    11.86 ns |    11.09 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     629.7 ns |     6.45 ns |     6.04 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,418.9 ns |    24.33 ns |    21.57 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,470.9 ns |    45.62 ns |    42.67 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,418.0 ns |    20.72 ns |    17.30 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,450.2 ns |    12.58 ns |     9.82 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,603.0 ns |    48.22 ns |    37.65 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  26,442.9 ns |   386.97 ns |   361.98 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 416,549.9 ns | 5,981.68 ns | 5,595.26 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 419,723.2 ns | 6,055.12 ns | 5,663.96 ns |         - |