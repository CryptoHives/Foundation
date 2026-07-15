| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   3.714 μs | 0.0075 μs | 0.0067 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   4.705 μs | 0.0156 μs | 0.0139 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   6.044 μs | 0.0102 μs | 0.0085 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.106 μs | 0.0176 μs | 0.0156 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   6.410 μs | 0.0323 μs | 0.0302 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   8.347 μs | 0.0166 μs | 0.0148 μs |    1248 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  15.547 μs | 0.0178 μs | 0.0139 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  19.203 μs | 0.0269 μs | 0.0210 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  25.838 μs | 0.1143 μs | 0.1069 μs |    9728 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 194.628 μs | 0.6297 μs | 0.5258 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 237.354 μs | 0.4095 μs | 0.3830 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 327.998 μs | 1.6810 μs | 1.4901 μs |  154208 B |