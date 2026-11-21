| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |     379.3 ns |     1.12 ns |     0.94 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     595.9 ns |     2.98 ns |     2.78 ns |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     858.4 ns |    13.89 ns |    12.99 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |     380.4 ns |     0.84 ns |     0.66 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     584.1 ns |     2.76 ns |     2.58 ns |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     866.2 ns |     8.12 ns |     7.20 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |     668.8 ns |     4.25 ns |     3.77 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     890.7 ns |     3.27 ns |     3.06 ns |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,746.0 ns |    73.28 ns |    81.45 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |     672.2 ns |     2.50 ns |     2.34 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     897.2 ns |     3.03 ns |     2.84 ns |    1224 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,741.2 ns |    74.38 ns |    79.59 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |   3,081.2 ns |    10.31 ns |     8.61 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,241.6 ns |     4.27 ns |     4.00 ns |    8384 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  27,266.6 ns |   522.82 ns |   559.41 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        |  44,575.7 ns |    72.43 ns |    56.55 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  51,696.8 ns |   192.96 ns |   180.49 ns |  131290 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 433,149.3 ns | 8,418.04 ns | 8,644.71 ns |         - |