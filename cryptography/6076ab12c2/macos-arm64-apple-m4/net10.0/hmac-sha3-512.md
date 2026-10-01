| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     497.5 ns |     2.59 ns |     2.16 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |     769.3 ns |     0.80 ns |     0.75 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     497.1 ns |     2.73 ns |     2.56 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |     770.1 ns |     0.65 ns |     0.58 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   2,503.2 ns |     4.36 ns |     3.64 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   2,698.0 ns |     1.95 ns |     1.63 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   2,510.6 ns |    17.08 ns |    15.14 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   2,705.5 ns |     0.99 ns |     0.83 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  17,282.2 ns |   185.16 ns |   173.20 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  17,413.9 ns |    31.08 ns |    29.07 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 271,272.6 ns |   307.98 ns |   288.08 ns |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 272,484.0 ns | 2,429.99 ns | 2,273.02 ns |         - |