| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   4.187 μs | 0.0137 μs | 0.0128 μs |   7,285 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   5.292 μs | 0.0261 μs | 0.0244 μs |  11,288 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   6.780 μs | 0.0083 μs | 0.0070 μs |  16,503 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.730 μs | 0.0133 μs | 0.0111 μs |   7,292 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   7.132 μs | 0.0151 μs | 0.0134 μs |  11,298 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   9.127 μs | 0.0115 μs | 0.0102 μs |  17,733 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  17.562 μs | 0.0783 μs | 0.0694 μs |   7,292 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  21.576 μs | 0.0611 μs | 0.0510 μs |  10,694 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  27.329 μs | 0.0356 μs | 0.0278 μs |  16,516 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 218.952 μs | 0.8018 μs | 0.7500 μs |   7,290 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 267.728 μs | 1.1276 μs | 1.0548 μs |  11,289 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 337.481 μs | 0.4212 μs | 0.3733 μs |  17,768 B |     128 B |