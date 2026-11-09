| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     643.2 ns |     9.39 ns |     8.78 ns |   5,560 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |   1,132.9 ns |    17.29 ns |    16.17 ns |   2,946 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   1,491.6 ns |    25.29 ns |    23.66 ns |   1,172 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     640.6 ns |     9.63 ns |     9.01 ns |   5,560 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |   1,141.2 ns |     3.91 ns |     3.66 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,483.1 ns |    22.48 ns |    21.03 ns |   1,172 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,996.3 ns |    19.50 ns |    18.24 ns |   5,572 B |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   4,414.5 ns |    62.28 ns |    58.25 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   4,834.9 ns |    80.22 ns |    75.04 ns |   2,930 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,992.8 ns |    30.69 ns |    28.71 ns |   5,572 B |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   4,455.3 ns |    23.68 ns |    22.15 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   4,564.3 ns |    85.93 ns |    80.37 ns |   2,946 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |  12,271.5 ns |   185.97 ns |   173.96 ns |   5,579 B |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  27,762.7 ns |   313.16 ns |   292.93 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  32,192.1 ns |   593.60 ns |   555.25 ns |   2,930 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 239,241.6 ns | 3,388.37 ns | 3,169.48 ns |   5,579 B |  131254 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 427,512.2 ns | 6,792.25 ns | 6,353.48 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 537,881.2 ns | 8,041.91 ns | 7,522.40 ns |   2,930 B |         - |