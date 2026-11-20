| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   4.184 μs | 0.0111 μs | 0.0093 μs |  17,808 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   5.284 μs | 0.0154 μs | 0.0128 μs |  16,512 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   6.766 μs | 0.0094 μs | 0.0078 μs |  27,647 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.758 μs | 0.0250 μs | 0.0208 μs |  18,007 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   7.198 μs | 0.0349 μs | 0.0309 μs |   9,767 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   9.158 μs | 0.0205 μs | 0.0192 μs |  27,482 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  17.634 μs | 0.0500 μs | 0.0468 μs |  17,808 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  21.764 μs | 0.0927 μs | 0.0822 μs |  16,508 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  27.457 μs | 0.0413 μs | 0.0344 μs |  21,144 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 219.420 μs | 0.5198 μs | 0.4608 μs |  11,482 B |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 268.986 μs | 0.8665 μs | 0.7681 μs |  20,932 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 338.552 μs | 0.7664 μs | 0.6793 μs |  21,109 B |     128 B |