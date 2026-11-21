| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     854.5 ns |     0.53 ns |     0.47 ns |   8,784 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     873.3 ns |     2.32 ns |     2.06 ns |   9,937 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |   1,046.2 ns |    17.13 ns |    15.19 ns |     995 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     852.3 ns |     0.49 ns |     0.46 ns |   8,615 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     881.4 ns |     6.20 ns |     5.50 ns |   5,904 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |   1,046.6 ns |    20.76 ns |    23.90 ns |     995 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,787.0 ns |     2.99 ns |     2.80 ns |  12,631 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   3,260.1 ns |    64.38 ns |    96.36 ns |     995 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   3,678.8 ns |    14.11 ns |    13.19 ns |   9,929 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,797.2 ns |     2.47 ns |     2.31 ns |  12,631 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   3,176.0 ns |    20.44 ns |    17.07 ns |     995 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   3,674.4 ns |     8.50 ns |     7.10 ns |   9,739 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  17,908.5 ns |    10.63 ns |     9.42 ns |  12,691 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  20,529.1 ns |   399.51 ns |   460.08 ns |     995 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  25,729.2 ns |    65.54 ns |    54.73 ns |   5,904 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 326,174.8 ns | 5,549.07 ns | 5,190.61 ns |     995 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 348,333.3 ns |   325.09 ns |   304.09 ns |  12,860 B |  131270 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 406,463.3 ns | 1,775.15 ns | 1,573.62 ns |   9,937 B |         - |