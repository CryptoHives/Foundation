| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     516.7 ns |     2.04 ns |     1.81 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |     774.6 ns |     1.58 ns |     1.40 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     515.1 ns |     1.19 ns |     0.99 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |     771.8 ns |     1.45 ns |     1.35 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   2,502.2 ns |     5.91 ns |     5.52 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   2,715.5 ns |     5.15 ns |     4.81 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   2,507.7 ns |    10.35 ns |     8.64 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   2,712.1 ns |     7.97 ns |     7.46 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  17,528.2 ns |     8.38 ns |     7.43 ns |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  17,583.2 ns |    20.58 ns |    17.19 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 274,238.3 ns |   620.68 ns |   580.58 ns |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 280,338.7 ns | 2,344.99 ns | 2,193.51 ns |         - |