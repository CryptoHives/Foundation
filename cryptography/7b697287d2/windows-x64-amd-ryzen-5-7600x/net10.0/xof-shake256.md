| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.674 μs | 0.0060 μs | 0.0053 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.515 μs | 0.0092 μs | 0.0086 μs |   2,811 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   5.620 μs | 0.0058 μs | 0.0055 μs |   7,091 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   5.315 μs | 0.0134 μs | 0.0119 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   6.476 μs | 0.0069 μs | 0.0061 μs |   2,813 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   8.034 μs | 0.0216 μs | 0.0202 μs |   7,114 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  17.002 μs | 0.0285 μs | 0.0253 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  20.839 μs | 0.0532 μs | 0.0472 μs |   2,813 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  26.074 μs | 0.0288 μs | 0.0269 μs |   7,114 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 217.193 μs | 0.4840 μs | 0.4527 μs |   5,179 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 266.409 μs | 0.7343 μs | 0.6869 μs |   2,811 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 334.965 μs | 0.6241 μs | 0.5838 μs |   7,114 B |         - |