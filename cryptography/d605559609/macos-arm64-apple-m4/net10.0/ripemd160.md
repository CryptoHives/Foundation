| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     525.1 ns |   0.21 ns |   0.19 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     533.3 ns |   2.10 ns |   1.86 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     531.5 ns |   1.66 ns |   1.47 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     535.2 ns |   3.55 ns |   3.33 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2,906.1 ns |   3.97 ns |   3.52 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,975.0 ns |   7.64 ns |   7.15 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2,911.6 ns |   4.28 ns |   3.57 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,978.8 ns |   5.30 ns |   4.95 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21,935.6 ns |   7.70 ns |   6.43 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  22,573.0 ns |  52.00 ns |  40.60 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 348,323.0 ns | 342.93 ns | 304.00 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 359,276.3 ns | 479.24 ns | 400.18 ns |         - |