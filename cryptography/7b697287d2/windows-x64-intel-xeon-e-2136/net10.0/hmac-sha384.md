| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1.006 μs | 0.0013 μs | 0.0010 μs |   5,556 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |   1.236 μs | 0.0238 μs | 0.0234 μs |   3,002 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1.241 μs | 0.0027 μs | 0.0022 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1.038 μs | 0.0157 μs | 0.0147 μs |   5,556 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |   1.250 μs | 0.0187 μs | 0.0175 μs |   2,991 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1.286 μs | 0.0240 μs | 0.0224 μs |   1,662 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   2.737 μs | 0.0052 μs | 0.0046 μs |   5,569 B |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2.923 μs | 0.0056 μs | 0.0053 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   3.870 μs | 0.0044 μs | 0.0036 μs |   3,002 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   2.735 μs | 0.0049 μs | 0.0043 μs |   5,569 B |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2.927 μs | 0.0039 μs | 0.0034 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   3.872 μs | 0.0084 μs | 0.0075 μs |   2,991 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  15.817 μs | 0.0264 μs | 0.0247 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  16.103 μs | 0.0420 μs | 0.0392 μs |   5,577 B |    8432 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  25.190 μs | 0.0259 μs | 0.0216 μs |   2,991 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 237.897 μs | 0.5571 μs | 0.4349 μs |   1,662 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 295.663 μs | 0.8132 μs | 0.7607 μs |   5,577 B |  131326 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 394.107 μs | 0.6143 μs | 0.5746 μs |   2,976 B |         - |