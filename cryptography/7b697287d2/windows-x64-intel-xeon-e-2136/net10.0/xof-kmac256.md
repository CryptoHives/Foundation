| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   7.525 μs | 0.0093 μs | 0.0083 μs |   7,313 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |  10.726 μs | 0.0184 μs | 0.0172 μs |  17,759 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |  10.774 μs | 0.0192 μs | 0.0170 μs |  10,729 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |  10.330 μs | 0.0211 μs | 0.0197 μs |   7,316 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |  14.537 μs | 0.0130 μs | 0.0116 μs |  17,812 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |  14.569 μs | 0.0442 μs | 0.0413 μs |  10,732 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  31.257 μs | 0.0649 μs | 0.0575 μs |   7,316 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  44.227 μs | 0.2084 μs | 0.1950 μs |  10,729 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  44.381 μs | 0.0911 μs | 0.0852 μs |  17,894 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 387.000 μs | 0.2467 μs | 0.2187 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 532.778 μs | 0.4440 μs | 0.3936 μs |  17,865 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 542.157 μs | 1.8643 μs | 1.7439 μs |  11,329 B |      32 B |