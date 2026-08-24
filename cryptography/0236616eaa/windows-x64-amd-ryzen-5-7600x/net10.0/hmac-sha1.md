| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     402.6 ns |   1.40 ns |   1.24 ns |   4,644 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     609.6 ns |   1.17 ns |   1.09 ns |   2,844 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     960.7 ns |   2.21 ns |   1.73 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     396.6 ns |   1.08 ns |   1.01 ns |   4,644 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     608.3 ns |   0.66 ns |   0.55 ns |   2,848 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     953.2 ns |   2.14 ns |   1.79 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,313.1 ns |   4.05 ns |   3.38 ns |   4,663 B |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,608.7 ns |   3.62 ns |   3.39 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   2,990.8 ns |   5.15 ns |   4.30 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,305.0 ns |   1.43 ns |   1.20 ns |   4,663 B |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,602.6 ns |   4.02 ns |   3.56 ns |   2,844 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   3,003.5 ns |  16.38 ns |  13.68 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   8,693.0 ns |  28.80 ns |  26.94 ns |   4,576 B |    8360 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  18,550.4 ns |  27.82 ns |  24.66 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  19,221.3 ns |  28.75 ns |  24.01 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 161,906.4 ns | 658.85 ns | 550.17 ns |   4,576 B |  131254 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 291,934.2 ns | 893.85 ns | 697.86 ns |   2,821 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 298,206.4 ns | 459.64 ns | 358.85 ns |   1,166 B |         - |