| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1.357 μs | 0.0013 μs | 0.0012 μs |   5,556 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |   1.636 μs | 0.0042 μs | 0.0039 μs |   3,002 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1.677 μs | 0.0015 μs | 0.0012 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1.360 μs | 0.0016 μs | 0.0014 μs |   5,556 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |   1.646 μs | 0.0015 μs | 0.0013 μs |   2,991 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1.694 μs | 0.0031 μs | 0.0029 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   3.687 μs | 0.0027 μs | 0.0025 μs |   5,571 B |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   3.947 μs | 0.0044 μs | 0.0039 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   5.253 μs | 0.0072 μs | 0.0064 μs |   3,002 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   3.695 μs | 0.0043 μs | 0.0041 μs |   5,569 B |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   3.954 μs | 0.0096 μs | 0.0090 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   5.245 μs | 0.0107 μs | 0.0095 μs |   3,002 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  21.433 μs | 0.0426 μs | 0.0399 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  21.776 μs | 0.0195 μs | 0.0173 μs |   5,577 B |    8432 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  34.160 μs | 0.0564 μs | 0.0528 μs |   2,991 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 321.959 μs | 0.4356 μs | 0.3862 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 396.297 μs | 0.4607 μs | 0.4084 μs |   5,577 B |  131326 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 533.534 μs | 0.5927 μs | 0.5254 μs |   2,991 B |         - |