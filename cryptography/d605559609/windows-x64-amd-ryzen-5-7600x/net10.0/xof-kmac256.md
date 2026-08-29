| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   3.734 μs | 0.0219 μs | 0.0205 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   4.712 μs | 0.0258 μs | 0.0229 μs |   9,964 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   6.032 μs | 0.0251 μs | 0.0234 μs |  16,991 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.114 μs | 0.0216 μs | 0.0192 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   6.458 μs | 0.0345 μs | 0.0288 μs |   9,969 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   8.213 μs | 0.0136 μs | 0.0127 μs |  15,867 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  15.698 μs | 0.0975 μs | 0.0912 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  19.304 μs | 0.0739 μs | 0.0655 μs |   9,372 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  24.450 μs | 0.1126 μs | 0.1053 μs |  15,817 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 195.132 μs | 0.8916 μs | 0.7904 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 240.040 μs | 1.7340 μs | 1.9273 μs |   9,989 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 300.824 μs | 1.4761 μs | 1.2326 μs |  17,098 B |     128 B |