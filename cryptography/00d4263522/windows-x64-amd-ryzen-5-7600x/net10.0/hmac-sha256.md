| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     221.3 ns |   0.60 ns |   0.50 ns |   4,639 B |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     772.9 ns |   1.29 ns |   1.08 ns |   2,878 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,030.8 ns |   3.01 ns |   2.67 ns |   1,333 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     225.8 ns |   1.01 ns |   0.89 ns |   4,639 B |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     778.0 ns |   1.46 ns |   1.14 ns |   2,858 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,035.1 ns |   5.15 ns |   4.30 ns |   1,333 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     582.2 ns |   2.66 ns |   2.36 ns |   4,643 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   3,313.2 ns |   5.26 ns |   4.66 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,343.2 ns |   9.60 ns |   8.98 ns |   2,858 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     586.2 ns |   3.63 ns |   3.40 ns |   4,643 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   3,319.3 ns |   8.88 ns |   7.41 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,340.9 ns |   5.67 ns |   4.43 ns |   2,858 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,710.2 ns |  25.14 ns |  22.29 ns |   4,576 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  21,537.5 ns |  83.13 ns |  73.70 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  23,824.3 ns |  84.08 ns |  74.53 ns |   2,858 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  87,010.8 ns | 861.19 ns | 763.42 ns |   4,576 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 332,683.1 ns | 603.60 ns | 471.25 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 375,357.3 ns | 511.01 ns | 453.00 ns |   2,858 B |         - |