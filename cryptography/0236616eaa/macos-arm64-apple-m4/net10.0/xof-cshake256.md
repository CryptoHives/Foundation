| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Median     | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|-----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   2.945 μs | 0.0276 μs | 0.0244 μs |   2.942 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 128B         |   3.087 μs | 0.0608 μs | 0.1143 μs |   3.066 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   3.178 μs | 0.0626 μs | 0.0791 μs |   3.209 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 1KB          |  15.344 μs | 1.0250 μs | 3.0063 μs |  16.197 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |  16.369 μs | 0.0363 μs | 0.0283 μs |  16.361 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |  17.293 μs | 0.1070 μs | 0.1001 μs |  17.235 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 8KB          |  10.945 μs | 0.0807 μs | 0.0755 μs |  10.896 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  11.371 μs | 0.0783 μs | 0.0654 μs |  11.359 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  11.753 μs | 0.0327 μs | 0.0290 μs |  11.743 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 138.544 μs | 0.0703 μs | 0.0658 μs | 138.553 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 144.314 μs | 1.3861 μs | 1.2966 μs | 143.480 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 149.547 μs | 0.3318 μs | 0.3103 μs | 149.483 μs |         - |