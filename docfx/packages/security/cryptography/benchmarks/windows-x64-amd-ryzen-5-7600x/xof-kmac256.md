| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   3.589 μs | 0.0173 μs | 0.0162 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   4.552 μs | 0.0292 μs | 0.0273 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   5.860 μs | 0.0349 μs | 0.0291 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.951 μs | 0.0415 μs | 0.0368 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   6.203 μs | 0.0586 μs | 0.0548 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   8.091 μs | 0.0433 μs | 0.0384 μs |    1248 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  15.154 μs | 0.0687 μs | 0.0574 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  18.749 μs | 0.1252 μs | 0.1171 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  25.168 μs | 0.1201 μs | 0.1065 μs |    9728 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 189.391 μs | 1.7310 μs | 1.4454 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 231.744 μs | 1.2464 μs | 1.1658 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 317.308 μs | 1.1747 μs | 1.0414 μs |  154208 B |