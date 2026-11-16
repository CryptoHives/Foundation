| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.763 μs | 0.0016 μs | 0.0014 μs |   6,432 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   2.113 μs | 0.0020 μs | 0.0019 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.766 μs | 0.0018 μs | 0.0017 μs |   6,430 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   2.108 μs | 0.0034 μs | 0.0032 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   7.359 μs | 0.0031 μs | 0.0029 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   8.847 μs | 0.0113 μs | 0.0105 μs |   6,982 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   7.373 μs | 0.0080 μs | 0.0071 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   8.857 μs | 0.0111 μs | 0.0093 μs |   6,981 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  46.645 μs | 0.0312 μs | 0.0292 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  62.729 μs | 0.0927 μs | 0.0822 μs |   6,981 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 723.854 μs | 0.3392 μs | 0.3173 μs |   1,460 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 993.434 μs | 0.8184 μs | 0.7655 μs |   6,979 B |         - |