| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   4.150 μs | 0.0774 μs | 0.0724 μs |   5,197 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   5.491 μs | 0.0917 μs | 0.0857 μs |   7,088 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   5.761 μs | 0.1036 μs | 0.0969 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   5.979 μs | 0.1030 μs | 0.0964 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   8.036 μs | 0.1126 μs | 0.1054 μs |   7,118 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   8.383 μs | 0.1070 μs | 0.1001 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  18.637 μs | 0.2831 μs | 0.2648 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  25.389 μs | 0.2999 μs | 0.2805 μs |   7,119 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  26.586 μs | 0.3998 μs | 0.3740 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 238.377 μs | 3.8626 μs | 3.6131 μs |   5,199 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 326.582 μs | 5.3731 μs | 5.0260 μs |   7,106 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 341.565 μs | 4.6877 μs | 4.3849 μs |   3,105 B |         - |