| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     389.8 ns |     1.20 ns |     1.12 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     594.0 ns |     2.08 ns |     1.95 ns |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     671.7 ns |     2.98 ns |     2.79 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     386.8 ns |     3.06 ns |     2.86 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     584.7 ns |     3.46 ns |     3.24 ns |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     675.3 ns |     2.83 ns |     2.65 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |     882.4 ns |     2.56 ns |     2.39 ns |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   1,396.4 ns |     5.77 ns |     5.40 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,917.0 ns |    12.33 ns |    11.53 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |     879.9 ns |     3.36 ns |     3.14 ns |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   1,389.9 ns |     5.91 ns |     5.52 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,919.7 ns |    10.32 ns |     9.65 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   3,202.2 ns |     6.33 ns |     5.92 ns |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |   9,351.5 ns |    21.92 ns |    18.31 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  20,803.0 ns |   129.74 ns |   121.35 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        |  48,607.0 ns |   182.73 ns |   170.92 ns |  131268 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 145,826.4 ns |   476.74 ns |   445.95 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 326,149.7 ns | 2,580.68 ns | 2,413.97 ns |         - |