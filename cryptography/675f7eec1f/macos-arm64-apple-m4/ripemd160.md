| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     516.8 ns |   1.09 ns |   1.02 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     524.4 ns |   1.02 ns |   0.95 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     521.2 ns |   0.18 ns |   0.17 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     522.7 ns |   4.47 ns |   4.18 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2,891.3 ns |   2.87 ns |   2.68 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,941.6 ns |  14.34 ns |  12.71 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2,896.2 ns |   1.15 ns |   1.08 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,961.0 ns |   6.56 ns |   6.14 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21,877.8 ns |  29.34 ns |  27.44 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  22,395.0 ns |  36.79 ns |  32.62 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 347,479.7 ns | 435.89 ns | 407.74 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 357,165.7 ns | 737.41 ns | 615.77 ns |         - |