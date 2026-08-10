| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128B         |   1.961 μs | 0.0022 μs | 0.0021 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   2.074 μs | 0.0032 μs | 0.0028 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.097 μs | 0.0043 μs | 0.0038 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   2.821 μs | 0.0015 μs | 0.0014 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   3.014 μs | 0.0062 μs | 0.0058 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   3.075 μs | 0.0069 μs | 0.0065 μs |    1152 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   8.789 μs | 0.0032 μs | 0.0025 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |   9.403 μs | 0.0234 μs | 0.0219 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  10.058 μs | 0.0145 μs | 0.0128 μs |    9216 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 112.845 μs | 0.0452 μs | 0.0401 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 120.932 μs | 0.1758 μs | 0.1644 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 132.125 μs | 0.1888 μs | 0.1766 μs |  149760 B |