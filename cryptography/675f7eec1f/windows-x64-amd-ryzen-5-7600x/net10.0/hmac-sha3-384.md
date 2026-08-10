| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.007 μs | 0.0029 μs | 0.0024 μs |   6,180 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1.069 μs | 0.0066 μs | 0.0055 μs |   1,105 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.007 μs | 0.0062 μs | 0.0055 μs |   6,181 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1.068 μs | 0.0055 μs | 0.0052 μs |   1,105 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   2.692 μs | 0.0080 μs | 0.0067 μs |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   3.547 μs | 0.0428 μs | 0.0400 μs |   6,180 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   2.701 μs | 0.0225 μs | 0.0200 μs |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   3.529 μs | 0.0137 μs | 0.0115 μs |   6,182 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  16.733 μs | 0.0744 μs | 0.0621 μs |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  25.268 μs | 0.1311 μs | 0.1162 μs |   6,183 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 257.769 μs | 0.7668 μs | 0.6403 μs |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 395.618 μs | 1.1232 μs | 0.8769 μs |   6,182 B |         - |