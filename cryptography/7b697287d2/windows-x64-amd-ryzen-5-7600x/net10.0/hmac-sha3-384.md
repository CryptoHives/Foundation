| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.103 μs | 0.0024 μs | 0.0022 μs |   6,973 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1.185 μs | 0.0036 μs | 0.0034 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.100 μs | 0.0020 μs | 0.0017 μs |   6,386 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1.186 μs | 0.0034 μs | 0.0030 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   2.997 μs | 0.0052 μs | 0.0044 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   3.876 μs | 0.0061 μs | 0.0057 μs |   6,922 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   3.010 μs | 0.0068 μs | 0.0063 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   3.885 μs | 0.0099 μs | 0.0093 μs |   6,916 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  18.602 μs | 0.0462 μs | 0.0432 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  27.867 μs | 0.0331 μs | 0.0309 μs |   6,930 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 286.187 μs | 0.8703 μs | 0.7267 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 437.564 μs | 0.5047 μs | 0.4474 μs |   6,922 B |         - |