| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     400.1 ns |   5.18 ns |   5.09 ns |   4,644 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     613.0 ns |   1.36 ns |   1.21 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     938.6 ns |   8.98 ns |   7.01 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     395.3 ns |   1.71 ns |   1.33 ns |   4,644 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     613.9 ns |   1.55 ns |   1.29 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     929.8 ns |   2.21 ns |   1.96 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,319.8 ns |   3.92 ns |   3.06 ns |   4,663 B |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,628.0 ns |  12.40 ns |  10.99 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   2,918.7 ns |  12.43 ns |  11.02 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,325.4 ns |  15.09 ns |  12.60 ns |   4,663 B |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,630.4 ns |   8.60 ns |   7.62 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   2,915.6 ns |   7.45 ns |   6.97 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   8,778.3 ns |  35.20 ns |  27.48 ns |   4,576 B |    8360 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  18,638.9 ns |  58.68 ns |  49.00 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  18,751.8 ns |  43.11 ns |  40.33 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 164,487.1 ns | 678.75 ns | 601.69 ns |   4,576 B |  131254 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 286,111.9 ns | 958.45 ns | 849.64 ns |   1,166 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 293,487.8 ns | 571.37 ns | 534.46 ns |   2,860 B |         - |