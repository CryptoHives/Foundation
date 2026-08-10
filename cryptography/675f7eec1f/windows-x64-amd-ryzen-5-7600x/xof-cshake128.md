| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.677 μs | 0.0135 μs | 0.0120 μs |        NA |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   4.125 μs | 0.0270 μs | 0.0252 μs |   6,895 B |         - |
|                                                |              |            |           |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   3.868 μs | 0.0281 μs | 0.0263 μs |        NA |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   6.095 μs | 0.0390 μs | 0.0365 μs |   7,334 B |    1152 B |
|                                                |              |            |           |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |  12.194 μs | 0.0783 μs | 0.0654 μs |        NA |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  19.955 μs | 0.1174 μs | 0.1041 μs |   7,336 B |    9216 B |
|                                                |              |            |           |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 156.984 μs | 0.8542 μs | 0.7990 μs |        NA |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 263.097 μs | 1.9983 μs | 1.8692 μs |   7,333 B |  149760 B |