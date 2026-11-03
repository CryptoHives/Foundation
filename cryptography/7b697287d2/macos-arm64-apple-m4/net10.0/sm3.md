| Description                               | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|-------------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     623.5 ns |     8.93 ns |      8.35 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     634.2 ns |     9.94 ns |      8.30 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     622.8 ns |     7.66 ns |      6.39 ns |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     627.2 ns |    11.08 ns |     10.36 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |   3,427.8 ns |    66.63 ns |     84.26 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |   3,504.0 ns |    37.82 ns |     35.38 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |   3,373.4 ns |     7.82 ns |      7.32 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |   3,528.4 ns |    64.39 ns |     57.08 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |  25,488.4 ns |   487.52 ns |    407.10 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |  26,597.5 ns |   415.15 ns |    388.33 ns |         - |
|                                           |              |              |             |              |           |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 415,320.7 ns | 8,303.65 ns | 12,171.39 ns |         - |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        | 421,929.6 ns | 7,768.77 ns |  6,886.81 ns |         - |