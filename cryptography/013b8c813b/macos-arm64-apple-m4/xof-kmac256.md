| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.728 μs | 0.0026 μs | 0.0023 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.905 μs | 0.0040 μs | 0.0036 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   3.042 μs | 0.0133 μs | 0.0124 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   3.725 μs | 0.0048 μs | 0.0044 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   3.980 μs | 0.0046 μs | 0.0038 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.181 μs | 0.0098 μs | 0.0092 μs |    1248 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  11.198 μs | 0.0081 μs | 0.0076 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  12.028 μs | 0.0280 μs | 0.0262 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  12.805 μs | 0.0126 μs | 0.0112 μs |    9728 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 138.938 μs | 0.1391 μs | 0.1162 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 149.021 μs | 0.1549 μs | 0.1449 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 160.106 μs | 0.2116 μs | 0.1876 μs |  154208 B |