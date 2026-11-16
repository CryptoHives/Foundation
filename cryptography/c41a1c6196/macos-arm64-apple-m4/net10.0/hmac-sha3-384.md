| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     497.6 ns |   1.65 ns |   1.54 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |     785.5 ns |   0.64 ns |   0.60 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     501.2 ns |   4.21 ns |   3.94 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |     785.5 ns |   0.80 ns |   0.75 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   1,763.3 ns |   8.46 ns |   7.91 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   1,982.5 ns |   2.02 ns |   1.89 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   1,718.0 ns |   4.35 ns |   3.63 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   1,983.3 ns |   1.74 ns |   1.63 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  12,143.1 ns |  39.65 ns |  30.96 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  12,328.4 ns |   7.48 ns |   6.64 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 191,212.4 ns | 360.87 ns | 301.34 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 191,282.8 ns | 326.15 ns | 289.12 ns |         - |