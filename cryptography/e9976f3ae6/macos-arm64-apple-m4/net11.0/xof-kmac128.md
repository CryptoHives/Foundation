| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |   2.328 μs | 0.0062 μs | 0.0058 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.489 μs | 0.0052 μs | 0.0049 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.532 μs | 0.0077 μs | 0.0072 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |   3.193 μs | 0.0132 μs | 0.0123 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.434 μs | 0.0082 μs | 0.0077 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.513 μs | 0.0127 μs | 0.0119 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |   9.159 μs | 0.0254 μs | 0.0238 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |   9.665 μs | 0.0341 μs | 0.0302 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |   9.970 μs | 0.0377 μs | 0.0353 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 114.391 μs | 0.2470 μs | 0.2311 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 118.548 μs | 0.4961 μs | 0.4640 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 123.717 μs | 0.3654 μs | 0.3418 μs |         - |