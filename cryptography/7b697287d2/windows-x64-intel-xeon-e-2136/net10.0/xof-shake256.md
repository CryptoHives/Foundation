| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   6.624 μs | 0.0056 μs | 0.0043 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   8.864 μs | 0.0073 μs | 0.0064 μs |   7,121 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   9.185 μs | 0.0192 μs | 0.0179 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   9.420 μs | 0.0111 μs | 0.0104 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |  12.674 μs | 0.0137 μs | 0.0128 μs |   7,148 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |  13.032 μs | 0.0317 μs | 0.0281 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  30.297 μs | 0.0204 μs | 0.0191 μs |   5,203 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  41.453 μs | 0.0401 μs | 0.0335 μs |   7,138 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  42.146 μs | 0.1081 μs | 0.0903 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 385.760 μs | 0.1846 μs | 0.1637 μs |   5,199 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 530.284 μs | 0.4354 μs | 0.3860 μs |   7,138 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 537.683 μs | 1.1719 μs | 1.0389 μs |   2,818 B |         - |