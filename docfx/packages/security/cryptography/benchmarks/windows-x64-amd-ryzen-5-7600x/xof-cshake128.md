| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Median     | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|-----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.731 μs | 0.0523 μs | 0.0463 μs |   2.709 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   4.214 μs | 0.0790 μs | 0.1577 μs |   4.148 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   3.871 μs | 0.0059 μs | 0.0049 μs |   3.871 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   6.133 μs | 0.0133 μs | 0.0125 μs |   6.132 μs |    1152 B |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |  12.224 μs | 0.0207 μs | 0.0183 μs |  12.222 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  20.051 μs | 0.0329 μs | 0.0291 μs |  20.052 μs |    9216 B |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 158.105 μs | 0.2474 μs | 0.2193 μs | 158.125 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 267.169 μs | 1.0695 μs | 1.0004 μs | 266.886 μs |  149760 B |