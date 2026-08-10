| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   3.183 μs | 0.0157 μs | 0.0139 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   4.908 μs | 0.0226 μs | 0.0211 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |   4.525 μs | 0.0328 μs | 0.0307 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |   7.109 μs | 0.0296 μs | 0.0247 μs |    1120 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  14.678 μs | 0.0494 μs | 0.0462 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  24.327 μs | 0.0797 μs | 0.0665 μs |    9600 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 187.876 μs | 0.5233 μs | 0.4370 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 314.991 μs | 1.1409 μs | 1.0114 μs |  154080 B |