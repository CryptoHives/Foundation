| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       314.3 ns |     0.77 ns |     0.72 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,606.8 ns |     4.80 ns |     4.49 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |     2,190.7 ns |     5.11 ns |     4.78 ns |     310 B |    2992 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       244.7 ns |     0.53 ns |     0.44 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,438.8 ns |     2.50 ns |     2.21 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |     2,016.0 ns |     7.55 ns |     6.69 ns |     387 B |    2544 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |       967.4 ns |     2.20 ns |     2.06 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     7,897.9 ns |    24.06 ns |    22.50 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |     9,809.5 ns |    23.31 ns |    20.67 ns |     310 B |    7416 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |       896.9 ns |     1.40 ns |     1.24 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     7,777.6 ns |    14.91 ns |    12.45 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |     9,050.7 ns |    23.11 ns |    20.48 ns |     387 B |    3312 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     6,165.7 ns |    13.13 ns |    12.28 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    61,624.8 ns |   168.58 ns |   157.69 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |    71,048.6 ns |   104.07 ns |    86.90 ns |     310 B |   43328 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     6,170.1 ns |   106.30 ns |    99.43 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    56,870.8 ns |   170.47 ns |   159.46 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |    64,851.4 ns |   176.30 ns |   164.91 ns |     387 B |   10480 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |    95,511.2 ns |   270.46 ns |   252.98 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        |   936,152.2 ns | 1,091.83 ns | 1,021.30 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 1,241,065.9 ns | 4,232.44 ns | 3,959.03 ns |     310 B |  657936 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |    95,400.5 ns |   193.03 ns |   171.12 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        |   872,328.3 ns | 4,017.78 ns | 3,758.23 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 1,070,895.0 ns | 2,514.23 ns | 2,099.50 ns |     387 B |  133388 B |