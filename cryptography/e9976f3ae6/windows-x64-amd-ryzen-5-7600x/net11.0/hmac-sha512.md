| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Median       | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |     727.7 ns |  14.05 ns |  16.18 ns |     716.7 ns |  12,605 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     864.7 ns |   0.92 ns |   0.82 ns |     864.4 ns |   5,886 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,130.7 ns |   3.69 ns |   3.27 ns |   1,129.6 ns |   4,982 B |         - |
|                                               |              |              |           |           |              |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |     697.7 ns |   1.01 ns |   0.89 ns |     697.3 ns |   8,762 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     867.1 ns |   1.71 ns |   1.51 ns |     866.6 ns |   5,886 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,121.6 ns |   1.40 ns |   1.24 ns |   1,121.5 ns |   4,991 B |         - |
|                                               |              |              |           |           |              |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,950.9 ns |   5.84 ns |   5.46 ns |   1,951.3 ns |   8,762 B |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,608.1 ns |   2.03 ns |   1.80 ns |   2,608.5 ns |   4,982 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,745.6 ns |   2.76 ns |   2.45 ns |   2,744.8 ns |   5,886 B |         - |
|                                               |              |              |           |           |              |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,949.3 ns |   2.05 ns |   1.82 ns |   1,949.5 ns |  12,791 B |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,599.7 ns |   3.39 ns |   3.01 ns |   2,600.0 ns |   4,991 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,747.0 ns |   5.93 ns |   5.25 ns |   2,745.9 ns |   9,729 B |         - |
|                                               |              |              |           |           |              |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  11,994.8 ns |  25.39 ns |  22.51 ns |  11,995.0 ns |  12,471 B |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  14,390.0 ns |  29.69 ns |  26.32 ns |  14,382.6 ns |   4,991 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  17,745.5 ns |  22.26 ns |  19.73 ns |  17,744.8 ns |   9,729 B |         - |
|                                               |              |              |           |           |              |           |           |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 215,582.5 ns | 326.99 ns | 289.87 ns | 215,526.8 ns |   4,982 B |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 222,818.4 ns | 585.18 ns | 547.38 ns | 222,819.8 ns |   8,801 B |  131414 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 274,812.1 ns | 286.41 ns | 239.16 ns | 274,807.2 ns |   5,893 B |         - |