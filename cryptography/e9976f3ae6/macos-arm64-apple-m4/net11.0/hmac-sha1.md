| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     401.5 ns |     0.21 ns |     0.20 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     610.3 ns |     2.24 ns |     1.99 ns |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     693.3 ns |     3.41 ns |     3.02 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     405.5 ns |     0.62 ns |     0.58 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     598.2 ns |     1.91 ns |     1.59 ns |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     672.5 ns |     2.99 ns |     2.80 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |     893.6 ns |     2.16 ns |     2.02 ns |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   1,407.8 ns |     2.83 ns |     2.64 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,941.4 ns |     8.00 ns |     7.09 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |     893.0 ns |     1.31 ns |     1.23 ns |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   1,405.2 ns |     1.80 ns |     1.68 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,920.5 ns |    15.38 ns |    14.39 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   3,240.5 ns |     2.66 ns |     2.36 ns |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |   9,408.3 ns |     9.47 ns |     8.86 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  20,768.8 ns |   106.71 ns |    99.82 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        |  51,819.0 ns |   139.40 ns |   130.39 ns |  131266 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 146,658.1 ns |   230.08 ns |   203.96 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 329,166.3 ns | 1,390.25 ns | 1,300.44 ns |         - |