| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128B         |   2.743 μs | 0.0023 μs | 0.0021 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   2.936 μs | 0.0064 μs | 0.0060 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   2.972 μs | 0.0107 μs | 0.0095 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 1KB          |   3.743 μs | 0.0033 μs | 0.0031 μs |         - |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.014 μs | 0.0136 μs | 0.0128 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   4.426 μs | 0.0437 μs | 0.0409 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 8KB          |  11.222 μs | 0.0084 μs | 0.0074 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  11.832 μs | 0.1123 μs | 0.1050 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  12.153 μs | 0.0227 μs | 0.0212 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Arm64  | 128KB        | 138.921 μs | 0.0906 μs | 0.0848 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 145.312 μs | 1.5633 μs | 1.4623 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 150.862 μs | 0.2087 μs | 0.1850 μs |         - |