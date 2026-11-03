| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |     699.1 ns |   2.13 ns |   1.66 ns |   5,516 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     867.7 ns |   1.42 ns |   1.32 ns |   2,943 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,121.0 ns |   1.81 ns |   1.60 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |     703.9 ns |   1.56 ns |   1.46 ns |   5,516 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     868.2 ns |   0.87 ns |   0.73 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,121.6 ns |   2.97 ns |   2.78 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,946.2 ns |   7.55 ns |   7.07 ns |   5,532 B |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,599.1 ns |   5.64 ns |   5.27 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,740.9 ns |   5.16 ns |   4.83 ns |   2,963 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,958.0 ns |   1.66 ns |   1.39 ns |   5,532 B |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,599.0 ns |   6.25 ns |   5.84 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,744.1 ns |   4.31 ns |   3.82 ns |   2,950 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  11,871.2 ns |  26.73 ns |  25.01 ns |   5,553 B |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  14,412.6 ns |  13.73 ns |  12.84 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  17,864.9 ns |  43.44 ns |  40.63 ns |   2,962 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 213,603.0 ns | 324.43 ns | 287.60 ns |   5,553 B |  131326 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 216,728.3 ns | 322.34 ns | 301.52 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 275,042.2 ns | 614.47 ns | 574.78 ns |   2,943 B |         - |