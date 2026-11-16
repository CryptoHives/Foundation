| Description                                   | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |     704.2 ns |     4.86 ns |   4.55 ns |   5,516 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     884.2 ns |     8.61 ns |   7.63 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,130.8 ns |     6.61 ns |   5.52 ns |   1,656 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |     710.0 ns |     6.18 ns |   5.48 ns |   5,522 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     885.3 ns |     8.01 ns |   6.69 ns |   2,943 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,137.9 ns |    10.26 ns |   9.60 ns |   1,656 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,977.8 ns |     6.79 ns |   5.67 ns |   5,532 B |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,598.1 ns |     4.05 ns |   3.38 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,749.9 ns |    13.61 ns |  11.36 ns |   2,963 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,978.1 ns |     7.21 ns |   6.02 ns |   5,532 B |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,595.5 ns |     5.11 ns |   4.53 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,765.2 ns |    18.84 ns |  17.63 ns |   2,950 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  12,166.6 ns |    46.31 ns |  43.31 ns |   5,553 B |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  14,226.9 ns |    23.52 ns |  20.85 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  17,766.0 ns |    53.27 ns |  41.59 ns |   2,963 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 216,993.2 ns | 1,144.56 ns | 955.76 ns |   5,553 B |  131326 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 217,821.2 ns |   644.35 ns | 538.06 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 276,069.8 ns | 1,117.79 ns | 933.40 ns |   2,943 B |         - |