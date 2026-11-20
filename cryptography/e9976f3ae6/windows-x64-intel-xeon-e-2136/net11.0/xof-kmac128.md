| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   6.352 μs | 0.0102 μs | 0.0096 μs |  11,506 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   9.071 μs | 0.0530 μs | 0.0496 μs |  19,999 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   9.131 μs | 0.0301 μs | 0.0282 μs |  24,523 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   8.723 μs | 0.0050 μs | 0.0045 μs |  17,841 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |  12.367 μs | 0.0117 μs | 0.0109 μs |  24,545 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |  12.444 μs | 0.0613 μs | 0.0544 μs |  13,655 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  25.358 μs | 0.0252 μs | 0.0236 μs |  11,506 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  35.251 μs | 0.0423 μs | 0.0395 μs |  18,198 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  36.451 μs | 0.0753 μs | 0.0667 μs |  16,337 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 313.878 μs | 0.1830 μs | 0.1623 μs |  17,841 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 432.021 μs | 0.2531 μs | 0.2244 μs |  24,533 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 449.961 μs | 0.9811 μs | 0.9177 μs |  16,339 B |      32 B |