| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.104 μs | 0.0022 μs | 0.0020 μs |  13,119 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1.182 μs | 0.0032 μs | 0.0026 μs |   5,482 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.103 μs | 0.0007 μs | 0.0006 μs |  12,929 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1.182 μs | 0.0020 μs | 0.0017 μs |   5,482 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   4.111 μs | 0.0073 μs | 0.0065 μs |   5,482 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   5.564 μs | 0.0053 μs | 0.0050 μs |   9,676 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   4.101 μs | 0.0027 μs | 0.0022 μs |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   5.571 μs | 0.0047 μs | 0.0039 μs |  14,732 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  26.361 μs | 0.0392 μs | 0.0328 μs |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  39.914 μs | 0.0615 μs | 0.0514 μs |  14,729 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 410.182 μs | 0.6536 μs | 0.5794 μs |   5,493 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 630.692 μs | 0.6488 μs | 0.5418 μs |  14,720 B |         - |