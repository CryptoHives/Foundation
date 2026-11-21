| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     511.6 ns |     3.48 ns |     3.25 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     805.4 ns |     1.20 ns |     1.07 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     512.4 ns |     4.52 ns |     4.23 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     805.1 ns |     2.05 ns |     1.91 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,851.9 ns |    15.14 ns |    14.16 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,551.8 ns |    19.72 ns |    18.45 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,854.3 ns |    11.75 ns |    10.99 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,568.0 ns |    17.56 ns |    16.43 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  21,532.0 ns |    79.67 ns |    74.52 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  34,547.9 ns |   202.94 ns |   189.83 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 341,760.6 ns | 1,465.35 ns | 1,370.69 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 548,242.4 ns | 2,663.30 ns | 2,491.25 ns |         - |