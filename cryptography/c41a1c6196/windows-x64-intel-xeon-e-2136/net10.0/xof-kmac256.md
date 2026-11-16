| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   7.540 μs | 0.0305 μs | 0.0285 μs |   7,319 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |  10.727 μs | 0.0199 μs | 0.0177 μs |  17,752 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |  10.853 μs | 0.0307 μs | 0.0288 μs |  10,729 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |  10.327 μs | 0.0359 μs | 0.0336 μs |   7,316 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |  14.503 μs | 0.0172 μs | 0.0153 μs |  17,802 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |  14.648 μs | 0.0219 μs | 0.0183 μs |  11,364 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  31.143 μs | 0.0170 μs | 0.0159 μs |   7,316 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  43.279 μs | 0.0653 μs | 0.0545 μs |  16,679 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  44.408 μs | 0.1721 μs | 0.1610 μs |  10,732 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 386.088 μs | 0.2382 μs | 0.2228 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 532.852 μs | 1.5062 μs | 1.4089 μs |  17,834 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 546.277 μs | 1.9436 μs | 1.8181 μs |  11,356 B |      32 B |