| Description                               | TestDataSize | Mean           | Error        | StdDev      | Allocated |
|------------------------------------------ |------------- |---------------:|-------------:|------------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |       680.3 ns |      8.24 ns |     6.88 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |       686.1 ns |      5.13 ns |     4.28 ns |         - |
|                                           |              |                |              |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |       685.4 ns |     13.10 ns |    15.09 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |       687.5 ns |      8.83 ns |     7.83 ns |         - |
|                                           |              |                |              |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |     3,733.2 ns |     45.09 ns |    37.66 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |     3,903.7 ns |     69.92 ns |    65.40 ns |         - |
|                                           |              |                |              |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |     3,850.7 ns |     57.92 ns |    54.18 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |    16,006.1 ns |    199.69 ns |   166.75 ns |         - |
|                                           |              |                |              |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |   119,661.3 ns |     73.15 ns |    64.84 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |   128,556.0 ns |  1,139.32 ns |   889.51 ns |         - |
|                                           |              |                |              |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 1,906,298.3 ns |  1,277.05 ns | 1,132.07 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 2,027,021.8 ns | 10,170.03 ns | 8,492.44 ns |         - |