| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     510.2 ns |   1.94 ns |   1.81 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     514.6 ns |   2.09 ns |   1.95 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     508.5 ns |   1.46 ns |   1.36 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     520.9 ns |   0.45 ns |   0.42 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,799.4 ns |  11.43 ns |  10.69 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2,893.6 ns |   0.57 ns |   0.53 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,812.9 ns |   9.47 ns |   8.86 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2,903.3 ns |   0.72 ns |   0.68 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  21,164.4 ns | 133.12 ns | 124.52 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21,880.8 ns |   6.37 ns |   5.96 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 338,436.5 ns | 464.93 ns | 388.24 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 347,572.2 ns | 183.08 ns | 171.25 ns |         - |