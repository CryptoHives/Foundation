| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     500.8 ns |   4.39 ns |   4.10 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     517.1 ns |   0.37 ns |   0.33 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     499.3 ns |   1.57 ns |   1.39 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     523.2 ns |   0.13 ns |   0.13 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,817.2 ns |   9.56 ns |   8.47 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2,908.3 ns |   1.27 ns |   1.19 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,833.3 ns |   7.19 ns |   6.72 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2,911.2 ns |   1.81 ns |   1.69 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  21,202.9 ns |  62.69 ns |  55.57 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21,910.3 ns |   5.14 ns |   4.29 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 342,089.3 ns | 941.05 ns | 834.21 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 347,803.9 ns | 209.93 ns | 196.36 ns |         - |