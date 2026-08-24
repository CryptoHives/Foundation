| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     903.1 ns |    13.34 ns |    12.47 ns |     907.0 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,008.6 ns |     3.38 ns |     2.82 ns |   1,008.6 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1,124.1 ns |     4.96 ns |     4.64 ns |   1,122.6 ns |     368 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     904.2 ns |    12.64 ns |    11.83 ns |     907.7 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,008.2 ns |     1.81 ns |     1.51 ns |   1,008.8 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1,101.5 ns |     4.15 ns |     3.88 ns |   1,100.9 ns |     384 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,580.9 ns |     6.31 ns |     5.90 ns |   1,579.3 ns |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,391.2 ns |    14.65 ns |    11.44 ns |   2,393.4 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,852.1 ns |    56.85 ns |   117.40 ns |   2,913.1 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,574.7 ns |     8.74 ns |     8.17 ns |   1,576.2 ns |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,396.4 ns |     4.94 ns |     4.12 ns |   2,396.4 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,878.7 ns |    57.41 ns |    61.43 ns |   2,894.3 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |   5,476.8 ns |    21.82 ns |    20.41 ns |   5,479.1 ns |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  13,708.4 ns |   273.28 ns |   374.07 ns |  13,488.7 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  18,839.1 ns |   366.54 ns |   360.00 ns |  18,975.7 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        |  77,512.0 ns |   428.37 ns |   400.70 ns |  77,614.7 ns |  131340 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 202,254.7 ns |   371.78 ns |   347.76 ns | 202,347.1 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 289,738.7 ns | 5,782.55 ns | 9,337.73 ns | 294,764.9 ns |         - |