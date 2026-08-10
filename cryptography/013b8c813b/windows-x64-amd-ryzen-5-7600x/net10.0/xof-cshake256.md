| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   3.285 μs | 0.0116 μs | 0.0097 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   5.052 μs | 0.0087 μs | 0.0077 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |   4.657 μs | 0.0126 μs | 0.0105 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |   7.341 μs | 0.0063 μs | 0.0052 μs |    1120 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  15.182 μs | 0.0339 μs | 0.0283 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  24.960 μs | 0.0967 μs | 0.0905 μs |    9600 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 193.947 μs | 0.5995 μs | 0.5314 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 327.406 μs | 0.5018 μs | 0.4694 μs |  154080 B |