| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.267 μs | 0.0073 μs | 0.0061 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.034 μs | 0.0142 μs | 0.0119 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   5.037 μs | 0.0113 μs | 0.0106 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   4.653 μs | 0.0290 μs | 0.0242 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   5.722 μs | 0.0200 μs | 0.0177 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   7.370 μs | 0.0221 μs | 0.0207 μs |    1120 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  15.090 μs | 0.0314 μs | 0.0279 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  18.509 μs | 0.0694 μs | 0.0616 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  24.934 μs | 0.0360 μs | 0.0319 μs |    9600 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 193.528 μs | 0.9154 μs | 0.7147 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 236.260 μs | 0.5196 μs | 0.4861 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 324.650 μs | 0.5239 μs | 0.4090 μs |  154080 B |