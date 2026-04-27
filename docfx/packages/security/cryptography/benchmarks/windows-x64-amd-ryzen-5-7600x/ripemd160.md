| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     638.8 ns |     1.59 ns |     1.41 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     703.1 ns |     4.50 ns |     3.99 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     639.3 ns |     2.85 ns |     2.53 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     712.4 ns |     7.27 ns |     6.45 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   3,551.4 ns |     3.91 ns |     3.05 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   3,942.6 ns |    24.81 ns |    21.99 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   3,561.0 ns |     9.13 ns |     7.63 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   3,950.1 ns |    14.31 ns |    12.69 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  26,855.9 ns |    68.48 ns |    60.70 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  29,928.6 ns |   266.76 ns |   208.27 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 426,882.3 ns | 1,441.29 ns | 1,203.54 ns |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 474,293.7 ns | 3,466.28 ns | 3,242.36 ns |         - |