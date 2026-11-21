| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   2.446 μs | 0.0029 μs | 0.0023 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128B         |   2.457 μs | 0.0020 μs | 0.0018 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   2.615 μs | 0.0037 μs | 0.0035 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 1KB          |   3.442 μs | 0.0030 μs | 0.0028 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   3.508 μs | 0.0223 μs | 0.0209 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   3.695 μs | 0.0031 μs | 0.0029 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 8KB          |  10.994 μs | 0.0090 μs | 0.0084 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  11.357 μs | 0.0454 μs | 0.0402 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  11.839 μs | 0.0149 μs | 0.0140 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128KB        | 139.296 μs | 0.3627 μs | 0.3392 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 145.564 μs | 0.9054 μs | 0.8469 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 150.921 μs | 0.1972 μs | 0.1845 μs |         - |