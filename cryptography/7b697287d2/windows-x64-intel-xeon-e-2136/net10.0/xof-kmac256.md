| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   5.662 μs | 0.0085 μs | 0.0075 μs |   7,313 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   7.973 μs | 0.0260 μs | 0.0244 μs |  10,732 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   8.068 μs | 0.0264 μs | 0.0234 μs |  17,760 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   7.776 μs | 0.0318 μs | 0.0298 μs |   7,316 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |  10.892 μs | 0.0386 μs | 0.0361 μs |  11,364 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |  10.927 μs | 0.0465 μs | 0.0435 μs |  17,760 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  23.445 μs | 0.0611 μs | 0.0572 μs |   7,316 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  32.544 μs | 0.0977 μs | 0.0914 μs |  17,848 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  32.979 μs | 0.2397 μs | 0.2243 μs |  10,732 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 290.738 μs | 1.3732 μs | 1.2173 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 399.371 μs | 1.2745 μs | 1.1922 μs |  17,837 B |     128 B |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 404.157 μs | 1.9787 μs | 1.8509 μs |  11,329 B |      32 B |