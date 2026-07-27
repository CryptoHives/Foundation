| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |     620.8 ns |     2.38 ns |     1.99 ns |   4,625 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     765.6 ns |     2.01 ns |     1.68 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,079.5 ns |     6.55 ns |     5.47 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |     632.5 ns |     1.48 ns |     1.23 ns |   4,625 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     772.2 ns |     2.90 ns |     2.57 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,076.7 ns |     2.54 ns |     2.12 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,752.7 ns |     8.55 ns |     8.00 ns |   4,641 B |    1264 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,442.4 ns |     5.30 ns |     4.14 ns |   2,911 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,516.6 ns |    15.40 ns |    13.66 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,751.2 ns |     4.61 ns |     3.60 ns |   4,641 B |    1272 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,438.6 ns |    10.48 ns |     9.29 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,531.2 ns |    18.07 ns |    16.90 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  10,801.2 ns |    28.60 ns |    23.88 ns |   4,574 B |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  14,016.5 ns |    67.33 ns |    56.22 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  15,774.8 ns |    31.74 ns |    24.78 ns |   2,911 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 193,329.5 ns | 2,675.40 ns | 2,371.67 ns |   4,574 B |  131326 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 209,556.9 ns |   396.75 ns |   309.75 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 245,161.9 ns | 2,282.62 ns | 1,906.09 ns |   2,905 B |         - |