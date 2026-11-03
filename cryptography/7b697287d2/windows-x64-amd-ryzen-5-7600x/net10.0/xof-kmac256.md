| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   4.168 μs | 0.0075 μs | 0.0070 μs |   7,285 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   5.233 μs | 0.0142 μs | 0.0133 μs |  11,291 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   6.747 μs | 0.0101 μs | 0.0094 μs |  17,630 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.721 μs | 0.0087 μs | 0.0081 μs |   7,292 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   7.134 μs | 0.0083 μs | 0.0074 μs |  10,701 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   9.097 μs | 0.0155 μs | 0.0138 μs |  16,568 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  17.516 μs | 0.0680 μs | 0.0636 μs |   7,292 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  21.639 μs | 0.0383 μs | 0.0339 μs |  10,701 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  27.343 μs | 0.0357 μs | 0.0334 μs |  17,665 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 218.394 μs | 0.2433 μs | 0.2276 μs |   7,290 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 266.879 μs | 0.7932 μs | 0.7420 μs |  11,286 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 337.514 μs | 0.6792 μs | 0.6353 μs |  17,794 B |     128 B |