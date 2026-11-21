| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     500.1 ns |     1.78 ns |     1.58 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |     780.3 ns |     1.84 ns |     1.72 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     500.1 ns |     2.33 ns |     2.18 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |     778.4 ns |     0.75 ns |     0.70 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   2,454.6 ns |     9.08 ns |     8.05 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   2,730.6 ns |     3.01 ns |     2.35 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   2,451.4 ns |     6.88 ns |     6.10 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   2,732.1 ns |     5.70 ns |     5.33 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  17,339.0 ns |   152.13 ns |   142.30 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  17,539.7 ns |    38.07 ns |    35.61 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 274,400.3 ns | 1,667.47 ns | 1,559.76 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 280,156.6 ns |   223.85 ns |   174.76 ns |         - |