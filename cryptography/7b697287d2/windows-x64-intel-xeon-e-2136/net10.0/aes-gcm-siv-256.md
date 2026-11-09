| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       388.8 ns |     0.50 ns |     0.42 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,957.4 ns |     3.77 ns |     3.34 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     2,814.4 ns |     7.20 ns |     6.38 ns |     310 B |    3408 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       321.9 ns |     0.74 ns |     0.66 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,841.3 ns |     4.70 ns |     4.40 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     2,723.0 ns |     5.51 ns |     4.89 ns |     387 B |    2960 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,152.7 ns |     2.23 ns |     2.09 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     9,445.9 ns |    26.20 ns |    23.22 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |    11,851.2 ns |    23.63 ns |    20.95 ns |     310 B |    7832 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,087.1 ns |     2.36 ns |     2.21 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     9,094.6 ns |    17.87 ns |    16.72 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |    11,156.9 ns |    38.60 ns |    36.11 ns |     387 B |    3728 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     7,230.8 ns |    17.68 ns |    16.54 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    65,936.5 ns |   676.82 ns |   565.17 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |    84,401.9 ns |   224.78 ns |   210.26 ns |     310 B |   43744 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     7,169.0 ns |    15.19 ns |    14.21 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    66,142.9 ns |   146.56 ns |   129.92 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |    78,879.3 ns |   170.85 ns |   151.45 ns |     387 B |   10896 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   111,614.5 ns |   157.42 ns |   131.45 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,045,296.7 ns | 3,333.63 ns | 2,955.17 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,474,004.3 ns | 4,558.64 ns | 4,041.11 ns |     310 B |  658352 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   111,642.8 ns |   216.88 ns |   192.26 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,005,448.4 ns | 2,987.02 ns | 2,794.06 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,281,120.0 ns | 2,620.41 ns | 2,322.92 ns |     387 B |  133804 B |