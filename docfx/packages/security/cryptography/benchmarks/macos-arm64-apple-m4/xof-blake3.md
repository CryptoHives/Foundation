| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128B         |   1.645 μs | 0.0005 μs | 0.0004 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   8.999 μs | 0.0288 μs | 0.0269 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.601 μs | 0.0301 μs | 0.0282 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 1KB          |   2.272 μs | 0.0010 μs | 0.0009 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |  12.575 μs | 0.0529 μs | 0.0495 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.634 μs | 0.0511 μs | 0.0478 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 8KB          |   7.289 μs | 0.0019 μs | 0.0016 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |  41.347 μs | 0.2597 μs | 0.2430 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  53.794 μs | 0.1565 μs | 0.1464 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128KB        |  93.201 μs | 0.0350 μs | 0.0292 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 530.956 μs | 3.0235 μs | 2.8282 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 687.648 μs | 2.0443 μs | 1.9122 μs |      56 B |