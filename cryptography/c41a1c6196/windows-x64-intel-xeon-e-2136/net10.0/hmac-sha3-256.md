| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |   1.233 μs | 0.0017 μs | 0.0016 μs |  10,172 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |   1.749 μs | 0.0058 μs | 0.0054 μs |   1,460 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1.756 μs | 0.0030 μs | 0.0028 μs |   7,013 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   2.151 μs | 0.0068 μs | 0.0063 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   4.649 μs | 0.0124 μs | 0.0103 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   5.086 μs | 0.0067 μs | 0.0060 μs |   6,989 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   4.614 μs | 0.0061 μs | 0.0051 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   5.094 μs | 0.0103 μs | 0.0096 μs |   6,987 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  25.996 μs | 0.0634 μs | 0.0593 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  34.217 μs | 0.0443 μs | 0.0393 μs |   6,994 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 390.716 μs | 2.3282 μs | 2.0639 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 529.033 μs | 0.5792 μs | 0.5418 μs |   6,998 B |         - |