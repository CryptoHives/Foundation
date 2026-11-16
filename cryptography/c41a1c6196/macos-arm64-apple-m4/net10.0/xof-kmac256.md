| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.776 μs | 0.0069 μs | 0.0065 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.968 μs | 0.0071 μs | 0.0063 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   3.006 μs | 0.0102 μs | 0.0095 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   3.785 μs | 0.0087 μs | 0.0081 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.029 μs | 0.0206 μs | 0.0183 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.058 μs | 0.0125 μs | 0.0116 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  11.947 μs | 0.0546 μs | 0.0511 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  12.060 μs | 0.0349 μs | 0.0327 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  12.246 μs | 0.0246 μs | 0.0230 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 140.910 μs | 0.4907 μs | 0.4590 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 146.458 μs | 0.5041 μs | 0.4715 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 152.585 μs | 0.4202 μs | 0.3930 μs |         - |