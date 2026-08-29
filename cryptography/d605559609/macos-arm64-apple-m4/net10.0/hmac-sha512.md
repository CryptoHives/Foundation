| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     901.3 ns |    17.04 ns |    20.29 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,011.5 ns |     2.40 ns |     2.01 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1,111.7 ns |     4.19 ns |     3.92 ns |     416 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     898.6 ns |    17.41 ns |    18.63 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,012.2 ns |     2.65 ns |     2.21 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1,089.2 ns |     7.41 ns |     6.93 ns |     432 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,585.7 ns |     8.47 ns |     7.93 ns |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,395.9 ns |     8.53 ns |     6.66 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,911.8 ns |    53.87 ns |    50.39 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,583.9 ns |     4.92 ns |     4.36 ns |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,396.1 ns |     4.75 ns |     3.71 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,839.4 ns |    54.97 ns |    78.84 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |   6,007.8 ns |     2.44 ns |     2.29 ns |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,668.1 ns |    97.17 ns |    81.14 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  18,710.7 ns |   363.55 ns |   555.18 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        |  85,786.9 ns |   178.24 ns |   158.00 ns |  131388 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 205,274.5 ns |   480.59 ns |   375.21 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 292,503.2 ns | 5,787.97 ns | 9,346.50 ns |         - |