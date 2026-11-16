| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.100 μs | 0.0016 μs | 0.0012 μs |   6,392 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1.185 μs | 0.0027 μs | 0.0024 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.102 μs | 0.0016 μs | 0.0013 μs |   6,386 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1.187 μs | 0.0023 μs | 0.0022 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   2.998 μs | 0.0046 μs | 0.0039 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   3.881 μs | 0.0033 μs | 0.0029 μs |   6,924 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   2.996 μs | 0.0047 μs | 0.0039 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   3.892 μs | 0.0084 μs | 0.0070 μs |   6,914 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  18.607 μs | 0.0253 μs | 0.0211 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  27.881 μs | 0.0543 μs | 0.0454 μs |   6,925 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 286.437 μs | 0.8123 μs | 0.6783 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 439.433 μs | 0.5393 μs | 0.4781 μs |   6,914 B |         - |