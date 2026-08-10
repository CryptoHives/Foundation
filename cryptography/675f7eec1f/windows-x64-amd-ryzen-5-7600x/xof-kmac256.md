| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   3.686 μs | 0.0374 μs | 0.0332 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   4.691 μs | 0.0520 μs | 0.0486 μs |   8,885 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   5.982 μs | 0.0415 μs | 0.0388 μs |  16,012 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.055 μs | 0.0386 μs | 0.0361 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   6.347 μs | 0.0380 μs | 0.0337 μs |   9,969 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   8.281 μs | 0.0381 μs | 0.0298 μs |  16,282 B |    1248 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  15.505 μs | 0.1312 μs | 0.1227 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  19.184 μs | 0.2047 μs | 0.1915 μs |   9,355 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  25.700 μs | 0.2418 μs | 0.2261 μs |  16,279 B |    9728 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 193.634 μs | 1.1849 μs | 1.1084 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 236.585 μs | 1.3517 μs | 1.2644 μs |   9,991 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 322.336 μs | 2.2261 μs | 1.9734 μs |  14,271 B |  154208 B |