| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1.351 μs | 0.0014 μs | 0.0012 μs |   5,541 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |   1.651 μs | 0.0031 μs | 0.0029 μs |   3,002 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1.691 μs | 0.0022 μs | 0.0020 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1.351 μs | 0.0020 μs | 0.0018 μs |   5,541 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |   1.651 μs | 0.0063 μs | 0.0059 μs |   3,002 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1.696 μs | 0.0034 μs | 0.0027 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   3.677 μs | 0.0039 μs | 0.0036 μs |   5,566 B |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   3.954 μs | 0.0098 μs | 0.0091 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   5.265 μs | 0.0056 μs | 0.0050 μs |   2,991 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   3.678 μs | 0.0036 μs | 0.0034 μs |   5,566 B |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   3.964 μs | 0.0137 μs | 0.0115 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   5.273 μs | 0.0100 μs | 0.0089 μs |   2,991 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  21.424 μs | 0.0482 μs | 0.0427 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  21.736 μs | 0.0171 μs | 0.0152 μs |   5,583 B |    8480 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  34.480 μs | 0.0416 μs | 0.0368 μs |   2,997 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 321.955 μs | 0.7768 μs | 0.6487 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 396.315 μs | 0.2323 μs | 0.2059 μs |   5,583 B |  131374 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 533.959 μs | 1.0193 μs | 0.8511 μs |   2,991 B |         - |