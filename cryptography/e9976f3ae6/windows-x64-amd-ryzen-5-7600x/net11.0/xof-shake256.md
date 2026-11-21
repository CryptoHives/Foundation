| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.682 μs | 0.0095 μs | 0.0079 μs |   9,530 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.546 μs | 0.0072 μs | 0.0060 μs |  11,723 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   5.642 μs | 0.0142 μs | 0.0126 μs |   9,729 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   5.258 μs | 0.0429 μs | 0.0380 μs |  15,865 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   6.433 μs | 0.0086 μs | 0.0072 μs |  10,492 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   8.046 μs | 0.0221 μs | 0.0196 μs |   9,751 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  17.047 μs | 0.0302 μs | 0.0268 μs |   9,539 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  20.992 μs | 0.1081 μs | 0.0958 μs |  11,723 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  26.387 μs | 0.1988 μs | 0.1762 μs |  16,086 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 218.536 μs | 0.4763 μs | 0.3977 μs |   9,532 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 267.046 μs | 0.2842 μs | 0.2520 μs |  10,666 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 335.049 μs | 0.5844 μs | 0.4880 μs |  16,276 B |         - |