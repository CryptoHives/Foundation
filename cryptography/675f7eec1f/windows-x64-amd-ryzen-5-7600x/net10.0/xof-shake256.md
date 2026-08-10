| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.262 μs | 0.0273 μs | 0.0255 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.030 μs | 0.0209 μs | 0.0185 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   5.016 μs | 0.0399 μs | 0.0373 μs |   6,828 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   4.635 μs | 0.0399 μs | 0.0354 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   5.737 μs | 0.0486 μs | 0.0431 μs |   2,723 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   7.295 μs | 0.0543 μs | 0.0508 μs |   7,264 B |    1120 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  15.101 μs | 0.0892 μs | 0.0745 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  18.535 μs | 0.1131 μs | 0.1058 μs |   2,723 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  24.701 μs | 0.2165 μs | 0.1919 μs |   7,264 B |    9600 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 193.443 μs | 1.2049 μs | 1.0681 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 236.898 μs | 1.2216 μs | 1.0201 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 322.691 μs | 2.3341 μs | 2.1833 μs |   7,257 B |  154080 B |