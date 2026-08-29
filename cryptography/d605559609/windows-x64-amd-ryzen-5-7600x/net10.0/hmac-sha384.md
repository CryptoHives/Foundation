| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |     626.1 ns |     3.87 ns |     3.23 ns |   4,625 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     764.7 ns |     2.91 ns |     2.43 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,084.5 ns |    11.14 ns |     9.30 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |     622.7 ns |     2.33 ns |     1.94 ns |   4,625 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     769.1 ns |     2.64 ns |     2.34 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,078.3 ns |     3.62 ns |     3.21 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,748.5 ns |     5.92 ns |     4.62 ns |   4,643 B |    1264 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,417.6 ns |     3.32 ns |     2.78 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,511.7 ns |     5.43 ns |     4.54 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,736.6 ns |     8.52 ns |     6.66 ns |   4,641 B |    1272 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,429.3 ns |     9.13 ns |     8.09 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,518.9 ns |    12.13 ns |    10.13 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  10,631.8 ns |    57.00 ns |    55.99 ns |   4,574 B |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  14,000.1 ns |    46.06 ns |    40.83 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  15,644.7 ns |    41.80 ns |    37.05 ns |   2,911 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 190,303.2 ns |   824.20 ns |   730.63 ns |   4,574 B |  131326 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 209,054.4 ns | 1,407.53 ns | 1,316.60 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 242,664.2 ns |   524.13 ns |   490.28 ns |   2,911 B |         - |