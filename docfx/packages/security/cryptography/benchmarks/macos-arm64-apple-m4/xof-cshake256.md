| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 128B         |   2.446 μs | 0.0075 μs | 0.0067 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   2.520 μs | 0.0034 μs | 0.0029 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   2.584 μs | 0.0039 μs | 0.0032 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   3.448 μs | 0.0091 μs | 0.0080 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |   3.658 μs | 0.0064 μs | 0.0057 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |   3.674 μs | 0.0141 μs | 0.0125 μs |    1120 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 8KB          |  10.965 μs | 0.0306 μs | 0.0286 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  11.738 μs | 0.0137 μs | 0.0115 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  12.356 μs | 0.0113 μs | 0.0106 μs |    9600 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 139.691 μs | 0.0788 μs | 0.0737 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 149.642 μs | 0.6457 μs | 0.5724 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 160.356 μs | 0.3127 μs | 0.2925 μs |  154080 B |