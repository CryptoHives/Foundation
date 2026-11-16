| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   3.132 μs | 0.0278 μs | 0.0260 μs |   5,177 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.872 μs | 0.0400 μs | 0.0374 μs |   3,099 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.643 μs | 0.0237 μs | 0.0210 μs |   7,055 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   4.407 μs | 0.0834 μs | 0.0856 μs |   5,177 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   5.411 μs | 0.0173 μs | 0.0153 μs |   3,101 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   6.757 μs | 0.0554 μs | 0.0518 μs |   7,082 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  13.809 μs | 0.1164 μs | 0.1089 μs |   5,177 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  17.653 μs | 0.2481 μs | 0.2321 μs |   3,101 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  21.407 μs | 0.0951 μs | 0.0890 μs |   7,082 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 179.463 μs | 0.8685 μs | 0.7252 μs |   5,179 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 220.492 μs | 0.7595 μs | 0.6342 μs |   3,099 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 279.214 μs | 4.1008 μs | 4.3879 μs |   7,082 B |         - |