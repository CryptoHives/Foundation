| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     514.3 ns |     4.47 ns |     3.96 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |     770.2 ns |     0.69 ns |     0.61 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     508.4 ns |     2.66 ns |     2.36 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |     772.9 ns |     1.27 ns |     1.12 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   2,474.4 ns |     6.71 ns |     5.95 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   2,740.6 ns |     2.89 ns |     2.56 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   2,484.1 ns |    11.25 ns |    10.53 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   2,744.3 ns |     5.48 ns |     5.12 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  17,445.5 ns |    75.03 ns |    66.51 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  17,740.2 ns |   115.62 ns |   102.49 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 275,834.9 ns |   651.63 ns |   508.75 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 279,006.1 ns | 3,772.55 ns | 3,528.84 ns |         - |