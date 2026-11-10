| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.768 μs | 0.0010 μs | 0.0009 μs |   6,436 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   2.109 μs | 0.0016 μs | 0.0015 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.774 μs | 0.0012 μs | 0.0011 μs |   6,436 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   2.105 μs | 0.0016 μs | 0.0014 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   7.347 μs | 0.0064 μs | 0.0060 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   8.884 μs | 0.0106 μs | 0.0094 μs |   6,982 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   7.357 μs | 0.0028 μs | 0.0025 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   8.873 μs | 0.0140 μs | 0.0124 μs |   6,981 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  46.678 μs | 0.0253 μs | 0.0237 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  62.757 μs | 0.0543 μs | 0.0481 μs |   6,975 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 724.899 μs | 0.5757 μs | 0.4807 μs |   1,460 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 991.151 μs | 0.8321 μs | 0.7783 μs |   6,979 B |         - |