| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.700 μs | 0.0084 μs | 0.0074 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.341 μs | 0.0032 μs | 0.0025 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.065 μs | 0.0053 μs | 0.0041 μs |   6,967 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.864 μs | 0.0040 μs | 0.0031 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   4.806 μs | 0.0175 μs | 0.0146 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   5.886 μs | 0.0132 μs | 0.0117 μs |   6,994 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  12.180 μs | 0.0229 μs | 0.0203 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  15.061 μs | 0.0240 μs | 0.0200 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  18.647 μs | 0.0333 μs | 0.0278 μs |   7,002 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 156.760 μs | 0.2445 μs | 0.2042 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 193.815 μs | 0.4494 μs | 0.3984 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 241.728 μs | 0.4545 μs | 0.4251 μs |   6,994 B |         - |