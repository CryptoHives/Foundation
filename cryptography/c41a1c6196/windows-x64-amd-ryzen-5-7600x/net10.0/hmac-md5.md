| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     502.8 ns |   1.00 ns |   0.89 ns |   5,532 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     588.7 ns |   0.54 ns |   0.45 ns |   2,882 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     637.4 ns |   1.16 ns |   0.97 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     500.7 ns |   1.15 ns |   0.96 ns |   5,532 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     590.5 ns |   0.74 ns |   0.62 ns |   2,882 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     641.2 ns |   0.86 ns |   0.72 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,822.9 ns |   3.45 ns |   3.23 ns |   5,554 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,014.5 ns |   4.14 ns |   3.67 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,464.8 ns |   3.02 ns |   2.68 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,816.6 ns |   2.00 ns |   1.87 ns |   5,554 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,021.5 ns |   2.76 ns |   2.45 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,468.7 ns |   3.50 ns |   2.92 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  12,393.3 ns |  26.83 ns |  25.09 ns |   5,555 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  13,017.0 ns |  13.13 ns |  11.64 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  17,479.2 ns |  14.63 ns |  12.22 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 201,755.6 ns | 297.24 ns | 248.21 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 225,600.9 ns | 716.61 ns | 670.32 ns |   5,555 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 275,070.5 ns | 276.09 ns | 258.25 ns |   2,882 B |         - |