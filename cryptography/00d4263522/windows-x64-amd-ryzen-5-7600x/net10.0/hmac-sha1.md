| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     400.3 ns |   1.38 ns |   1.15 ns |   4,644 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     620.6 ns |   1.09 ns |   0.91 ns |   2,844 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     972.3 ns |   1.20 ns |   1.00 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     407.2 ns |   2.35 ns |   2.08 ns |   4,644 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     621.6 ns |   2.10 ns |   1.86 ns |   2,848 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     968.7 ns |   2.08 ns |   1.74 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,337.0 ns |   1.48 ns |   1.23 ns |   4,663 B |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,657.3 ns |  10.63 ns |   9.43 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   3,044.1 ns |   9.33 ns |   8.27 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,335.7 ns |   9.28 ns |   7.75 ns |   4,663 B |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,649.9 ns |   7.24 ns |   6.77 ns |   2,844 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   3,042.2 ns |  21.12 ns |  18.72 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   8,876.1 ns |  39.26 ns |  36.72 ns |   4,576 B |    8360 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  18,823.4 ns |  28.21 ns |  22.03 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  19,484.3 ns |  23.66 ns |  19.75 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 166,209.8 ns | 687.63 ns | 609.57 ns |   4,576 B |  131254 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 297,393.4 ns | 710.73 ns | 664.82 ns |   2,828 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 302,156.2 ns | 684.56 ns | 571.64 ns |   1,166 B |         - |