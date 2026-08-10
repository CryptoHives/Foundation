| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     513.2 ns |     0.23 ns |     0.21 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     513.2 ns |     1.62 ns |     1.35 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     517.0 ns |     1.91 ns |     1.79 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     517.7 ns |     0.27 ns |     0.25 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2,871.8 ns |     0.51 ns |     0.45 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,888.5 ns |    14.41 ns |    13.48 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2,875.5 ns |     0.66 ns |     0.58 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,894.6 ns |    10.47 ns |     9.79 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21,735.9 ns |     2.96 ns |     2.77 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  21,838.1 ns |    69.30 ns |    61.43 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 345,241.5 ns |    26.93 ns |    25.19 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 349,368.3 ns | 1,609.18 ns | 1,505.22 ns |         - |