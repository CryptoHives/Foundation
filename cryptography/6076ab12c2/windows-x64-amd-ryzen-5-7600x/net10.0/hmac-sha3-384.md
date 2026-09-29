| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.095 μs | 0.0017 μs | 0.0016 μs |   6,392 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1.181 μs | 0.0011 μs | 0.0010 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.094 μs | 0.0013 μs | 0.0012 μs |   6,392 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1.186 μs | 0.0010 μs | 0.0008 μs |   1,437 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   2.988 μs | 0.0025 μs | 0.0023 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   3.877 μs | 0.0061 μs | 0.0057 μs |   6,924 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   2.989 μs | 0.0023 μs | 0.0021 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   3.877 μs | 0.0035 μs | 0.0032 μs |   6,924 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  18.557 μs | 0.0178 μs | 0.0166 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  27.760 μs | 0.0147 μs | 0.0137 μs |   6,916 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 285.001 μs | 0.3872 μs | 0.3622 μs |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 436.436 μs | 0.1994 μs | 0.1865 μs |   6,914 B |         - |