| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   3.730 μs | 0.0133 μs | 0.0118 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   4.564 μs | 0.0347 μs | 0.0308 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   5.897 μs | 0.0309 μs | 0.0289 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.645 μs | 0.0391 μs | 0.0366 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   6.226 μs | 0.0247 μs | 0.0231 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   8.128 μs | 0.0365 μs | 0.0342 μs |    1248 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  18.814 μs | 0.1609 μs | 0.1343 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  20.334 μs | 0.0754 μs | 0.0668 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  25.184 μs | 0.1988 μs | 0.1762 μs |    9728 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 232.120 μs | 1.1318 μs | 0.8836 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 271.349 μs | 2.8158 μs | 2.6339 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 317.745 μs | 1.6789 μs | 1.5705 μs |  154208 B |