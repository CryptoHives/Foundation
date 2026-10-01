| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   4.167 μs | 0.0107 μs | 0.0100 μs |   7,047 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   5.235 μs | 0.0148 μs | 0.0138 μs |  11,314 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   6.775 μs | 0.0128 μs | 0.0113 μs |  17,674 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.714 μs | 0.0087 μs | 0.0081 μs |   7,056 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   7.133 μs | 0.0128 μs | 0.0120 μs |  11,316 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   9.164 μs | 0.0172 μs | 0.0161 μs |  16,563 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  17.496 μs | 0.0490 μs | 0.0458 μs |   7,054 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  21.702 μs | 0.2928 μs | 0.4104 μs |  10,697 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  27.394 μs | 0.0343 μs | 0.0287 μs |  17,767 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 218.358 μs | 0.3644 μs | 0.3409 μs |   7,052 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 267.035 μs | 0.7878 μs | 0.6984 μs |  11,281 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 335.791 μs | 0.5851 μs | 0.5473 μs |  17,768 B |     128 B |