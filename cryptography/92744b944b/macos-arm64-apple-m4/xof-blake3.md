| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128B         |   1.641 μs | 0.0033 μs | 0.0030 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   8.997 μs | 0.0475 μs | 0.0444 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.582 μs | 0.0401 μs | 0.0356 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 1KB          |   2.266 μs | 0.0045 μs | 0.0042 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |  12.502 μs | 0.0375 μs | 0.0314 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.572 μs | 0.0842 μs | 0.0746 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 8KB          |   7.285 μs | 0.0071 μs | 0.0063 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |  40.677 μs | 0.2871 μs | 0.2545 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  53.862 μs | 0.6764 μs | 0.5648 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128KB        |  93.105 μs | 0.3192 μs | 0.2492 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 525.042 μs | 6.4389 μs | 5.3768 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 686.699 μs | 3.1645 μs | 2.6425 μs |      56 B |