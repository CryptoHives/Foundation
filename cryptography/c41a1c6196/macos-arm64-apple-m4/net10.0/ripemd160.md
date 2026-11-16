| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     503.7 ns |     2.87 ns |     2.68 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     518.8 ns |     1.90 ns |     1.78 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     507.7 ns |     2.12 ns |     1.99 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     524.4 ns |     2.45 ns |     2.29 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,797.4 ns |    15.81 ns |    14.79 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2,925.5 ns |    11.23 ns |     9.95 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,828.4 ns |    10.11 ns |     9.46 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2,924.3 ns |    11.54 ns |    10.79 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  21,361.8 ns |    93.73 ns |    87.67 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21,997.4 ns |    88.27 ns |    82.56 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 339,436.8 ns | 1,724.34 ns | 1,528.59 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 350,689.9 ns |   973.55 ns |   910.66 ns |         - |