| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     509.1 ns |     2.33 ns |     2.06 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     512.8 ns |     2.02 ns |     1.79 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     513.6 ns |     3.97 ns |     3.71 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     516.5 ns |     0.86 ns |     0.67 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2,874.5 ns |     1.00 ns |     0.78 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2,903.5 ns |    24.76 ns |    20.67 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2,886.0 ns |    11.76 ns |    11.00 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2,898.6 ns |    20.35 ns |    16.99 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21,795.7 ns |    36.72 ns |    32.56 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  21,811.0 ns |    88.48 ns |    82.76 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 346,015.8 ns | 1,106.39 ns |   863.80 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 349,735.2 ns | 2,790.84 ns | 2,474.01 ns |         - |