| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |     620.7 ns |     5.42 ns |     4.53 ns |   4,625 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     758.3 ns |     1.71 ns |     1.60 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,064.0 ns |     2.75 ns |     2.57 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |     623.5 ns |     0.94 ns |     0.78 ns |   4,625 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     760.6 ns |     0.94 ns |     0.83 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,065.1 ns |     2.16 ns |     1.69 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,726.7 ns |     4.57 ns |     3.81 ns |   4,643 B |    1264 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,407.4 ns |     2.20 ns |     2.06 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,471.3 ns |     3.49 ns |     3.10 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,722.8 ns |     3.59 ns |     3.00 ns |   4,641 B |    1272 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,425.0 ns |    33.46 ns |    35.80 ns |   2,911 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,477.8 ns |     5.95 ns |     5.28 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  10,530.3 ns |    20.76 ns |    19.42 ns |   4,574 B |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  13,699.2 ns |    19.28 ns |    15.05 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  15,572.8 ns |    22.73 ns |    21.26 ns |   2,910 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 189,494.5 ns | 1,804.08 ns | 1,599.27 ns |   4,574 B |  131326 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 206,500.4 ns |   445.06 ns |   371.65 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 241,415.1 ns |   680.93 ns |   603.62 ns |   2,911 B |         - |