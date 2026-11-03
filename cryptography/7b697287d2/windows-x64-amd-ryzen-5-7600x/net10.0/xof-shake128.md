| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   3.009 μs | 0.0065 μs | 0.0061 μs |   5,177 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.736 μs | 0.0050 μs | 0.0044 μs |   3,099 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.574 μs | 0.0118 μs | 0.0110 μs |   7,055 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   4.340 μs | 0.0094 μs | 0.0083 μs |   5,177 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   5.372 μs | 0.0141 μs | 0.0132 μs |   3,101 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   6.635 μs | 0.0070 μs | 0.0062 μs |   7,082 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  13.713 μs | 0.0227 μs | 0.0213 μs |   5,179 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  16.942 μs | 0.0360 μs | 0.0337 μs |   3,101 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  20.991 μs | 0.0311 μs | 0.0276 μs |   7,082 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 176.669 μs | 0.4747 μs | 0.4208 μs |   5,179 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 217.404 μs | 0.3186 μs | 0.2660 μs |   3,099 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 272.393 μs | 0.6522 μs | 0.6101 μs |   7,082 B |         - |