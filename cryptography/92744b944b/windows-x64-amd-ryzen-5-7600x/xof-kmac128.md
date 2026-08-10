| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.170 μs | 0.0142 μs | 0.0125 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   3.890 μs | 0.0322 μs | 0.0302 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.028 μs | 0.0288 μs | 0.0270 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.900 μs | 0.0208 μs | 0.0195 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   5.302 μs | 0.0269 μs | 0.0252 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   6.951 μs | 0.0212 μs | 0.0177 μs |    1280 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  15.408 μs | 0.1204 μs | 0.1006 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  17.548 μs | 0.2162 μs | 0.1805 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  20.523 μs | 0.1073 μs | 0.0951 μs |    9344 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 190.766 μs | 1.2287 μs | 1.1493 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 235.551 μs | 1.1747 μs | 0.9809 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 257.764 μs | 2.5554 μs | 2.3903 μs |  149888 B |