| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   6.623 μs | 0.0140 μs | 0.0124 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   8.868 μs | 0.0166 μs | 0.0155 μs |   7,116 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   9.193 μs | 0.0423 μs | 0.0353 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   9.424 μs | 0.0297 μs | 0.0278 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |  12.690 μs | 0.0304 μs | 0.0284 μs |   7,153 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |  13.043 μs | 0.0624 μs | 0.0583 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  30.328 μs | 0.0173 μs | 0.0145 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  41.613 μs | 0.0820 μs | 0.0767 μs |   7,146 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  42.481 μs | 0.3061 μs | 0.2863 μs |   2,818 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 385.194 μs | 0.2101 μs | 0.1862 μs |   5,199 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 530.560 μs | 1.2071 μs | 1.1292 μs |   7,138 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 540.444 μs | 1.8511 μs | 1.6410 μs |   2,818 B |         - |