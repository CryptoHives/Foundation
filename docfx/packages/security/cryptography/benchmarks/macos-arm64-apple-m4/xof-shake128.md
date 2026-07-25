| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 128B         |   1.955 μs | 0.0024 μs | 0.0022 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   2.061 μs | 0.0036 μs | 0.0030 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.103 μs | 0.0029 μs | 0.0024 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 1KB          |   2.819 μs | 0.0011 μs | 0.0009 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.022 μs | 0.0030 μs | 0.0029 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   3.072 μs | 0.0050 μs | 0.0046 μs |    1152 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 8KB          |   8.785 μs | 0.0026 μs | 0.0024 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |   9.422 μs | 0.0053 μs | 0.0045 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  10.057 μs | 0.0150 μs | 0.0140 μs |    9216 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 128KB        | 112.832 μs | 0.0318 μs | 0.0297 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 121.255 μs | 0.1609 μs | 0.1505 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 132.261 μs | 0.1873 μs | 0.1752 μs |  149760 B |