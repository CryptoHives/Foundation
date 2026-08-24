| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.729 μs | 0.0029 μs | 0.0028 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.936 μs | 0.0080 μs | 0.0075 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   2.985 μs | 0.0104 μs | 0.0098 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   4.627 μs | 0.0925 μs | 0.2372 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |  19.017 μs | 0.1552 μs | 0.1376 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |  19.221 μs | 0.0967 μs | 0.0808 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  53.410 μs | 0.3465 μs | 0.3072 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  56.134 μs | 0.9566 μs | 0.8948 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  57.099 μs | 0.2456 μs | 0.2297 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 138.922 μs | 0.0893 μs | 0.1280 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 145.230 μs | 1.4346 μs | 1.2717 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 149.850 μs | 0.3013 μs | 0.2671 μs |         - |