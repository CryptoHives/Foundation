| Description                                   | TestDataSize | Mean      | Error    | StdDev   | Allocated |
|---------------------------------------------- |------------- |----------:|---------:|---------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |  10.84 μs | 0.066 μs | 0.062 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |  11.63 μs | 0.062 μs | 0.058 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |  11.90 μs | 0.043 μs | 0.041 μs |     128 B |
|                                               |              |           |          |          |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |  14.91 μs | 0.031 μs | 0.026 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |  15.99 μs | 0.041 μs | 0.038 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |  16.56 μs | 0.168 μs | 0.149 μs |     128 B |
|                                               |              |           |          |          |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |  43.39 μs | 0.218 μs | 0.204 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  45.44 μs | 0.394 μs | 0.350 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  46.34 μs | 0.234 μs | 0.219 μs |         - |
|                                               |              |           |          |          |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 117.44 μs | 0.714 μs | 0.633 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 122.45 μs | 1.102 μs | 1.031 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 539.81 μs | 4.662 μs | 4.361 μs |         - |