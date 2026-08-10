| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.772 μs | 0.0403 μs | 0.0358 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.292 μs | 0.0311 μs | 0.0291 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.087 μs | 0.0755 μs | 0.0707 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   4.544 μs | 0.0827 μs | 0.1015 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   4.796 μs | 0.0936 μs | 0.1485 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   6.017 μs | 0.0746 μs | 0.0698 μs |    1152 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  15.039 μs | 0.2545 μs | 0.2256 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  17.317 μs | 0.3356 μs | 0.3446 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  19.959 μs | 0.3989 μs | 0.4749 μs |    9216 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 191.658 μs | 2.5788 μs | 2.4122 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 236.344 μs | 2.7841 μs | 2.6043 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 255.234 μs | 2.1568 μs | 1.8011 μs |  149760 B |