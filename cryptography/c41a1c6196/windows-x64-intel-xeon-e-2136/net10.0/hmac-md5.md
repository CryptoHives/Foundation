| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     846.4 ns |     0.55 ns |     0.46 ns |   5,560 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     872.2 ns |     4.41 ns |     3.91 ns |   2,918 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     986.3 ns |     2.82 ns |     2.63 ns |   1,037 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     847.1 ns |     0.96 ns |     0.89 ns |   5,562 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     870.2 ns |     2.93 ns |     2.60 ns |   2,918 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |   1,015.2 ns |     5.20 ns |     4.61 ns |   1,037 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,778.3 ns |     6.23 ns |     5.20 ns |   5,572 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   3,208.3 ns |     6.60 ns |     5.51 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   3,692.5 ns |    17.46 ns |    15.48 ns |   2,918 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,788.1 ns |     3.43 ns |     2.87 ns |   5,572 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   3,237.7 ns |    14.38 ns |    13.45 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   3,745.0 ns |     9.49 ns |     8.87 ns |   2,918 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  17,890.6 ns |    20.71 ns |    18.35 ns |   5,579 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  20,665.4 ns |    16.00 ns |    13.36 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  25,828.4 ns |   143.36 ns |   127.08 ns |   2,918 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 314,982.8 ns |   543.03 ns |   507.95 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 336,846.4 ns |   411.79 ns |   343.86 ns |   5,579 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 411,364.6 ns | 2,810.06 ns | 2,628.53 ns |   2,918 B |         - |