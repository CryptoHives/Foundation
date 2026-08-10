| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 128B         |   2.424 μs | 0.0066 μs | 0.0051 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   2.540 μs | 0.0137 μs | 0.0114 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   2.606 μs | 0.0043 μs | 0.0036 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   3.432 μs | 0.0076 μs | 0.0067 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |   3.692 μs | 0.0158 μs | 0.0140 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |   3.739 μs | 0.0081 μs | 0.0063 μs |    1120 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 8KB          |  10.933 μs | 0.0064 μs | 0.0054 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  11.858 μs | 0.0157 μs | 0.0139 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  12.575 μs | 0.0566 μs | 0.0442 μs |    9600 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 139.921 μs | 0.6292 μs | 0.5254 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 151.094 μs | 0.2513 μs | 0.1962 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 162.368 μs | 0.2855 μs | 0.2531 μs |  154080 B |