| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |   2.294 μs | 0.0014 μs | 0.0013 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.466 μs | 0.0029 μs | 0.0027 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.612 μs | 0.0068 μs | 0.0063 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |   3.162 μs | 0.0022 μs | 0.0019 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.381 μs | 0.0058 μs | 0.0054 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.674 μs | 0.0051 μs | 0.0045 μs |    1280 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |   9.168 μs | 0.0058 μs | 0.0054 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |   9.805 μs | 0.0193 μs | 0.0180 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  10.661 μs | 0.0159 μs | 0.0149 μs |    9344 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 113.960 μs | 0.2868 μs | 0.2542 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 121.798 μs | 0.2840 μs | 0.2656 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 133.557 μs | 0.1511 μs | 0.1340 μs |  149888 B |