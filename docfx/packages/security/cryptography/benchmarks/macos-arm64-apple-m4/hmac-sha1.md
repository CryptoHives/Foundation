| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     624.4 ns |     2.34 ns |     2.19 ns |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     661.2 ns |     0.93 ns |     0.87 ns |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   1,070.6 ns |     3.37 ns |     2.81 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     609.5 ns |     1.46 ns |     1.37 ns |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     667.1 ns |     0.97 ns |     0.91 ns |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,068.5 ns |     2.48 ns |     2.20 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |     910.5 ns |     2.80 ns |     2.62 ns |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,888.3 ns |     6.65 ns |     6.22 ns |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   3,421.2 ns |    10.90 ns |     9.10 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |     906.6 ns |     2.92 ns |     2.74 ns |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,876.3 ns |     7.81 ns |     7.31 ns |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   3,425.1 ns |     8.05 ns |     6.72 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   3,201.4 ns |     4.74 ns |     4.20 ns |    8360 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  20,542.5 ns |    93.69 ns |    87.63 ns |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  22,270.9 ns |    83.27 ns |    65.01 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        |  49,032.1 ns |    65.37 ns |    61.15 ns |  131268 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 323,035.7 ns | 1,348.43 ns | 1,261.32 ns |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 344,359.7 ns |   829.84 ns |   692.95 ns |         - |