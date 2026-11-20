| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |     700.5 ns |   1.17 ns |   1.03 ns |   8,762 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     864.3 ns |   2.89 ns |   2.41 ns |   5,886 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,137.8 ns |   1.65 ns |   1.46 ns |   4,991 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |     704.4 ns |   1.32 ns |   1.17 ns |   8,758 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     865.4 ns |   0.82 ns |   0.68 ns |   5,886 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,129.0 ns |   2.63 ns |   2.46 ns |   4,982 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,958.0 ns |   5.91 ns |   4.62 ns |  12,605 B |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,616.0 ns |   4.83 ns |   4.03 ns |   4,991 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,750.1 ns |   4.82 ns |   4.27 ns |   5,886 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,959.8 ns |   5.58 ns |   4.94 ns |   8,762 B |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,607.0 ns |   5.08 ns |   4.50 ns |   4,991 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,749.9 ns |   5.26 ns |   4.66 ns |   9,729 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  11,983.5 ns |  25.58 ns |  23.92 ns |   8,801 B |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  14,319.5 ns |  17.92 ns |  14.97 ns |   4,991 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  17,824.6 ns |  18.98 ns |  15.85 ns |   9,729 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 216,157.8 ns | 586.27 ns | 489.57 ns |   4,991 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 223,384.9 ns | 884.29 ns | 738.42 ns |   8,801 B |  131366 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 274,706.2 ns | 454.76 ns | 403.13 ns |   9,926 B |         - |