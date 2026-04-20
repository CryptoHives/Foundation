| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128B         |   2.423 μs | 0.0025 μs | 0.0023 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   2.528 μs | 0.0167 μs | 0.0156 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   2.577 μs | 0.0072 μs | 0.0063 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 1KB          |   3.427 μs | 0.0027 μs | 0.0024 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   3.648 μs | 0.0039 μs | 0.0035 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   3.754 μs | 0.0082 μs | 0.0073 μs |    1120 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 8KB          |  10.933 μs | 0.0063 μs | 0.0053 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  11.730 μs | 0.0188 μs | 0.0176 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  12.515 μs | 0.0292 μs | 0.0273 μs |    9600 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128KB        | 139.331 μs | 0.1048 μs | 0.0929 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 149.582 μs | 0.2771 μs | 0.2314 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 161.799 μs | 0.2561 μs | 0.2271 μs |  154080 B |