| Description                               | TestDataSize | Mean         | Error        | StdDev       | Median       | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|-------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     800.7 ns |      4.91 ns |      4.59 ns |     798.5 ns |  11,984 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     907.7 ns |      1.89 ns |      1.67 ns |     907.7 ns |   3,813 B |         - |
|                                           |              |              |              |              |              |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     800.3 ns |      1.38 ns |      1.22 ns |     800.4 ns |   5,447 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     900.5 ns |      2.25 ns |      2.10 ns |     900.3 ns |   3,813 B |         - |
|                                           |              |              |              |              |              |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   4,451.1 ns |     12.74 ns |     11.91 ns |   4,446.0 ns |   5,459 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   5,059.8 ns |      4.20 ns |      3.51 ns |   5,059.6 ns |   3,805 B |         - |
|                                           |              |              |              |              |              |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   4,451.1 ns |      9.26 ns |      8.21 ns |   4,449.1 ns |  11,785 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   5,063.6 ns |      7.16 ns |      5.97 ns |   5,062.8 ns |   3,815 B |         - |
|                                           |              |              |              |              |              |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  33,633.7 ns |     24.08 ns |     18.80 ns |  33,637.8 ns |  11,984 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  38,103.5 ns |    346.55 ns |    289.39 ns |  37,929.2 ns |   4,161 B |         - |
|                                           |              |              |              |              |              |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 546,438.4 ns | 10,796.96 ns | 20,279.31 ns | 536,879.3 ns |  11,804 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 610,579.1 ns |    651.40 ns |    543.94 ns | 610,436.9 ns |   4,026 B |         - |