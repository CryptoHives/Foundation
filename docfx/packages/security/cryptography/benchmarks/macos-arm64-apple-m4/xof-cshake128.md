| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128B         |   1.982 μs | 0.0014 μs | 0.0013 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   2.078 μs | 0.0069 μs | 0.0065 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.133 μs | 0.0058 μs | 0.0052 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   2.848 μs | 0.0026 μs | 0.0021 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   3.060 μs | 0.0032 μs | 0.0030 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   3.150 μs | 0.0060 μs | 0.0053 μs |    1152 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   8.856 μs | 0.0146 μs | 0.0122 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |   9.566 μs | 0.0147 μs | 0.0130 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  10.301 μs | 0.0352 μs | 0.0294 μs |    9216 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 113.493 μs | 0.0670 μs | 0.0523 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 123.085 μs | 0.3629 μs | 0.2833 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 132.800 μs | 0.3830 μs | 0.3198 μs |  149760 B |