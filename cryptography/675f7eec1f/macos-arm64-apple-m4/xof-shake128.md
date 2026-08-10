| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 128B         |   1.969 μs | 0.0018 μs | 0.0016 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   2.082 μs | 0.0111 μs | 0.0104 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.110 μs | 0.0065 μs | 0.0058 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 1KB          |   2.839 μs | 0.0021 μs | 0.0019 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.047 μs | 0.0083 μs | 0.0073 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   3.250 μs | 0.0114 μs | 0.0107 μs |    1152 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 8KB          |   8.833 μs | 0.0260 μs | 0.0243 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |   9.507 μs | 0.0136 μs | 0.0127 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  10.114 μs | 0.0265 μs | 0.0248 μs |    9216 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Arm64  | 128KB        | 113.737 μs | 0.0628 μs | 0.0557 μs |         - |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 122.159 μs | 0.1188 μs | 0.1111 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 132.929 μs | 0.1858 μs | 0.1738 μs |  149760 B |