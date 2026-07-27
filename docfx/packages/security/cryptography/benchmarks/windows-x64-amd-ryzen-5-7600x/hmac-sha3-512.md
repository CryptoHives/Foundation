| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.020 μs | 0.0038 μs | 0.0032 μs |   6,158 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1.058 μs | 0.0033 μs | 0.0028 μs |   1,105 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.001 μs | 0.0019 μs | 0.0016 μs |   6,171 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1.062 μs | 0.0097 μs | 0.0081 μs |   1,105 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   3.692 μs | 0.0263 μs | 0.0233 μs |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   5.054 μs | 0.0281 μs | 0.0263 μs |   6,174 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   3.686 μs | 0.0183 μs | 0.0162 μs |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   5.052 μs | 0.0199 μs | 0.0186 μs |   6,173 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  23.849 μs | 0.1947 μs | 0.1726 μs |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  35.970 μs | 0.2656 μs | 0.2218 μs |   6,173 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 368.852 μs | 1.8301 μs | 1.5283 μs |   1,107 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 573.814 μs | 2.4067 μs | 2.1334 μs |   6,170 B |         - |