| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.107 μs | 0.0018 μs | 0.0015 μs |   6,392 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1.179 μs | 0.0050 μs | 0.0047 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.107 μs | 0.0018 μs | 0.0017 μs |   6,396 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1.177 μs | 0.0027 μs | 0.0026 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   4.097 μs | 0.0116 μs | 0.0109 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   5.623 μs | 0.0059 μs | 0.0056 μs |   6,943 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   4.099 μs | 0.0128 μs | 0.0120 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   5.641 μs | 0.0081 μs | 0.0076 μs |   6,942 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  26.397 μs | 0.0912 μs | 0.0762 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  39.943 μs | 0.0710 μs | 0.0665 μs |   6,940 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 408.980 μs | 0.6735 μs | 0.5971 μs |   1,439 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 634.912 μs | 0.9027 μs | 0.8444 μs |   6,938 B |         - |