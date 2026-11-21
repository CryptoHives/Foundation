| Description                                | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     506.2 ns |     0.56 ns |   0.53 ns |  12,622 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     587.2 ns |     0.61 ns |   0.57 ns |   9,681 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     649.7 ns |     1.19 ns |   1.05 ns |     989 B |         - |
|                                            |              |              |             |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     506.9 ns |     1.59 ns |   1.33 ns |   8,762 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     586.9 ns |     1.01 ns |   0.90 ns |   9,871 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     655.6 ns |     0.40 ns |   0.34 ns |     989 B |         - |
|                                            |              |              |             |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,838.5 ns |     5.16 ns |   4.83 ns |   8,758 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,044.9 ns |     3.46 ns |   3.24 ns |     989 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,489.3 ns |     1.66 ns |   1.38 ns |   9,681 B |         - |
|                                            |              |              |             |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,828.1 ns |     2.89 ns |   2.71 ns |  12,795 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,048.6 ns |     2.56 ns |   2.14 ns |     989 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,492.5 ns |     6.06 ns |   5.67 ns |   5,838 B |         - |
|                                            |              |              |             |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  12,447.0 ns |    26.38 ns |  24.68 ns |  12,471 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  13,162.7 ns |    25.63 ns |  23.98 ns |     989 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  17,447.6 ns |     9.70 ns |   8.10 ns |   5,838 B |         - |
|                                            |              |              |             |           |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 203,797.8 ns |   509.07 ns | 476.19 ns |     989 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 233,030.8 ns | 1,028.24 ns | 961.82 ns |   8,797 B |  131270 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 274,735.8 ns |   779.27 ns | 728.93 ns |   9,688 B |         - |