| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1.017 μs | 0.0176 μs | 0.0164 μs |   5,541 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |   1.213 μs | 0.0021 μs | 0.0020 μs |   2,991 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1.249 μs | 0.0018 μs | 0.0014 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1.002 μs | 0.0041 μs | 0.0034 μs |   5,541 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |   1.220 μs | 0.0011 μs | 0.0009 μs |   3,006 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1.254 μs | 0.0025 μs | 0.0023 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   2.726 μs | 0.0109 μs | 0.0102 μs |   5,564 B |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2.923 μs | 0.0040 μs | 0.0036 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   3.884 μs | 0.0097 μs | 0.0090 μs |   3,002 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   2.725 μs | 0.0059 μs | 0.0049 μs |   5,533 B |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2.931 μs | 0.0045 μs | 0.0042 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   3.906 μs | 0.0128 μs | 0.0114 μs |   2,991 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  15.831 μs | 0.0383 μs | 0.0359 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  16.075 μs | 0.0353 μs | 0.0295 μs |   5,583 B |    8480 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  25.459 μs | 0.0283 μs | 0.0236 μs |   2,991 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 237.411 μs | 0.2371 μs | 0.1852 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 295.072 μs | 0.4518 μs | 0.3773 μs |   5,583 B |  131374 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 394.015 μs | 0.8968 μs | 0.8389 μs |   2,991 B |         - |