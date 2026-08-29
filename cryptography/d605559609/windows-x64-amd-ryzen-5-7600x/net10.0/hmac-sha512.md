| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |     622.8 ns |     2.61 ns |     2.31 ns |   4,626 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     765.0 ns |     2.45 ns |     2.29 ns |   2,911 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,080.4 ns |     3.12 ns |     2.61 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |     620.0 ns |     5.57 ns |     5.21 ns |   4,626 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     771.7 ns |     1.16 ns |     1.02 ns |   2,911 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,082.0 ns |     3.95 ns |     3.50 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,729.6 ns |     7.35 ns |     6.87 ns |   4,646 B |    1312 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,426.4 ns |     6.41 ns |     5.69 ns |   2,906 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,509.0 ns |    17.08 ns |    15.97 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,733.4 ns |     7.33 ns |     6.49 ns |   4,624 B |    1320 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,432.1 ns |     3.58 ns |     2.99 ns |   2,911 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,528.4 ns |     4.66 ns |     3.89 ns |   1,443 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  10,613.3 ns |    43.37 ns |    38.45 ns |   4,576 B |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,860.8 ns |    42.60 ns |    33.26 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  15,669.4 ns |    46.52 ns |    43.51 ns |   2,911 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 190,572.4 ns | 1,210.76 ns | 1,073.31 ns |   4,576 B |  131374 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 210,669.2 ns | 1,970.46 ns | 1,645.42 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 242,272.2 ns |   388.99 ns |   303.70 ns |   2,911 B |         - |