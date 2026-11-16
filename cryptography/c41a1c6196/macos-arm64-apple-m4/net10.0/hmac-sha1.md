| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     390.8 ns |     0.33 ns |     0.31 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     612.9 ns |     3.81 ns |     3.57 ns |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     672.6 ns |     3.29 ns |     3.08 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     393.1 ns |     1.16 ns |     1.08 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     607.6 ns |     2.35 ns |     2.08 ns |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     675.7 ns |     3.01 ns |     2.81 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |     893.1 ns |     1.93 ns |     1.81 ns |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   1,400.2 ns |     2.06 ns |     1.93 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,882.5 ns |    18.97 ns |    16.82 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |     888.3 ns |     1.79 ns |     1.67 ns |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   1,393.8 ns |     2.28 ns |     2.13 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,897.2 ns |    11.20 ns |     9.36 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   3,267.2 ns |     4.40 ns |     4.11 ns |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |   9,378.0 ns |     8.61 ns |     8.05 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  19,164.3 ns |    98.64 ns |    92.27 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        |  48,488.0 ns |    85.20 ns |    79.70 ns |  131268 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 146,144.0 ns |   131.58 ns |   123.08 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 324,020.2 ns | 3,774.54 ns | 3,530.71 ns |         - |