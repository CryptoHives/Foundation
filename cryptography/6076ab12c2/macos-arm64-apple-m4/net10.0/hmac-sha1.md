| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     389.4 ns |     0.17 ns |     0.15 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     592.6 ns |     1.10 ns |     1.03 ns |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     662.1 ns |     2.80 ns |     2.62 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     386.4 ns |     0.08 ns |     0.07 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     579.1 ns |     1.24 ns |     1.16 ns |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     662.4 ns |     3.76 ns |     3.52 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |     881.4 ns |     1.33 ns |     1.24 ns |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   1,380.9 ns |     2.83 ns |     2.65 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,865.3 ns |     7.48 ns |     6.99 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |     878.6 ns |     1.28 ns |     1.19 ns |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   1,381.9 ns |     2.84 ns |     2.66 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,720.5 ns |    34.32 ns |    32.10 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   3,367.5 ns |    19.26 ns |    18.02 ns |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |   9,717.2 ns |    53.40 ns |    49.95 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  21,349.6 ns |    84.61 ns |    79.15 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        |  51,875.4 ns |   185.65 ns |   155.02 ns |  131268 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 153,707.8 ns |   917.37 ns |   813.22 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 333,919.4 ns | 2,013.43 ns | 1,883.36 ns |         - |