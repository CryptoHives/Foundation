| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.764 μs | 0.0016 μs | 0.0015 μs |   6,426 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   2.135 μs | 0.0077 μs | 0.0068 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.763 μs | 0.0008 μs | 0.0006 μs |   6,432 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   2.124 μs | 0.0057 μs | 0.0054 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   5.394 μs | 0.0094 μs | 0.0083 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   6.168 μs | 0.0032 μs | 0.0030 μs |   6,967 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   5.429 μs | 0.0069 μs | 0.0065 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   6.196 μs | 0.0059 μs | 0.0049 μs |   6,967 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  33.042 μs | 0.0472 μs | 0.0418 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  43.956 μs | 0.0355 μs | 0.0314 μs |   6,964 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 506.162 μs | 0.7847 μs | 0.6956 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 689.341 μs | 0.3158 μs | 0.2637 μs |   6,963 B |         - |