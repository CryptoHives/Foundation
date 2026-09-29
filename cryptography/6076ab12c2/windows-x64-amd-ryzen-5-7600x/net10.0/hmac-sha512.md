| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |     701.1 ns |   1.23 ns |   1.02 ns |   5,520 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     868.8 ns |   0.56 ns |   0.53 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,219.5 ns |   1.04 ns |   0.86 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |     698.5 ns |   0.57 ns |   0.50 ns |   5,522 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     868.9 ns |   0.61 ns |   0.57 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,222.1 ns |   1.61 ns |   1.50 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,934.3 ns |   2.76 ns |   2.58 ns |   5,540 B |    1312 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,736.5 ns |   2.31 ns |   2.16 ns |   2,943 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,822.8 ns |   2.20 ns |   2.06 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,939.9 ns |   1.49 ns |   1.24 ns |   5,540 B |    1320 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,737.2 ns |   2.04 ns |   1.70 ns |   2,939 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,827.3 ns |   3.07 ns |   2.73 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  11,847.8 ns |   8.25 ns |   7.72 ns |   5,558 B |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  15,634.4 ns |   9.40 ns |   7.85 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  17,696.5 ns |  27.33 ns |  25.57 ns |   2,943 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 212,160.0 ns | 177.02 ns | 165.58 ns |   5,558 B |  131374 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 235,120.4 ns | 155.12 ns | 145.10 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 274,199.4 ns | 255.44 ns | 238.94 ns |   2,943 B |         - |