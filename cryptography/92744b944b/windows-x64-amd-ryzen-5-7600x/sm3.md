| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     690.8 ns |     2.63 ns |     2.46 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     789.6 ns |     3.31 ns |     3.09 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     698.7 ns |     3.89 ns |     3.45 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     789.0 ns |     1.20 ns |     1.00 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,861.6 ns |     8.64 ns |     8.08 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   4,409.1 ns |    15.87 ns |    14.07 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,855.9 ns |    16.79 ns |    14.88 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   4,414.5 ns |    20.47 ns |    18.15 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  29,266.0 ns |    95.57 ns |    74.61 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  32,888.8 ns |    90.25 ns |    80.00 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 465,270.1 ns |   676.16 ns |   564.62 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 521,319.2 ns | 1,230.84 ns | 1,091.11 ns |         - |