| Description                                   | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |     613.1 ns |     1.53 ns |   1.35 ns |   4,626 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     761.3 ns |     3.13 ns |   2.61 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,069.4 ns |     7.58 ns |   7.09 ns |   1,443 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |     611.6 ns |     1.68 ns |   1.40 ns |   4,626 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     766.2 ns |     1.15 ns |   0.96 ns |   2,911 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,077.6 ns |     1.58 ns |   1.40 ns |   1,443 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,712.9 ns |     4.77 ns |   4.23 ns |   4,646 B |    1312 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,409.8 ns |     3.57 ns |   3.17 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,487.7 ns |     6.42 ns |   6.00 ns |   1,443 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,716.1 ns |     4.19 ns |   3.71 ns |   4,624 B |    1320 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,411.1 ns |     5.95 ns |   5.28 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,484.9 ns |     7.12 ns |   6.31 ns |   1,443 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  10,533.5 ns |    63.74 ns |  49.76 ns |   4,576 B |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,834.0 ns |    28.31 ns |  25.10 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  15,584.4 ns |    34.47 ns |  28.79 ns |   2,911 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 188,337.4 ns | 1,005.37 ns | 839.53 ns |   4,576 B |  131374 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 208,681.3 ns | 1,044.06 ns | 815.13 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 241,388.7 ns |   376.40 ns | 333.67 ns |   2,905 B |         - |