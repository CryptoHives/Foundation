| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |   1.229 μs | 0.0016 μs | 0.0015 μs |  10,172 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |   1.744 μs | 0.0045 μs | 0.0042 μs |   1,460 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1.762 μs | 0.0007 μs | 0.0006 μs |   7,013 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   2.158 μs | 0.0037 μs | 0.0033 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   4.622 μs | 0.0062 μs | 0.0058 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   5.073 μs | 0.0038 μs | 0.0034 μs |   6,997 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   4.632 μs | 0.0121 μs | 0.0113 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   5.077 μs | 0.0046 μs | 0.0041 μs |   6,989 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  25.997 μs | 0.0231 μs | 0.0216 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  34.193 μs | 0.0542 μs | 0.0453 μs |   7,002 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 389.957 μs | 1.2632 μs | 1.1816 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 531.243 μs | 0.5451 μs | 0.4832 μs |   6,991 B |         - |