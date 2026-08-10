| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128B         |   1.643 μs | 0.0056 μs | 0.0053 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   8.963 μs | 0.0476 μs | 0.0445 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.587 μs | 0.0369 μs | 0.0327 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 1KB          |   2.273 μs | 0.0104 μs | 0.0097 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |  12.444 μs | 0.0446 μs | 0.0417 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.572 μs | 0.0622 μs | 0.0582 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 8KB          |   7.312 μs | 0.0153 μs | 0.0143 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |  40.892 μs | 0.3356 μs | 0.3140 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  53.690 μs | 0.1873 μs | 0.1752 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128KB        |  93.569 μs | 0.3721 μs | 0.3480 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 525.172 μs | 2.7830 μs | 2.6032 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 686.210 μs | 2.5021 μs | 2.3405 μs |      56 B |