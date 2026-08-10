| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.748 μs | 0.0038 μs | 0.0035 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.933 μs | 0.0066 μs | 0.0062 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   3.061 μs | 0.0113 μs | 0.0106 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   3.745 μs | 0.0117 μs | 0.0109 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   3.990 μs | 0.0067 μs | 0.0052 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.212 μs | 0.0086 μs | 0.0080 μs |    1248 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  11.272 μs | 0.0232 μs | 0.0217 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  12.072 μs | 0.0334 μs | 0.0312 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  12.911 μs | 0.0207 μs | 0.0193 μs |    9728 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 140.032 μs | 0.0886 μs | 0.0828 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 149.591 μs | 0.4339 μs | 0.3847 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 161.139 μs | 0.4250 μs | 0.3975 μs |  154208 B |