| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.687 μs | 0.0081 μs | 0.0068 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.355 μs | 0.0359 μs | 0.0336 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.136 μs | 0.0106 μs | 0.0094 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.871 μs | 0.0165 μs | 0.0155 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   4.793 μs | 0.0186 μs | 0.0165 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   6.119 μs | 0.0161 μs | 0.0143 μs |    1152 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  12.177 μs | 0.0547 μs | 0.0457 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  15.064 μs | 0.0399 μs | 0.0373 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  20.162 μs | 0.0759 μs | 0.0710 μs |    9216 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 156.634 μs | 0.4300 μs | 0.3591 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 193.863 μs | 0.5322 μs | 0.4444 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 265.473 μs | 0.7896 μs | 0.6593 μs |  149760 B |