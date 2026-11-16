| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.111 μs | 0.0028 μs | 0.0025 μs |   6,926 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1.178 μs | 0.0026 μs | 0.0023 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.115 μs | 0.0053 μs | 0.0049 μs |   6,930 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1.179 μs | 0.0032 μs | 0.0027 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   4.110 μs | 0.0120 μs | 0.0112 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   5.625 μs | 0.0116 μs | 0.0097 μs |   6,941 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   4.094 μs | 0.0086 μs | 0.0072 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   5.679 μs | 0.0645 μs | 0.0571 μs |   6,940 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  26.522 μs | 0.0849 μs | 0.0753 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  39.585 μs | 0.0522 μs | 0.0463 μs |   6,940 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 410.175 μs | 1.0494 μs | 0.8763 μs |   1,439 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 633.405 μs | 2.5024 μs | 2.3408 μs |   6,938 B |         - |