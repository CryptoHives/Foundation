| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     352.5 ns |   2.51 ns |   2.35 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     646.4 ns |   1.57 ns |   1.47 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     494.6 ns |   4.00 ns |   3.74 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |     794.9 ns |   1.80 ns |   1.68 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   1,411.0 ns |   4.72 ns |   4.18 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   1,701.6 ns |   3.19 ns |   2.98 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   1,413.3 ns |   7.22 ns |   6.40 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   1,704.1 ns |   2.47 ns |   2.31 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |   9,457.4 ns |  76.83 ns |  71.87 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |   9,673.2 ns |  11.17 ns |  10.44 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 147,157.1 ns | 161.56 ns | 143.22 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 149,089.1 ns | 549.14 ns | 486.80 ns |         - |