| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     463.1 ns |   1.23 ns |   1.15 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     735.4 ns |   0.51 ns |   0.45 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128B         |   1,025.8 ns |   5.99 ns |   5.60 ns |     272 B |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     463.8 ns |   1.68 ns |   1.57 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     736.5 ns |   1.88 ns |   1.76 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |   1,008.3 ns |   5.29 ns |   4.95 ns |     288 B |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,057.3 ns |   5.46 ns |   5.10 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,123.4 ns |   8.70 ns |   8.14 ns |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,509.6 ns |   4.07 ns |   3.81 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,055.1 ns |   5.06 ns |   4.73 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,119.6 ns |  10.60 ns |   9.92 ns |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,506.3 ns |   6.33 ns |   5.61 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,527.4 ns |  36.27 ns |  33.93 ns |    8336 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  14,778.1 ns |  44.98 ns |  42.07 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  16,658.8 ns |  32.36 ns |  27.03 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 161,236.8 ns | 604.72 ns | 565.66 ns |  131244 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 233,198.7 ns | 923.81 ns | 864.13 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 259,021.5 ns | 745.46 ns | 697.31 ns |         - |