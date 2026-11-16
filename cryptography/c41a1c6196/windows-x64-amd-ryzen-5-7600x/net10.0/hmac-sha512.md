| Description                                   | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |     703.5 ns |     4.43 ns |   3.93 ns |   5,517 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     865.3 ns |     1.65 ns |   1.38 ns |   2,943 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,124.0 ns |     2.14 ns |   1.90 ns |   1,656 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |     700.7 ns |     3.18 ns |   2.66 ns |   5,517 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     870.3 ns |     3.57 ns |   2.98 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,124.8 ns |     3.55 ns |   3.15 ns |   1,656 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,985.1 ns |    11.37 ns |  10.08 ns |   5,537 B |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,621.8 ns |    10.77 ns |  10.07 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,790.0 ns |    23.76 ns |  21.06 ns |   2,963 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,998.9 ns |    23.68 ns |  19.78 ns |   5,515 B |    1320 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,770.0 ns |     9.75 ns |   8.64 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,796.9 ns |    14.54 ns |  13.60 ns |   1,656 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  11,994.6 ns |    90.56 ns |  80.28 ns |   5,555 B |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  14,478.6 ns |   110.95 ns |  98.36 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  17,767.4 ns |    59.06 ns |  49.32 ns |   2,963 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 214,711.3 ns | 1,176.89 ns | 982.76 ns |   5,555 B |  131374 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 216,782.2 ns |   218.12 ns | 182.14 ns |   1,656 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 275,345.1 ns |   750.13 ns | 626.39 ns |   2,943 B |         - |