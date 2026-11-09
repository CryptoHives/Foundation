| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   4.796 μs | 0.0203 μs | 0.0190 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   6.792 μs | 0.0278 μs | 0.0217 μs |  11,326 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   6.831 μs | 0.0206 μs | 0.0183 μs |  14,623 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   6.577 μs | 0.0341 μs | 0.0319 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   9.305 μs | 0.0287 μs | 0.0268 μs |  14,648 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   9.400 μs | 0.0309 μs | 0.0289 μs |  11,364 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  19.073 μs | 0.0653 μs | 0.0579 μs |   7,314 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  26.386 μs | 0.0850 μs | 0.0796 μs |  14,670 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  27.344 μs | 0.0981 μs | 0.0917 μs |  10,732 B |      32 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 236.117 μs | 0.6392 μs | 0.5666 μs |   7,312 B |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 324.696 μs | 1.0343 μs | 0.9169 μs |  14,685 B |     128 B |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 336.945 μs | 0.7886 μs | 0.6585 μs |  11,364 B |      32 B |