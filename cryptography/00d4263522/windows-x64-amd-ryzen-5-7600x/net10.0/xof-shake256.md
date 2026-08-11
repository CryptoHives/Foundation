| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.325 μs | 0.0048 μs | 0.0038 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.101 μs | 0.0080 μs | 0.0071 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   5.109 μs | 0.0326 μs | 0.0254 μs |   7,003 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   4.728 μs | 0.0098 μs | 0.0087 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   5.819 μs | 0.0153 μs | 0.0128 μs |   2,723 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   7.238 μs | 0.0142 μs | 0.0118 μs |   7,033 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  15.401 μs | 0.1028 μs | 0.0859 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  18.838 μs | 0.0431 μs | 0.0337 μs |   2,723 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  23.744 μs | 0.1067 μs | 0.0946 μs |   7,026 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 196.819 μs | 0.8226 μs | 0.7292 μs |        NA |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 241.784 μs | 0.7250 μs | 0.6054 μs |   2,725 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 302.592 μs | 0.5787 μs | 0.4518 μs |   7,026 B |         - |