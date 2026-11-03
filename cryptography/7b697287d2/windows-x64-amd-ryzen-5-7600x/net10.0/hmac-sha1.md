| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     447.0 ns |   0.63 ns |   0.59 ns |   5,533 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     695.2 ns |   1.40 ns |   1.31 ns |   2,894 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   1,021.8 ns |   3.93 ns |   3.68 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     446.8 ns |   0.68 ns |   0.63 ns |   5,533 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     698.6 ns |   1.26 ns |   1.12 ns |   2,894 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,022.0 ns |   1.33 ns |   1.24 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,486.4 ns |   2.53 ns |   2.36 ns |   5,556 B |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,980.6 ns |   5.76 ns |   5.39 ns |   2,902 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   3,174.7 ns |   6.02 ns |   5.63 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,490.6 ns |   2.63 ns |   2.46 ns |   5,556 B |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,979.9 ns |   3.65 ns |   3.41 ns |   2,894 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   3,181.6 ns |   5.16 ns |   4.82 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   9,848.7 ns |  25.50 ns |  23.85 ns |   5,555 B |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  20,391.8 ns |  35.12 ns |  32.86 ns |   1,166 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  21,250.8 ns |  39.71 ns |  37.14 ns |   2,902 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 184,842.6 ns | 304.34 ns | 284.68 ns |   5,555 B |  131254 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 315,448.9 ns | 754.55 ns | 668.89 ns |   1,166 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 333,885.8 ns | 645.89 ns | 604.16 ns |   2,894 B |         - |