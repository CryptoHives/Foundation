| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.300 μs | 0.0024 μs | 0.0022 μs |   7,016 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1.567 μs | 0.0021 μs | 0.0019 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.331 μs | 0.0245 μs | 0.0229 μs |   6,426 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1.571 μs | 0.0022 μs | 0.0020 μs |   1,458 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   4.022 μs | 0.0141 μs | 0.0132 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   4.561 μs | 0.0066 μs | 0.0055 μs |   6,957 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   4.006 μs | 0.0101 μs | 0.0094 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   4.558 μs | 0.0131 μs | 0.0122 μs |   6,965 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  24.456 μs | 0.1146 μs | 0.1016 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  32.451 μs | 0.0745 μs | 0.0660 μs |   6,971 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 373.407 μs | 0.8293 μs | 0.7757 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 509.657 μs | 1.6419 μs | 1.3711 μs |   6,963 B |         - |