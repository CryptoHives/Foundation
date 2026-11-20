| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |   1.228 μs | 0.0028 μs | 0.0025 μs |  16,481 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |   1.731 μs | 0.0023 μs | 0.0019 μs |   5,505 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1.758 μs | 0.0014 μs | 0.0012 μs |  13,177 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   2.134 μs | 0.0129 μs | 0.0121 μs |   5,512 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   4.641 μs | 0.0244 μs | 0.0228 μs |   5,503 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   5.086 μs | 0.0116 μs | 0.0109 μs |  13,567 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   4.640 μs | 0.0185 μs | 0.0173 μs |   5,503 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   5.078 μs | 0.0024 μs | 0.0021 μs |   9,724 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  25.980 μs | 0.0663 μs | 0.0588 μs |   5,512 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  34.270 μs | 0.0105 μs | 0.0088 μs |   9,723 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 390.150 μs | 1.3468 μs | 1.1939 μs |   5,501 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 531.813 μs | 1.1899 μs | 1.1131 μs |  13,560 B |         - |