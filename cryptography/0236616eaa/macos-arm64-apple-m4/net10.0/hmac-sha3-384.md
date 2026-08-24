| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     498.1 ns |     3.81 ns |     3.19 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |     779.5 ns |     3.61 ns |     3.20 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     502.2 ns |     7.49 ns |     7.00 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |     775.4 ns |     0.27 ns |     0.21 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   1,711.5 ns |     8.89 ns |     7.88 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   1,967.3 ns |     2.16 ns |     1.80 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   1,707.8 ns |    15.84 ns |    14.04 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   1,966.7 ns |     1.07 ns |     0.89 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  12,182.5 ns |   178.37 ns |   166.85 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  12,236.3 ns |     6.89 ns |     6.11 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 190,360.4 ns |   152.12 ns |   142.29 ns |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 191,062.6 ns | 1,785.25 ns | 1,669.92 ns |         - |