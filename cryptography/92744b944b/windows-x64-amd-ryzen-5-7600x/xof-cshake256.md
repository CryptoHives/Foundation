| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   3.316 μs | 0.0112 μs | 0.0104 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   4.915 μs | 0.0330 μs | 0.0309 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |   5.245 μs | 0.0358 μs | 0.0299 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |   7.151 μs | 0.0306 μs | 0.0287 μs |    1120 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  19.923 μs | 0.0970 μs | 0.0860 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  24.214 μs | 0.1118 μs | 0.1046 μs |    9600 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 270.663 μs | 0.9881 μs | 0.8759 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 316.950 μs | 1.3381 μs | 1.1862 μs |  154080 B |