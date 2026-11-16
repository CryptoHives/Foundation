| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     898.8 ns |    16.75 ns |    15.67 ns |     902.5 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |     961.4 ns |    18.71 ns |    18.38 ns |     953.0 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1,078.3 ns |     4.23 ns |     3.96 ns |   1,079.5 ns |     416 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     913.1 ns |     2.35 ns |     2.20 ns |     912.7 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |     955.4 ns |     6.42 ns |     5.36 ns |     954.4 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1,057.1 ns |     4.70 ns |     4.39 ns |   1,057.4 ns |     432 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,551.6 ns |     4.65 ns |     4.35 ns |   1,552.1 ns |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,293.9 ns |    42.26 ns |    74.01 ns |   2,258.9 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,895.1 ns |    46.88 ns |    43.85 ns |   2,912.2 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,553.5 ns |     2.32 ns |     2.17 ns |   1,553.4 ns |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,246.9 ns |    17.80 ns |    14.87 ns |   2,241.8 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,669.6 ns |    43.81 ns |    44.99 ns |   2,672.8 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |   5,479.3 ns |    13.33 ns |    12.47 ns |   5,477.5 ns |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  12,611.4 ns |   118.44 ns |    92.47 ns |  12,585.1 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  18,724.1 ns |   360.28 ns |   337.01 ns |  18,816.1 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        |  77,826.5 ns |   287.36 ns |   268.80 ns |  77,870.5 ns |  131388 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 189,436.6 ns |   924.94 ns |   819.93 ns | 189,461.9 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 290,980.0 ns | 5,810.49 ns | 7,135.81 ns | 293,490.0 ns |         - |