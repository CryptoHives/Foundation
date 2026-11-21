| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.758 μs | 0.0075 μs | 0.0067 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.964 μs | 0.0091 μs | 0.0085 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   2.988 μs | 0.0082 μs | 0.0073 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   3.773 μs | 0.0088 μs | 0.0082 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.005 μs | 0.0117 μs | 0.0097 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.039 μs | 0.0093 μs | 0.0083 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  11.336 μs | 0.0454 μs | 0.0425 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  11.914 μs | 0.0342 μs | 0.0304 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  12.228 μs | 0.0176 μs | 0.0165 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 140.806 μs | 0.3514 μs | 0.3287 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 146.377 μs | 1.1217 μs | 0.9944 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 151.744 μs | 0.4636 μs | 0.4337 μs |         - |