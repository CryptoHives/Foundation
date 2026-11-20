| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   3.022 μs | 0.0099 μs | 0.0088 μs |   9,530 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.761 μs | 0.0235 μs | 0.0219 μs |  10,682 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.591 μs | 0.0113 μs | 0.0106 μs |   9,702 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   4.359 μs | 0.0158 μs | 0.0132 μs |   9,539 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   5.407 μs | 0.0129 μs | 0.0115 μs |   4,157 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   6.686 μs | 0.0401 μs | 0.0355 μs |  16,059 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  13.726 μs | 0.0218 μs | 0.0182 μs |   9,530 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  16.917 μs | 0.0344 μs | 0.0305 μs |   4,157 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  21.068 μs | 0.0740 μs | 0.0656 μs |   9,724 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 176.914 μs | 0.4961 μs | 0.4397 μs |  15,874 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 217.724 μs | 0.4949 μs | 0.4387 μs |  11,985 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 271.195 μs | 0.4591 μs | 0.4070 μs |  16,249 B |         - |