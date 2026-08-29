| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.297 μs | 0.0232 μs | 0.0194 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.079 μs | 0.0132 μs | 0.0124 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   5.013 μs | 0.0152 μs | 0.0134 μs |   7,008 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   4.683 μs | 0.0317 μs | 0.0248 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   5.808 μs | 0.0128 μs | 0.0120 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   7.132 μs | 0.0220 μs | 0.0195 μs |   7,024 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  15.273 μs | 0.2070 μs | 0.2033 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  18.747 μs | 0.0693 μs | 0.0579 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  23.256 μs | 0.0521 μs | 0.0462 μs |   7,022 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 195.272 μs | 3.1836 μs | 2.4855 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 239.209 μs | 0.7339 μs | 0.6128 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 300.529 μs | 0.4710 μs | 0.3933 μs |   7,026 B |         - |