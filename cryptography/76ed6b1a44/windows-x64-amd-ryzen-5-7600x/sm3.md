| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     691.8 ns |     1.63 ns |     1.52 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     780.5 ns |     4.64 ns |     4.34 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     695.5 ns |     2.23 ns |     2.09 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     781.5 ns |     3.03 ns |     2.83 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,870.8 ns |    13.02 ns |    11.54 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   4,358.4 ns |    11.60 ns |    10.85 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,876.9 ns |    18.02 ns |    15.04 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   4,366.9 ns |    16.04 ns |    13.40 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  29,200.2 ns |   166.39 ns |   155.64 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  33,422.9 ns |   120.08 ns |   106.45 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 462,994.6 ns | 1,390.99 ns | 1,233.08 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 532,056.9 ns | 2,589.70 ns | 2,295.70 ns |         - |