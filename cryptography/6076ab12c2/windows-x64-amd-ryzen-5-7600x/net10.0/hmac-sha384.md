| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |     702.3 ns |   0.50 ns |   0.47 ns |   5,519 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     861.3 ns |   0.59 ns |   0.52 ns |   2,939 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,221.4 ns |   1.15 ns |   1.02 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |     693.7 ns |   0.73 ns |   0.65 ns |   5,519 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     857.8 ns |   0.70 ns |   0.55 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,219.4 ns |   1.16 ns |   1.03 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,944.0 ns |   4.80 ns |   4.49 ns |   5,535 B |    1264 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,731.7 ns |   2.67 ns |   2.49 ns |   2,943 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,823.8 ns |   4.15 ns |   3.88 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,944.4 ns |   3.61 ns |   3.37 ns |   5,535 B |    1272 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,731.3 ns |   1.96 ns |   1.83 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,824.7 ns |   2.63 ns |   2.46 ns |   1,656 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  11,854.3 ns |  16.68 ns |  14.79 ns |   5,556 B |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  15,633.2 ns |  31.12 ns |  29.11 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  17,688.8 ns |  17.74 ns |  16.59 ns |   2,943 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 212,144.0 ns | 150.87 ns | 133.74 ns |   5,556 B |  131326 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 235,138.8 ns | 107.31 ns |  89.61 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 274,086.5 ns | 285.97 ns | 267.50 ns |   2,943 B |         - |