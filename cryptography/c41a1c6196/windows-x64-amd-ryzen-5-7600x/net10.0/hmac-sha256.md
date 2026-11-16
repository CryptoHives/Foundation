| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     252.0 ns |   1.19 ns |   1.06 ns |   5,530 B |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     869.2 ns |   1.57 ns |   1.31 ns |   2,940 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,056.0 ns |   3.24 ns |   2.71 ns |   1,546 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     260.7 ns |   0.38 ns |   0.31 ns |   5,530 B |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     946.6 ns |   2.32 ns |   2.06 ns |   2,940 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,066.8 ns |   2.06 ns |   1.72 ns |   1,546 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     667.3 ns |   2.23 ns |   1.98 ns |   5,536 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   3,422.6 ns |   9.03 ns |   8.01 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,758.0 ns |  16.11 ns |  13.45 ns |   2,902 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     667.8 ns |   2.05 ns |   1.92 ns |   5,536 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   3,427.6 ns |   3.92 ns |   3.28 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,744.5 ns |   7.33 ns |   5.73 ns |   2,940 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   4,025.0 ns |  13.23 ns |  12.38 ns |   5,555 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  22,279.7 ns |  42.23 ns |  35.26 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  26,758.7 ns | 103.29 ns |  91.56 ns |   2,902 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  93,417.9 ns | 186.65 ns | 155.86 ns |   5,555 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 343,404.2 ns | 557.77 ns | 465.77 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 421,877.3 ns | 678.06 ns | 566.21 ns |   2,940 B |         - |