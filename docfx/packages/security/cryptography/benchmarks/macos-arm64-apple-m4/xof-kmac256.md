| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   3.107 μs | 0.0033 μs | 0.0029 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   3.123 μs | 0.0291 μs | 0.0243 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.429 μs | 0.0136 μs | 0.0121 μs |    1248 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.814 μs | 0.0081 μs | 0.0072 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  12.913 μs | 0.1944 μs | 0.1518 μs |    9728 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  18.072 μs | 0.0490 μs | 0.0409 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 161.545 μs | 2.9532 μs | 2.4661 μs |  154208 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 246.613 μs | 4.7857 μs | 5.3193 μs |         - |