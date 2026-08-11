| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     624.8 ns |     2.47 ns |     2.06 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     633.7 ns |     2.56 ns |     2.14 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     626.3 ns |     5.03 ns |     4.71 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     638.2 ns |     1.37 ns |     1.22 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,399.1 ns |     1.59 ns |     1.33 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,601.5 ns |    11.26 ns |     8.79 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,395.0 ns |    14.10 ns |    11.78 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,597.4 ns |    16.06 ns |    12.54 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,511.0 ns |    44.28 ns |    41.42 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  27,436.1 ns |   242.34 ns |   202.37 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 406,050.6 ns | 1,354.28 ns | 1,130.89 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 439,096.5 ns | 7,189.61 ns | 6,725.17 ns |         - |