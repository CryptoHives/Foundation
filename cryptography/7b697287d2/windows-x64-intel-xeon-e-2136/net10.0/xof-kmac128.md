| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   6.359 μs | 0.0068 μs | 0.0064 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   9.129 μs | 0.0085 μs | 0.0080 μs |  14,633 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   9.192 μs | 0.0376 μs | 0.0351 μs |  10,739 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   8.745 μs | 0.0084 μs | 0.0078 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |  12.377 μs | 0.0158 μs | 0.0148 μs |  14,649 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |  12.543 μs | 0.0411 μs | 0.0384 μs |  10,729 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  25.386 μs | 0.0197 μs | 0.0184 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  35.270 μs | 0.0996 μs | 0.0883 μs |  14,694 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  36.473 μs | 0.0532 μs | 0.0498 μs |  11,364 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 314.723 μs | 0.2821 μs | 0.2639 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 432.691 μs | 0.7205 μs | 0.6740 μs |  14,685 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 451.307 μs | 0.3604 μs | 0.3010 μs |  11,326 B |      32 B |