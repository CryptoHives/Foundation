| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.766 μs | 0.0020 μs | 0.0018 μs |  12,971 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   2.125 μs | 0.0095 μs | 0.0084 μs |   5,510 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.766 μs | 0.0014 μs | 0.0012 μs |  12,971 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   2.124 μs | 0.0058 μs | 0.0049 μs |   5,501 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   5.388 μs | 0.0157 μs | 0.0147 μs |   5,503 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   6.172 μs | 0.0063 μs | 0.0053 μs |  13,502 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   5.401 μs | 0.0155 μs | 0.0137 μs |   5,503 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   6.183 μs | 0.0144 μs | 0.0135 μs |  13,506 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  33.177 μs | 0.0608 μs | 0.0539 μs |   5,503 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  43.969 μs | 0.0406 μs | 0.0339 μs |   9,658 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 506.506 μs | 2.0069 μs | 1.8772 μs |   5,512 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 689.491 μs | 0.3674 μs | 0.3437 μs |  13,696 B |         - |