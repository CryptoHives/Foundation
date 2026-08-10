| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128B         |   2.412 μs | 0.0028 μs | 0.0026 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   2.503 μs | 0.0060 μs | 0.0051 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   2.567 μs | 0.0015 μs | 0.0013 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 1KB          |   3.407 μs | 0.0038 μs | 0.0035 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   3.649 μs | 0.0023 μs | 0.0021 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   3.676 μs | 0.0094 μs | 0.0083 μs |    1120 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 8KB          |  10.880 μs | 0.0063 μs | 0.0059 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  11.709 μs | 0.0087 μs | 0.0081 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  12.484 μs | 0.0267 μs | 0.0250 μs |    9600 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128KB        | 138.554 μs | 0.0577 μs | 0.0511 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 149.217 μs | 0.3072 μs | 0.2723 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 159.717 μs | 0.2820 μs | 0.2638 μs |  154080 B |