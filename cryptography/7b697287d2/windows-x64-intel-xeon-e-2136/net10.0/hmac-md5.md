| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     852.3 ns |   0.78 ns |   0.73 ns |   5,562 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     871.9 ns |   1.85 ns |   1.73 ns |   2,918 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     996.2 ns |   1.53 ns |   1.36 ns |   1,037 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     850.3 ns |   0.91 ns |   0.85 ns |   5,560 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     870.9 ns |   2.96 ns |   2.77 ns |   2,918 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     993.2 ns |   4.08 ns |   3.62 ns |   1,037 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,782.4 ns |   2.60 ns |   2.43 ns |   5,572 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   3,206.2 ns |   2.06 ns |   1.92 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   3,678.8 ns |   5.55 ns |   5.19 ns |   2,918 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,790.3 ns |   2.87 ns |   2.40 ns |   5,572 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   3,223.9 ns |   4.74 ns |   4.43 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   3,695.1 ns |   6.88 ns |   6.43 ns |   2,918 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  17,905.7 ns |  20.03 ns |  17.76 ns |   5,579 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  20,377.5 ns |  15.54 ns |  13.78 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  25,723.4 ns |  26.44 ns |  22.08 ns |   2,918 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 315,513.2 ns | 371.34 ns | 347.35 ns |   1,037 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 340,795.9 ns | 417.93 ns | 390.93 ns |   5,579 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 405,368.3 ns | 338.57 ns | 282.72 ns |   2,918 B |         - |