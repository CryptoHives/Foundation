| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     515.8 ns |     2.03 ns |     1.58 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     521.8 ns |     2.52 ns |     1.96 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     520.5 ns |     0.56 ns |     0.44 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     522.8 ns |     8.26 ns |     7.72 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2,910.9 ns |    39.86 ns |    37.28 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,942.6 ns |    34.88 ns |    32.62 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2,904.7 ns |    35.22 ns |    29.41 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,938.7 ns |    32.07 ns |    30.00 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21,994.6 ns |   315.30 ns |   279.51 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  22,378.1 ns |   302.81 ns |   283.25 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 350,215.8 ns | 5,295.77 ns | 4,953.66 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 357,573.2 ns | 3,857.56 ns | 3,608.36 ns |         - |