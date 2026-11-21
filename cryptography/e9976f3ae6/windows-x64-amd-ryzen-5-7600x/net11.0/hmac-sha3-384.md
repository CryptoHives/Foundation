| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.096 μs | 0.0025 μs | 0.0021 μs |   9,070 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1.189 μs | 0.0015 μs | 0.0012 μs |   5,482 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.098 μs | 0.0033 μs | 0.0029 μs |   9,070 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1.193 μs | 0.0026 μs | 0.0025 μs |   5,482 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   3.008 μs | 0.0088 μs | 0.0074 μs |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   3.875 μs | 0.0036 μs | 0.0033 μs |   9,597 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   3.023 μs | 0.0311 μs | 0.0276 μs |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   3.866 μs | 0.0044 μs | 0.0041 μs |  13,440 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  18.613 μs | 0.0184 μs | 0.0143 μs |   5,482 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  27.965 μs | 0.1430 μs | 0.1194 μs |   9,592 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 286.397 μs | 0.7596 μs | 0.6734 μs |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 437.625 μs | 0.3961 μs | 0.3307 μs |  13,476 B |         - |