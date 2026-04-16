| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.334 μs | 0.0331 μs | 0.0293 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   3.973 μs | 0.0520 μs | 0.0486 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   4.922 μs | 0.0312 μs | 0.0277 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   5.257 μs | 0.0373 μs | 0.0348 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   5.689 μs | 0.1099 μs | 0.1028 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   7.159 μs | 0.0623 μs | 0.0520 μs |    1120 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  18.236 μs | 0.1301 μs | 0.1086 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  20.167 μs | 0.3372 μs | 0.3312 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  24.317 μs | 0.1946 μs | 0.1820 μs |    9600 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 234.121 μs | 1.7088 μs | 1.5148 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 273.913 μs | 5.2669 μs | 4.9266 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 319.335 μs | 2.0836 μs | 1.9490 μs |  154080 B |