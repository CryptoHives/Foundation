| Description                                   | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |     397.9 ns |     0.39 ns |      0.35 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     619.9 ns |     2.31 ns |      2.05 ns |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     837.6 ns |    16.68 ns |     21.09 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |     400.5 ns |     0.85 ns |      0.66 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     611.4 ns |     2.49 ns |      2.33 ns |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     850.5 ns |    16.71 ns |     29.69 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |     673.7 ns |     3.88 ns |      3.63 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     867.2 ns |     0.70 ns |      0.62 ns |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,673.5 ns |    73.11 ns |    139.10 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |     662.2 ns |     7.10 ns |      6.30 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     872.1 ns |     0.59 ns |      0.49 ns |    1224 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,666.6 ns |    72.15 ns |     98.76 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |   3,041.7 ns |     1.62 ns |      1.43 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,190.7 ns |     2.32 ns |      2.17 ns |    8384 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  26,008.9 ns |   516.02 ns |    969.20 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        |  44,033.8 ns |    12.54 ns |     11.73 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  48,343.3 ns |   120.90 ns |    113.09 ns |  131292 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 403,069.9 ns | 7,942.17 ns | 17,926.80 ns |         - |