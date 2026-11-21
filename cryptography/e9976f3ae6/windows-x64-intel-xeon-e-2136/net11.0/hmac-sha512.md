| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1.353 μs | 0.0006 μs | 0.0006 μs |  12,460 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |   1.657 μs | 0.0050 μs | 0.0047 μs |   5,948 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1.684 μs | 0.0026 μs | 0.0021 μs |   4,988 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1.352 μs | 0.0011 μs | 0.0009 μs |   8,784 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |   1.658 μs | 0.0015 μs | 0.0012 μs |   9,789 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1.693 μs | 0.0042 μs | 0.0037 μs |   4,988 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   3.669 μs | 0.0019 μs | 0.0016 μs |  12,631 B |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   4.216 μs | 0.0409 μs | 0.0383 μs |   4,988 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   5.284 μs | 0.0274 μs | 0.0243 μs |   9,977 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   3.690 μs | 0.0031 μs | 0.0028 μs |  12,631 B |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   3.961 μs | 0.0124 μs | 0.0104 μs |   4,988 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   5.245 μs | 0.0095 μs | 0.0079 μs |   5,946 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  21.466 μs | 0.0998 μs | 0.0934 μs |   4,988 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  21.771 μs | 0.0098 μs | 0.0087 μs |  12,687 B |    8480 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  34.291 μs | 0.1438 μs | 0.1345 μs |   9,977 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 321.253 μs | 0.7906 μs | 0.7008 μs |   4,988 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 401.516 μs | 0.2935 μs | 0.2602 μs |  12,666 B |  131414 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 534.189 μs | 1.0403 μs | 0.8122 μs |   9,787 B |         - |