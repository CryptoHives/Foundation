| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     639.4 ns |     1.73 ns |     1.53 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     731.2 ns |     2.43 ns |     2.03 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     640.7 ns |     1.79 ns |     1.59 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     733.6 ns |     1.80 ns |     1.69 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   3,557.7 ns |     8.86 ns |     7.85 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,108.1 ns |    18.08 ns |    16.03 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   3,558.5 ns |     5.00 ns |     4.68 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,114.8 ns |    16.83 ns |    15.75 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  26,860.1 ns |    41.60 ns |    36.88 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  30,822.7 ns |    78.64 ns |    69.71 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 427,819.3 ns | 1,138.60 ns | 1,009.34 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 488,409.3 ns |   803.42 ns |   751.52 ns |         - |