| Description                                 | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     428.0 ns |     0.78 ns |   0.73 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     657.8 ns |     1.42 ns |   1.33 ns |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     692.1 ns |     0.63 ns |   0.56 ns |         - |
|                                             |              |              |             |           |           |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     405.5 ns |     2.04 ns |   1.70 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     622.7 ns |     2.46 ns |   2.18 ns |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     640.8 ns |     0.93 ns |   0.78 ns |         - |
|                                             |              |              |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |     917.2 ns |     5.90 ns |   5.23 ns |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   1,379.7 ns |     2.25 ns |   1.76 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,946.5 ns |     4.11 ns |   3.85 ns |         - |
|                                             |              |              |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |     916.3 ns |     3.92 ns |   3.47 ns |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   1,382.1 ns |     2.83 ns |   2.36 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,950.4 ns |     4.39 ns |   3.89 ns |         - |
|                                             |              |              |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   3,203.5 ns |     6.32 ns |   5.28 ns |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |   9,312.8 ns |     1.76 ns |   1.47 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  20,777.8 ns |   138.85 ns | 129.88 ns |         - |
|                                             |              |              |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        |  48,641.4 ns |   445.36 ns | 416.59 ns |  131268 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 145,217.4 ns |    63.79 ns |  49.80 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 331,042.8 ns | 1,034.50 ns | 967.67 ns |         - |