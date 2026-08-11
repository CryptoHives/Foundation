| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   3.755 μs | 0.0140 μs | 0.0131 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   4.722 μs | 0.0085 μs | 0.0066 μs |   9,969 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   6.066 μs | 0.0081 μs | 0.0072 μs |  16,975 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.141 μs | 0.0138 μs | 0.0116 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   6.418 μs | 0.0183 μs | 0.0153 μs |   9,969 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   8.215 μs | 0.0175 μs | 0.0146 μs |  15,860 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  15.707 μs | 0.0419 μs | 0.0327 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  19.435 μs | 0.0603 μs | 0.0534 μs |   9,361 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  24.461 μs | 0.0531 μs | 0.0443 μs |  15,820 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 196.544 μs | 0.5228 μs | 0.4890 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 242.009 μs | 0.6326 μs | 0.5282 μs |   9,991 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 303.261 μs | 1.3729 μs | 1.2842 μs |  17,090 B |     128 B |