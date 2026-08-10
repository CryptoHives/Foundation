| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   3.272 μs | 0.0376 μs | 0.0314 μs |        NA |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   5.013 μs | 0.0389 μs | 0.0345 μs |   6,891 B |         - |
|                                                |              |            |           |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |   4.630 μs | 0.0351 μs | 0.0311 μs |        NA |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |   7.289 μs | 0.0539 μs | 0.0478 μs |   7,327 B |    1120 B |
|                                                |              |            |           |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  15.028 μs | 0.0803 μs | 0.0712 μs |        NA |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  24.840 μs | 0.1794 μs | 0.1678 μs |   7,332 B |    9600 B |
|                                                |              |            |           |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 192.227 μs | 1.4095 μs | 1.2495 μs |        NA |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 320.586 μs | 1.4376 μs | 1.2004 μs |   7,325 B |  154080 B |