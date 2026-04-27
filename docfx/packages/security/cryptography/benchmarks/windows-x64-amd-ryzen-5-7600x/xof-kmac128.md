| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.022 μs | 0.0170 μs | 0.0159 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   3.862 μs | 0.0205 μs | 0.0191 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.017 μs | 0.0343 μs | 0.0268 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.181 μs | 0.0280 μs | 0.0262 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   5.284 μs | 0.0226 μs | 0.0200 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   6.924 μs | 0.0334 μs | 0.0279 μs |    1280 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  12.274 μs | 0.0641 μs | 0.0600 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  15.270 μs | 0.0874 μs | 0.0775 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  20.427 μs | 0.1068 μs | 0.0946 μs |    9344 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 152.990 μs | 0.5088 μs | 0.4249 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 189.590 μs | 1.5164 μs | 1.3443 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 256.960 μs | 1.3968 μs | 1.3066 μs |  149888 B |