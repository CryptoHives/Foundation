| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.106 μs | 0.0210 μs | 0.0186 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   3.968 μs | 0.0384 μs | 0.0359 μs |   8,885 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.107 μs | 0.0258 μs | 0.0215 μs |  15,429 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.292 μs | 0.0318 μs | 0.0282 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   5.395 μs | 0.0327 μs | 0.0290 μs |   9,969 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   7.090 μs | 0.0515 μs | 0.0482 μs |  16,409 B |    1280 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  12.542 μs | 0.1230 μs | 0.1027 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  15.713 μs | 0.1890 μs | 0.1768 μs |  10,004 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  20.922 μs | 0.1492 μs | 0.1396 μs |  16,427 B |    9344 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 156.910 μs | 1.3074 μs | 1.0918 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 194.647 μs | 1.0902 μs | 1.0198 μs |   9,989 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 264.255 μs | 2.4430 μs | 2.2851 μs |  16,390 B |  149888 B |