| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.305 μs | 0.0024 μs | 0.0023 μs |   6,974 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1.554 μs | 0.0021 μs | 0.0019 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.314 μs | 0.0101 μs | 0.0085 μs |   6,976 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1.558 μs | 0.0035 μs | 0.0031 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   5.437 μs | 0.0076 μs | 0.0071 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   6.564 μs | 0.0216 μs | 0.0202 μs |   6,986 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   5.445 μs | 0.0171 μs | 0.0151 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   6.549 μs | 0.0076 μs | 0.0071 μs |   6,981 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  34.517 μs | 0.0621 μs | 0.0551 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  46.343 μs | 0.0664 μs | 0.0589 μs |   6,981 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 542.146 μs | 9.3298 μs | 8.7271 μs |   1,460 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 732.532 μs | 1.2905 μs | 1.2071 μs |   6,979 B |         - |