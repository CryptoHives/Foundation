| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128B         |   2.427 μs | 0.0033 μs | 0.0029 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   2.540 μs | 0.0093 μs | 0.0077 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   2.580 μs | 0.0045 μs | 0.0037 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 1KB          |   3.432 μs | 0.0051 μs | 0.0048 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   3.676 μs | 0.0039 μs | 0.0035 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   3.774 μs | 0.0105 μs | 0.0098 μs |    1120 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 8KB          |  10.959 μs | 0.0211 μs | 0.0197 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  11.793 μs | 0.0254 μs | 0.0238 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  12.536 μs | 0.0167 μs | 0.0156 μs |    9600 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128KB        | 139.547 μs | 0.3160 μs | 0.2956 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 150.416 μs | 0.1961 μs | 0.1835 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 160.313 μs | 0.4428 μs | 0.4142 μs |  154080 B |