| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     552.4 ns |     3.46 ns |     3.07 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,033.1 ns |     2.42 ns |     1.89 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     827.0 ns |     8.78 ns |     6.86 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,200.0 ns |    18.86 ns |    16.72 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,704.1 ns |     6.04 ns |     5.04 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,165.4 ns |    10.41 ns |     9.23 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,716.4 ns |    18.95 ns |    16.80 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,128.9 ns |     9.52 ns |     7.95 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  10,170.9 ns |    33.04 ns |    29.29 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,494.1 ns |   142.42 ns |   126.25 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 151,979.4 ns | 1,421.66 ns | 1,260.27 ns |     256 B |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 153,932.0 ns |   349.90 ns |   327.30 ns |         - |