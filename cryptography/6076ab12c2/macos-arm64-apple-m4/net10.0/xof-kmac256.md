| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.768 μs | 0.0026 μs | 0.0022 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.977 μs | 0.0057 μs | 0.0054 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   3.012 μs | 0.0100 μs | 0.0089 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   3.781 μs | 0.0028 μs | 0.0025 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.060 μs | 0.0169 μs | 0.0158 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.085 μs | 0.0069 μs | 0.0064 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  11.380 μs | 0.0069 μs | 0.0061 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  12.007 μs | 0.0544 μs | 0.0482 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  12.316 μs | 0.0091 μs | 0.0081 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 141.141 μs | 0.1093 μs | 0.0968 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 146.353 μs | 0.6603 μs | 0.5514 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 152.473 μs | 0.1176 μs | 0.0982 μs |         - |