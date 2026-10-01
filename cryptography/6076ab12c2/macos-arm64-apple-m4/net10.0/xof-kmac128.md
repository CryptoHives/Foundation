| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |   2.279 μs | 0.0027 μs | 0.0026 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.466 μs | 0.0040 μs | 0.0036 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.537 μs | 0.0207 μs | 0.0183 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |   3.138 μs | 0.0016 μs | 0.0015 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.401 μs | 0.0051 μs | 0.0048 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.427 μs | 0.0187 μs | 0.0175 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |   9.116 μs | 0.0030 μs | 0.0027 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |   9.833 μs | 0.0142 μs | 0.0126 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |   9.840 μs | 0.0637 μs | 0.0532 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 113.741 μs | 0.0530 μs | 0.0470 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 120.472 μs | 0.5240 μs | 0.4901 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 122.274 μs | 0.1438 μs | 0.1201 μs |         - |