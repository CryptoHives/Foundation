| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1.350 μs | 0.0009 μs | 0.0007 μs |   5,556 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |   1.635 μs | 0.0019 μs | 0.0016 μs |   2,991 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1.683 μs | 0.0022 μs | 0.0019 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1.356 μs | 0.0012 μs | 0.0011 μs |   5,556 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |   1.645 μs | 0.0033 μs | 0.0029 μs |   3,002 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1.702 μs | 0.0063 μs | 0.0055 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   3.677 μs | 0.0038 μs | 0.0035 μs |   5,569 B |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   3.946 μs | 0.0086 μs | 0.0077 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   5.246 μs | 0.0101 μs | 0.0090 μs |   3,002 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   3.681 μs | 0.0039 μs | 0.0036 μs |   5,569 B |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   3.950 μs | 0.0106 μs | 0.0099 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   5.279 μs | 0.0108 μs | 0.0090 μs |   3,002 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  21.460 μs | 0.0622 μs | 0.0520 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  21.705 μs | 0.0179 μs | 0.0150 μs |   5,577 B |    8432 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  34.367 μs | 0.1962 μs | 0.1835 μs |   2,997 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 322.909 μs | 1.0980 μs | 1.0270 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 391.395 μs | 0.4875 μs | 0.4321 μs |   5,577 B |  131326 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 537.074 μs | 3.6441 μs | 3.4087 μs |   2,991 B |         - |