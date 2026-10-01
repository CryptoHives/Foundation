| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     246.5 ns |   0.40 ns |   0.38 ns |   5,533 B |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     866.2 ns |   0.71 ns |   0.63 ns |   2,940 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,166.1 ns |   1.22 ns |   1.15 ns |   1,546 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     247.1 ns |   0.88 ns |   0.82 ns |   5,533 B |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     866.4 ns |   0.45 ns |   0.37 ns |   2,940 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,170.1 ns |   2.45 ns |   2.17 ns |   1,546 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     664.7 ns |   0.96 ns |   0.90 ns |   5,537 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   3,725.6 ns |   3.72 ns |   3.48 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,732.1 ns |   1.61 ns |   1.43 ns |   2,940 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     661.9 ns |   0.85 ns |   0.75 ns |   5,537 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   3,722.6 ns |   1.50 ns |   1.40 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,732.9 ns |   2.71 ns |   2.53 ns |   2,940 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   4,003.7 ns |  11.18 ns |  10.46 ns |   5,558 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  24,152.3 ns |  17.73 ns |  16.59 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  26,670.3 ns |  35.66 ns |  33.36 ns |   2,940 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  93,976.7 ns | 269.27 ns | 251.87 ns |   5,558 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 376,155.1 ns | 437.76 ns | 409.48 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 419,160.6 ns | 287.89 ns | 269.29 ns |   2,922 B |         - |