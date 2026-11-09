| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     652.8 ns |    10.63 ns |     9.95 ns |   5,560 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     666.5 ns |     2.13 ns |     1.99 ns |   2,918 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     759.7 ns |    11.28 ns |    10.00 ns |   1,037 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     651.7 ns |    11.22 ns |    10.49 ns |   5,560 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     662.1 ns |    10.42 ns |     9.75 ns |   2,918 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     754.5 ns |    13.34 ns |    12.48 ns |   1,037 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,132.5 ns |    29.72 ns |    27.80 ns |   5,572 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,455.1 ns |    33.08 ns |    30.94 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,856.2 ns |    44.76 ns |    41.87 ns |   2,918 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,132.9 ns |    33.50 ns |    31.33 ns |   5,572 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,464.5 ns |    36.83 ns |    34.45 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,843.4 ns |    46.89 ns |    43.86 ns |   2,918 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  13,684.9 ns |   141.87 ns |   132.70 ns |   5,579 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  15,501.4 ns |   274.12 ns |   256.41 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  19,522.9 ns |   351.44 ns |   328.73 ns |   2,918 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 241,725.4 ns | 3,227.27 ns | 3,018.79 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 261,994.5 ns | 3,570.82 ns | 3,340.15 ns |   5,579 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 308,074.5 ns | 4,155.46 ns | 3,887.02 ns |   2,918 B |         - |