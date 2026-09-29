| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.500 μs | 0.0056 μs | 0.0052 μs |   7,051 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   4.442 μs | 0.0126 μs | 0.0118 μs |  11,281 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.702 μs | 0.0090 μs | 0.0080 μs |  14,577 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.843 μs | 0.0152 μs | 0.0134 μs |   7,057 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   6.085 μs | 0.0077 μs | 0.0068 μs |  11,281 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   7.767 μs | 0.0190 μs | 0.0177 μs |  14,615 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  14.204 μs | 0.0221 μs | 0.0207 μs |   7,050 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  17.633 μs | 0.0436 μs | 0.0387 μs |  10,699 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  22.158 μs | 0.0342 μs | 0.0320 μs |  14,621 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 177.371 μs | 0.3550 μs | 0.3320 μs |   7,052 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 217.771 μs | 0.3997 μs | 0.3544 μs |  11,279 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 273.445 μs | 0.5744 μs | 0.5373 μs |  14,645 B |     128 B |