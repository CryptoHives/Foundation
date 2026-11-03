| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |     701.1 ns |   1.44 ns |   1.27 ns |   5,517 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     864.4 ns |   1.05 ns |   0.99 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,124.5 ns |   1.68 ns |   1.57 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |     696.2 ns |   1.54 ns |   1.36 ns |   5,519 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     867.4 ns |   1.22 ns |   1.09 ns |   2,943 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,125.7 ns |   3.31 ns |   3.09 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,947.5 ns |   4.63 ns |   4.33 ns |   5,515 B |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,607.3 ns |   3.69 ns |   3.27 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,744.7 ns |   3.82 ns |   3.19 ns |   2,963 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,945.8 ns |   5.38 ns |   5.03 ns |   5,515 B |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,622.0 ns |   3.68 ns |   3.45 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,744.5 ns |   5.10 ns |   4.77 ns |   2,943 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  11,884.3 ns |  30.66 ns |  27.18 ns |   5,555 B |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  14,417.8 ns |  13.51 ns |  10.55 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  17,732.8 ns |  51.16 ns |  47.86 ns |   2,963 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 213,744.2 ns | 439.45 ns | 389.56 ns |   5,555 B |  131374 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 216,919.5 ns | 252.98 ns | 236.63 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 274,855.2 ns | 370.10 ns | 346.19 ns |   2,943 B |         - |