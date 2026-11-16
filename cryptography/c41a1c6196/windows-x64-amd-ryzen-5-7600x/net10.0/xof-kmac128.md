| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.533 μs | 0.0163 μs | 0.0153 μs |   7,287 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   4.483 μs | 0.0229 μs | 0.0214 μs |  11,273 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.728 μs | 0.0131 μs | 0.0109 μs |  14,579 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.885 μs | 0.0213 μs | 0.0189 μs |   7,286 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   6.126 μs | 0.0309 μs | 0.0289 μs |  11,291 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   7.769 μs | 0.0238 μs | 0.0223 μs |  14,606 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  14.236 μs | 0.0267 μs | 0.0223 μs |   7,286 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  17.588 μs | 0.0292 μs | 0.0244 μs |  11,326 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  22.251 μs | 0.0454 μs | 0.0403 μs |  14,628 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 178.198 μs | 0.5907 μs | 0.5526 μs |   7,288 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 218.746 μs | 0.9060 μs | 0.8474 μs |  11,289 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 274.403 μs | 0.7991 μs | 0.7475 μs |  14,645 B |     128 B |