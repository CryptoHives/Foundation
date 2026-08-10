| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |     636.8 ns |     4.37 ns |     3.65 ns |   4,626 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     770.3 ns |     1.80 ns |     1.51 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,087.1 ns |     7.88 ns |     7.37 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |     629.7 ns |     6.23 ns |     5.53 ns |   4,626 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     774.9 ns |     2.48 ns |     2.32 ns |   2,905 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,087.7 ns |    11.21 ns |    10.48 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,757.1 ns |    16.21 ns |    15.16 ns |   4,626 B |    1312 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,440.6 ns |    12.80 ns |    11.35 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,516.3 ns |    16.96 ns |    15.03 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,752.1 ns |    12.16 ns |    10.15 ns |   4,624 B |    1320 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,437.7 ns |     5.77 ns |     4.50 ns |   2,905 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,507.7 ns |     3.69 ns |     3.08 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  10,788.9 ns |    71.38 ns |    66.77 ns |   4,576 B |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,981.9 ns |    34.67 ns |    27.07 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  15,711.4 ns |    43.08 ns |    35.97 ns |   2,911 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 193,193.7 ns | 2,024.68 ns | 1,794.82 ns |   4,576 B |  131374 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 208,853.8 ns |   531.17 ns |   443.55 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 243,891.6 ns |   677.56 ns |   528.99 ns |   2,905 B |         - |