| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   3.055 μs | 0.0116 μs | 0.0108 μs |   5,177 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.808 μs | 0.0061 μs | 0.0057 μs |   3,101 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.636 μs | 0.0261 μs | 0.0244 μs |   7,055 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   4.414 μs | 0.0319 μs | 0.0283 μs |   5,177 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   5.481 μs | 0.0705 μs | 0.0588 μs |   3,101 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   6.729 μs | 0.0357 μs | 0.0334 μs |   7,082 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  13.878 μs | 0.0388 μs | 0.0344 μs |   5,177 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  17.109 μs | 0.1259 μs | 0.1178 μs |   3,101 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  21.336 μs | 0.0835 μs | 0.0781 μs |   7,090 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 179.190 μs | 0.8412 μs | 0.7868 μs |   5,179 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 219.987 μs | 0.5552 μs | 0.4922 μs |   3,101 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 274.512 μs | 1.4362 μs | 1.2732 μs |   7,082 B |         - |