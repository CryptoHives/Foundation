| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   6.380 μs | 0.0301 μs | 0.0281 μs |   7,317 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   9.138 μs | 0.0153 μs | 0.0143 μs |  14,619 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   9.221 μs | 0.0567 μs | 0.0530 μs |  10,739 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   8.741 μs | 0.0088 μs | 0.0082 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |  12.437 μs | 0.0263 μs | 0.0246 μs |  14,654 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |  12.618 μs | 0.0531 μs | 0.0471 μs |  10,732 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  25.363 μs | 0.0556 μs | 0.0520 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  35.253 μs | 0.1033 μs | 0.0966 μs |  14,691 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  36.665 μs | 0.0890 μs | 0.0833 μs |  10,738 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 314.248 μs | 0.1625 μs | 0.1520 μs |   7,312 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 432.453 μs | 0.8354 μs | 0.7406 μs |  14,685 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 450.185 μs | 1.3211 μs | 1.1711 μs |  11,329 B |      32 B |