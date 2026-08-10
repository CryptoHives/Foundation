| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128B         |   1.982 μs | 0.0022 μs | 0.0020 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   2.082 μs | 0.0107 μs | 0.0095 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.112 μs | 0.0049 μs | 0.0046 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   2.843 μs | 0.0100 μs | 0.0093 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   3.040 μs | 0.0039 μs | 0.0037 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   3.098 μs | 0.0058 μs | 0.0054 μs |    1152 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   8.839 μs | 0.0282 μs | 0.0264 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |   9.473 μs | 0.0134 μs | 0.0119 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  10.120 μs | 0.0139 μs | 0.0123 μs |    9216 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 113.599 μs | 0.2614 μs | 0.2445 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 121.783 μs | 0.1872 μs | 0.1659 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 132.951 μs | 0.2446 μs | 0.2288 μs |  149760 B |