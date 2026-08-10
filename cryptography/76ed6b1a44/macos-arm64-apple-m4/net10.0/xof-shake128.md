| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 128B         |   1.986 μs | 0.0022 μs | 0.0021 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   2.077 μs | 0.0034 μs | 0.0030 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.115 μs | 0.0051 μs | 0.0043 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 1KB          |   2.853 μs | 0.0010 μs | 0.0008 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.032 μs | 0.0034 μs | 0.0032 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   3.095 μs | 0.0071 μs | 0.0067 μs |    1152 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 8KB          |   8.868 μs | 0.0067 μs | 0.0063 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |   9.669 μs | 0.0739 μs | 0.0691 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  10.236 μs | 0.1461 μs | 0.1367 μs |    9216 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 128KB        | 113.853 μs | 0.1921 μs | 0.1796 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 121.735 μs | 0.1942 μs | 0.1622 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 133.084 μs | 0.4793 μs | 0.3742 μs |  149760 B |