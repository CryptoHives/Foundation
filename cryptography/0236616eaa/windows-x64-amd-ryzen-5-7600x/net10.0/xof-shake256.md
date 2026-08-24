| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.267 μs | 0.0077 μs | 0.0068 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.042 μs | 0.0160 μs | 0.0133 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   4.996 μs | 0.0089 μs | 0.0079 μs |   7,008 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   4.654 μs | 0.0143 μs | 0.0127 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   5.730 μs | 0.0095 μs | 0.0074 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   7.134 μs | 0.0062 μs | 0.0052 μs |   7,035 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  15.105 μs | 0.0186 μs | 0.0145 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  18.728 μs | 0.1186 μs | 0.0991 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  23.313 μs | 0.1099 μs | 0.0858 μs |   7,022 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 194.177 μs | 0.2761 μs | 0.2306 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 237.268 μs | 0.3632 μs | 0.3220 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 297.601 μs | 0.5100 μs | 0.4259 μs |   7,026 B |         - |