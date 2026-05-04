| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.614 μs | 0.0200 μs | 0.0187 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.266 μs | 0.0343 μs | 0.0304 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.038 μs | 0.0191 μs | 0.0178 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.779 μs | 0.0222 μs | 0.0208 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   4.681 μs | 0.0289 μs | 0.0256 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   5.980 μs | 0.0512 μs | 0.0428 μs |    1152 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  11.886 μs | 0.0459 μs | 0.0407 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  14.797 μs | 0.1038 μs | 0.0920 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  19.520 μs | 0.1391 μs | 0.1301 μs |    9216 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 153.131 μs | 1.0075 μs | 0.8931 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 189.887 μs | 2.2975 μs | 2.0367 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 255.651 μs | 1.5554 μs | 1.4549 μs |  149760 B |