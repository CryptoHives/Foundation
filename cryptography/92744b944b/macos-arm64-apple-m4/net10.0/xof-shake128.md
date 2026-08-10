| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   2.065 μs | 0.0051 μs | 0.0043 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.326 μs | 0.0073 μs | 0.0065 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   3.092 μs | 0.0108 μs | 0.0101 μs |    1152 B |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.883 μs | 0.0075 μs | 0.0067 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  10.055 μs | 0.0162 μs | 0.0143 μs |    9216 B |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  15.487 μs | 0.0248 μs | 0.0207 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 132.467 μs | 0.4133 μs | 0.3664 μs |  149760 B |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 216.277 μs | 0.3966 μs | 0.3710 μs |         - |