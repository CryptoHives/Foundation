| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     431.4 ns |     1.89 ns |     1.77 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     706.6 ns |     2.32 ns |     2.17 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     975.6 ns |     0.88 ns |     0.78 ns |     272 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     432.0 ns |     1.99 ns |     1.86 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     704.1 ns |     2.88 ns |     2.70 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     964.2 ns |     1.34 ns |     1.25 ns |     288 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   1,910.8 ns |     0.80 ns |     0.75 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,976.8 ns |     3.72 ns |     3.48 ns |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,368.1 ns |     7.26 ns |     6.79 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   1,909.0 ns |     1.32 ns |     1.17 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,975.1 ns |     2.37 ns |     2.21 ns |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,358.3 ns |     7.83 ns |     7.32 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |   9,951.6 ns |     3.26 ns |     2.89 ns |    8336 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  13,892.5 ns |     8.74 ns |     8.18 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  15,643.2 ns |    88.47 ns |    82.76 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 152,516.6 ns |    95.95 ns |    85.06 ns |  131244 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 219,199.6 ns |   179.26 ns |   158.91 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 242,851.9 ns | 1,103.72 ns | 1,032.42 ns |         - |