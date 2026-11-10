| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     844.9 ns |     0.78 ns |     0.73 ns |   5,560 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |   1,490.5 ns |     1.40 ns |     1.31 ns |   2,934 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   1,956.3 ns |    10.35 ns |     9.68 ns |   1,172 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     843.0 ns |     1.24 ns |     1.16 ns |   5,562 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |   1,496.2 ns |     2.41 ns |     2.01 ns |   2,930 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,948.5 ns |     7.35 ns |     6.87 ns |   1,172 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   2,596.9 ns |     4.40 ns |     4.11 ns |   5,572 B |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   5,801.4 ns |    11.43 ns |    10.69 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   6,365.4 ns |    11.99 ns |    10.01 ns |   2,930 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   2,597.2 ns |     3.91 ns |     3.46 ns |   5,572 B |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   5,829.2 ns |    13.98 ns |    11.67 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   6,023.7 ns |    15.65 ns |    13.87 ns |   2,930 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |  16,124.4 ns |    31.69 ns |    28.09 ns |   5,579 B |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  36,471.5 ns |    64.72 ns |    54.05 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  43,694.4 ns |    72.30 ns |    60.38 ns |   2,930 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 313,543.2 ns |   246.89 ns |   206.17 ns |   5,604 B |  131254 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 563,272.6 ns | 2,014.55 ns | 1,785.84 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 708,865.1 ns | 2,498.20 ns | 2,336.82 ns |   2,930 B |         - |