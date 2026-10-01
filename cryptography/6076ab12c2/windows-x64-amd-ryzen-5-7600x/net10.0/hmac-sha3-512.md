| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.099 μs | 0.0006 μs | 0.0005 μs |   6,392 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1.173 μs | 0.0017 μs | 0.0016 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.098 μs | 0.0013 μs | 0.0012 μs |   6,398 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1.173 μs | 0.0015 μs | 0.0014 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   4.082 μs | 0.0037 μs | 0.0033 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   5.611 μs | 0.0080 μs | 0.0071 μs |   6,943 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   4.086 μs | 0.0045 μs | 0.0042 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   5.626 μs | 0.0052 μs | 0.0049 μs |   6,940 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  26.274 μs | 0.0266 μs | 0.0249 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  39.967 μs | 0.0328 μs | 0.0307 μs |   6,940 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 408.623 μs | 0.3792 μs | 0.3547 μs |   1,439 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 631.295 μs | 0.6445 μs | 0.5713 μs |   6,938 B |         - |