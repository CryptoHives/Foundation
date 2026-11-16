| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |   2.340 μs | 0.0070 μs | 0.0065 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.489 μs | 0.0062 μs | 0.0055 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.564 μs | 0.0101 μs | 0.0089 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |   3.217 μs | 0.0113 μs | 0.0105 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.419 μs | 0.0084 μs | 0.0079 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.454 μs | 0.0099 μs | 0.0093 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |   9.272 μs | 0.0218 μs | 0.0204 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |   9.722 μs | 0.0630 μs | 0.0589 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |   9.936 μs | 0.0310 μs | 0.0275 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 114.921 μs | 0.5346 μs | 0.5001 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 118.873 μs | 0.3104 μs | 0.2904 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 123.464 μs | 0.3404 μs | 0.3184 μs |         - |