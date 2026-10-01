| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     441.3 ns |   0.40 ns |   0.33 ns |   5,536 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     696.0 ns |   0.60 ns |   0.56 ns |   2,884 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   1,049.9 ns |   0.89 ns |   0.74 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     444.1 ns |   0.40 ns |   0.38 ns |   5,536 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     699.3 ns |   0.51 ns |   0.48 ns |   2,876 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,044.4 ns |   1.22 ns |   1.14 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,487.8 ns |   1.96 ns |   1.74 ns |   5,557 B |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,973.8 ns |   1.90 ns |   1.68 ns |   2,876 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   3,289.1 ns |   2.12 ns |   1.88 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,480.5 ns |   1.30 ns |   1.22 ns |   5,557 B |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,972.1 ns |   1.90 ns |   1.77 ns |   2,876 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   3,293.5 ns |   1.98 ns |   1.85 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   9,817.1 ns |  19.15 ns |  15.99 ns |   5,558 B |    8360 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  21,149.7 ns |  16.23 ns |  14.39 ns |   2,876 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  21,193.3 ns |  25.83 ns |  24.16 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 184,901.6 ns | 393.60 ns | 368.17 ns |   5,558 B |  131254 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 327,912.6 ns | 301.63 ns | 282.14 ns |   1,166 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 332,828.3 ns | 248.03 ns | 207.12 ns |   2,876 B |         - |