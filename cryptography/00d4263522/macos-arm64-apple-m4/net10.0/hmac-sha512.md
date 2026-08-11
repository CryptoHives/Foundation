| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     871.0 ns |    10.10 ns |     9.45 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,017.2 ns |     3.01 ns |     2.67 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1,097.4 ns |     6.73 ns |     6.29 ns |     416 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     876.2 ns |     2.56 ns |     2.40 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,020.1 ns |     3.88 ns |     3.44 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1,072.4 ns |     8.15 ns |     7.62 ns |     432 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,559.5 ns |     8.18 ns |     7.65 ns |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,401.9 ns |    13.32 ns |    12.46 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,768.8 ns |    19.77 ns |    18.49 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,561.2 ns |     5.96 ns |     5.58 ns |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,410.8 ns |     3.29 ns |     3.08 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,779.5 ns |    13.95 ns |    13.05 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |   5,491.2 ns |    22.97 ns |    21.48 ns |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,504.7 ns |    35.55 ns |    31.51 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  17,994.7 ns |   251.97 ns |   235.69 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        |  78,356.4 ns |   509.29 ns |   476.39 ns |  131388 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 203,291.5 ns |   796.49 ns |   745.04 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 272,663.5 ns | 5,362.39 ns | 7,158.64 ns |         - |