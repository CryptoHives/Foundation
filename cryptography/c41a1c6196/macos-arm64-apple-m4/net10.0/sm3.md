| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     625.4 ns |     2.08 ns |     1.63 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     643.9 ns |     9.62 ns |     9.00 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     628.7 ns |     5.11 ns |     4.53 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     631.5 ns |     6.83 ns |     6.39 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,417.1 ns |    14.17 ns |    11.83 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,568.6 ns |    55.73 ns |    52.13 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,425.9 ns |    35.96 ns |    33.63 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,578.2 ns |    42.11 ns |    39.39 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,729.0 ns |   305.74 ns |   271.03 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  27,133.7 ns |   347.15 ns |   324.73 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 410,624.2 ns | 3,915.38 ns | 3,269.52 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 430,034.1 ns | 4,512.09 ns | 4,220.61 ns |         - |