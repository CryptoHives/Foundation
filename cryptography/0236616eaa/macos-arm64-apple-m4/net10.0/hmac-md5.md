| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     465.3 ns |   6.19 ns |   5.48 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     732.2 ns |   0.86 ns |   0.72 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128B         |   1,015.8 ns |   5.78 ns |   5.41 ns |     272 B |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     463.9 ns |   1.16 ns |   1.03 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     733.7 ns |   0.84 ns |   0.75 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |   1,003.2 ns |   5.59 ns |   5.23 ns |     288 B |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,037.1 ns |   8.10 ns |   7.57 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,104.1 ns |   9.73 ns |   9.10 ns |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,495.3 ns |   1.94 ns |   1.72 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,044.0 ns |   6.02 ns |   5.34 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,113.9 ns |   8.65 ns |   8.09 ns |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,495.3 ns |   1.85 ns |   1.64 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,522.6 ns |  26.68 ns |  24.95 ns |    8336 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  14,686.7 ns |  50.14 ns |  46.90 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  16,596.5 ns |  27.24 ns |  22.74 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 160,945.2 ns | 641.54 ns | 600.10 ns |  131244 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 231,236.0 ns | 537.89 ns | 503.14 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 258,172.8 ns | 453.99 ns | 424.66 ns |         - |