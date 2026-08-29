| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |   2.316 μs | 0.0031 μs | 0.0027 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.512 μs | 0.0065 μs | 0.0061 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.573 μs | 0.0079 μs | 0.0070 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |   3.203 μs | 0.0094 μs | 0.0088 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.445 μs | 0.0065 μs | 0.0058 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.445 μs | 0.0343 μs | 0.0321 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |   9.167 μs | 0.0404 μs | 0.0358 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |   9.687 μs | 0.0977 μs | 0.0866 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |   9.850 μs | 0.0292 μs | 0.0244 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 113.586 μs | 0.2490 μs | 0.2079 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 117.538 μs | 0.5686 μs | 0.4748 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 122.190 μs | 0.3205 μs | 0.2677 μs |         - |