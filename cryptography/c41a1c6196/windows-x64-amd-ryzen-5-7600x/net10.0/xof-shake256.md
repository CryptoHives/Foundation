| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.743 μs | 0.0356 μs | 0.0297 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.662 μs | 0.0733 μs | 0.0612 μs |   2,811 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   5.650 μs | 0.0271 μs | 0.0211 μs |   7,096 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   5.358 μs | 0.0552 μs | 0.0431 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   6.478 μs | 0.0557 μs | 0.0521 μs |   2,813 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   8.202 μs | 0.1065 μs | 0.0996 μs |   7,121 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  17.355 μs | 0.3414 μs | 0.4192 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  20.887 μs | 0.0910 μs | 0.0806 μs |   2,813 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  26.605 μs | 0.1438 μs | 0.1201 μs |   7,110 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 217.925 μs | 0.7889 μs | 0.6588 μs |   5,179 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 270.350 μs | 4.3058 μs | 4.0277 μs |   2,811 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 527.253 μs | 6.1984 μs | 5.4947 μs |   7,114 B |         - |