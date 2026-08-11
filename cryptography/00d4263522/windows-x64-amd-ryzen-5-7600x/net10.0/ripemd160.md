| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     652.5 ns |     1.88 ns |     1.76 ns |  11,277 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     743.3 ns |     2.59 ns |     2.43 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     657.4 ns |     1.64 ns |     1.46 ns |  11,282 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     736.5 ns |     1.93 ns |     1.71 ns |   5,918 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   3,588.6 ns |     9.46 ns |     8.84 ns |  11,288 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,104.3 ns |    12.06 ns |    10.69 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   3,588.9 ns |     4.66 ns |     4.13 ns |  11,288 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,113.0 ns |    15.12 ns |    13.40 ns |   5,923 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  27,046.0 ns |    41.36 ns |    34.53 ns |  11,136 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  31,059.0 ns |   103.85 ns |    92.06 ns |   5,930 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 430,285.0 ns | 1,520.36 ns | 1,422.14 ns |  11,249 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 492,542.0 ns | 1,244.32 ns | 1,039.07 ns |   5,940 B |         - |