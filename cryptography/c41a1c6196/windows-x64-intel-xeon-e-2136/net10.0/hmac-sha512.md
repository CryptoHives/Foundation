| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1.346 μs | 0.0013 μs | 0.0011 μs |   5,541 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |   1.642 μs | 0.0022 μs | 0.0020 μs |   3,002 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1.685 μs | 0.0038 μs | 0.0033 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1.345 μs | 0.0007 μs | 0.0007 μs |   5,541 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |   1.659 μs | 0.0031 μs | 0.0028 μs |   3,002 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1.700 μs | 0.0019 μs | 0.0016 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   3.657 μs | 0.0039 μs | 0.0036 μs |   5,533 B |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   3.963 μs | 0.0166 μs | 0.0147 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   5.264 μs | 0.0082 μs | 0.0068 μs |   3,002 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   3.663 μs | 0.0031 μs | 0.0029 μs |   5,533 B |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   3.962 μs | 0.0251 μs | 0.0222 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   5.277 μs | 0.0212 μs | 0.0199 μs |   3,002 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  21.452 μs | 0.0753 μs | 0.0704 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  21.718 μs | 0.0320 μs | 0.0299 μs |   5,583 B |    8480 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  34.152 μs | 0.0683 μs | 0.0639 μs |   2,997 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 322.375 μs | 1.0253 μs | 0.9591 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 390.828 μs | 0.2092 μs | 0.1747 μs |   5,583 B |  131374 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 535.218 μs | 2.3966 μs | 2.0013 μs |   2,991 B |         - |