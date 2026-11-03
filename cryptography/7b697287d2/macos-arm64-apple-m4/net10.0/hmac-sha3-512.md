| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     512.1 ns |     3.18 ns |     2.97 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |     772.6 ns |     0.87 ns |     0.77 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     514.6 ns |     4.28 ns |     4.01 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |     773.5 ns |     2.71 ns |     2.54 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   2,449.5 ns |    11.14 ns |     9.88 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   2,717.5 ns |     7.21 ns |     6.74 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   2,525.5 ns |     9.30 ns |     8.25 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   2,717.8 ns |     6.29 ns |     5.88 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  17,079.2 ns |    64.61 ns |    50.44 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  17,427.7 ns |     7.20 ns |     6.38 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 272,050.7 ns |   212.27 ns |   198.55 ns |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 274,039.1 ns | 2,267.41 ns | 2,120.94 ns |         - |