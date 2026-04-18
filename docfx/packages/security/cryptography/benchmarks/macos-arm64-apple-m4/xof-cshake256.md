| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   2.511 μs | 0.0128 μs | 0.0114 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   2.797 μs | 0.0239 μs | 0.0212 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |   3.684 μs | 0.0114 μs | 0.0101 μs |    1120 B |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |   4.480 μs | 0.0055 μs | 0.0049 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  12.306 μs | 0.0216 μs | 0.0192 μs |    9600 B |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  17.684 μs | 0.0243 μs | 0.0227 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 161.864 μs | 1.7823 μs | 1.4883 μs |  154080 B |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 242.995 μs | 0.2432 μs | 0.2275 μs |         - |