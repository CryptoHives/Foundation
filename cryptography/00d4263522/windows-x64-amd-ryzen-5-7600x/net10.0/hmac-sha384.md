| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |     631.8 ns |   1.53 ns |   1.28 ns |   4,625 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     773.7 ns |   0.98 ns |   0.87 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,083.3 ns |   6.22 ns |   5.19 ns |   1,443 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |     630.1 ns |   2.05 ns |   1.82 ns |   4,625 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     775.3 ns |   1.39 ns |   1.23 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,084.6 ns |   3.06 ns |   2.72 ns |   1,443 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,755.8 ns |   5.86 ns |   4.90 ns |   4,641 B |    1264 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,448.6 ns |   7.72 ns |   7.22 ns |   2,911 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,520.3 ns |  10.23 ns |   8.55 ns |   1,443 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,757.2 ns |   7.19 ns |   6.73 ns |   4,641 B |    1272 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,448.6 ns |   6.87 ns |   5.73 ns |   2,905 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,533.3 ns |   7.39 ns |   6.55 ns |   1,443 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  10,709.1 ns |  70.43 ns |  65.88 ns |   4,574 B |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  13,939.7 ns |  17.33 ns |  13.53 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  15,817.1 ns |  63.52 ns |  53.04 ns |   2,911 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 191,992.4 ns | 849.46 ns | 709.34 ns |   4,574 B |  131326 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 209,922.2 ns | 362.74 ns | 283.21 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 245,049.8 ns | 634.35 ns | 562.34 ns |   2,905 B |         - |