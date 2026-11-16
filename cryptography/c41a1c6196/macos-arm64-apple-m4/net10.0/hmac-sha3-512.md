| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     503.3 ns |     2.23 ns |     2.08 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |     774.0 ns |     1.20 ns |     1.06 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     503.3 ns |     4.02 ns |     3.76 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |     773.0 ns |     0.65 ns |     0.61 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   2,524.2 ns |    11.99 ns |    11.22 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   2,721.6 ns |     2.36 ns |     2.21 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   2,522.3 ns |     4.91 ns |     4.10 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   2,722.9 ns |     2.14 ns |     2.00 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  17,391.1 ns |   119.71 ns |   111.98 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  17,530.0 ns |    24.41 ns |    22.84 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 273,866.0 ns |   210.28 ns |   186.40 ns |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 274,748.7 ns | 2,217.03 ns | 1,965.34 ns |         - |