| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     902.5 ns |     5.41 ns |     5.06 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |     957.3 ns |     8.65 ns |     8.09 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1,097.8 ns |     2.33 ns |     2.18 ns |     368 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     903.7 ns |     5.57 ns |     5.21 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |     956.4 ns |     6.18 ns |     5.48 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1,075.7 ns |     3.77 ns |     3.52 ns |     384 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,585.8 ns |     1.95 ns |     1.82 ns |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,248.6 ns |    19.71 ns |    15.39 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,907.6 ns |    18.73 ns |    16.61 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,586.0 ns |     2.46 ns |     1.92 ns |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,251.8 ns |    16.66 ns |    13.91 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,947.7 ns |    50.54 ns |    47.27 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |   5,516.4 ns |    20.03 ns |    18.73 ns |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  12,622.6 ns |    66.47 ns |    55.51 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  18,653.8 ns |   368.50 ns |   438.68 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        |  81,347.8 ns |   399.37 ns |   373.58 ns |  131338 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 192,960.3 ns | 3,726.53 ns | 3,987.35 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 292,530.7 ns | 2,756.46 ns | 2,578.40 ns |         - |