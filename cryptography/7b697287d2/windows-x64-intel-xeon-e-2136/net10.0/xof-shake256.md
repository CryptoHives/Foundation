| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   4.910 μs | 0.0097 μs | 0.0091 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   6.552 μs | 0.0155 μs | 0.0145 μs |   7,110 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   6.777 μs | 0.0099 μs | 0.0083 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   6.960 μs | 0.0101 μs | 0.0089 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   9.373 μs | 0.0212 μs | 0.0188 μs |   7,138 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   9.629 μs | 0.0218 μs | 0.0204 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  22.406 μs | 0.0411 μs | 0.0385 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  30.745 μs | 0.0786 μs | 0.0735 μs |   7,135 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  31.100 μs | 0.0495 μs | 0.0414 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 285.138 μs | 0.5604 μs | 0.5242 μs |   5,199 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 391.482 μs | 0.6375 μs | 0.5323 μs |   7,138 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 396.035 μs | 0.3985 μs | 0.3532 μs |   2,818 B |         - |