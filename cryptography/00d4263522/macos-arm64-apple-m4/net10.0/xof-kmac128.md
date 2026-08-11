| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |   2.285 μs | 0.0021 μs | 0.0016 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.459 μs | 0.0190 μs | 0.0158 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.562 μs | 0.0500 μs | 0.0576 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |   3.179 μs | 0.0447 μs | 0.0418 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.398 μs | 0.0477 μs | 0.0446 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.459 μs | 0.0486 μs | 0.0455 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |   9.143 μs | 0.0187 μs | 0.0146 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |   9.777 μs | 0.0163 μs | 0.0128 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |   9.975 μs | 0.1919 μs | 0.1795 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 114.733 μs | 1.6022 μs | 1.4987 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 118.665 μs | 2.0541 μs | 1.8209 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 122.727 μs | 1.5550 μs | 1.4545 μs |         - |