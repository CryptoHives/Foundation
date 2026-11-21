| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   7.537 μs | 0.0134 μs | 0.0126 μs |  17,843 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |  10.677 μs | 0.0122 μs | 0.0102 μs |  21,200 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |  10.757 μs | 0.0329 μs | 0.0308 μs |   9,768 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |  10.336 μs | 0.0197 μs | 0.0175 μs |  11,508 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |  14.431 μs | 0.0308 μs | 0.0273 μs |  19,801 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |  14.501 μs | 0.0161 μs | 0.0143 μs |  21,229 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  31.293 μs | 0.0193 μs | 0.0181 μs |  11,517 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  43.291 μs | 0.0515 μs | 0.0430 μs |  27,561 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  43.782 μs | 0.2042 μs | 0.1810 μs |  16,129 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 386.529 μs | 0.1428 μs | 0.1336 μs |  11,508 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 532.012 μs | 0.8607 μs | 0.7630 μs |  27,487 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 541.154 μs | 2.8245 μs | 2.6420 μs |  15,139 B |      32 B |