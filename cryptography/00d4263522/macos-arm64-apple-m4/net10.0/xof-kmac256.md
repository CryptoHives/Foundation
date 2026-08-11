| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.762 μs | 0.0472 μs | 0.0442 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.946 μs | 0.0446 μs | 0.0417 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   2.998 μs | 0.0379 μs | 0.0355 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   3.772 μs | 0.0480 μs | 0.0449 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   3.994 μs | 0.0109 μs | 0.0085 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.008 μs | 0.0135 μs | 0.0105 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  11.338 μs | 0.1815 μs | 0.1698 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  11.926 μs | 0.1807 μs | 0.1690 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  12.131 μs | 0.1786 μs | 0.1671 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 139.440 μs | 0.3523 μs | 0.2750 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 146.293 μs | 2.5872 μs | 2.4200 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 149.816 μs | 0.3191 μs | 0.2491 μs |         - |