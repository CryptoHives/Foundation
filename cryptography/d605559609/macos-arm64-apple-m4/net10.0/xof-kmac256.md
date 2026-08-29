| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.729 μs | 0.0036 μs | 0.0032 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.979 μs | 0.0075 μs | 0.0067 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   3.087 μs | 0.0066 μs | 0.0062 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   3.761 μs | 0.0356 μs | 0.0333 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.029 μs | 0.0213 μs | 0.0189 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.040 μs | 0.0339 μs | 0.0265 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  11.216 μs | 0.0070 μs | 0.0058 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  11.810 μs | 0.0429 μs | 0.0402 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  12.128 μs | 0.0242 μs | 0.0215 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 139.126 μs | 0.1000 μs | 0.0887 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 144.883 μs | 0.9509 μs | 0.7940 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 150.370 μs | 0.4021 μs | 0.3564 μs |         - |