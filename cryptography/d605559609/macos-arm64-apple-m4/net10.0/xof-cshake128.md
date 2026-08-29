| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Median     | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|-----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   2.015 μs | 0.0236 μs | 0.0197 μs |   2.006 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128B         |   2.053 μs | 0.0410 μs | 0.1029 μs |   1.991 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.116 μs | 0.0054 μs | 0.0048 μs |   2.115 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   2.852 μs | 0.0126 μs | 0.0105 μs |   2.847 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   2.907 μs | 0.0219 μs | 0.0205 μs |   2.897 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   3.040 μs | 0.0076 μs | 0.0067 μs |   3.039 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   8.818 μs | 0.0048 μs | 0.0043 μs |   8.818 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |   9.147 μs | 0.0972 μs | 0.0862 μs |   9.117 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |   9.461 μs | 0.0146 μs | 0.0114 μs |   9.458 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 113.005 μs | 0.1180 μs | 0.0985 μs | 112.984 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 117.496 μs | 0.8521 μs | 0.7971 μs | 117.442 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 121.585 μs | 0.1983 μs | 0.1854 μs | 121.612 μs |         - |