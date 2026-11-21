| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       524.8 ns |     0.80 ns |     0.74 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     2,520.1 ns |     4.07 ns |     3.61 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     3,574.3 ns |    10.09 ns |     8.95 ns |     310 B |    3408 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       437.8 ns |     0.38 ns |     0.35 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     2,465.0 ns |     7.72 ns |     7.22 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     3,400.0 ns |     8.58 ns |     7.61 ns |     390 B |    2960 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,555.6 ns |     1.86 ns |     1.74 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    11,937.6 ns |    32.45 ns |    30.36 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |    14,711.1 ns |    21.25 ns |    19.88 ns |     310 B |    7832 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,469.7 ns |     3.08 ns |     2.88 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    12,262.7 ns |    38.39 ns |    35.91 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |    13,932.9 ns |    19.13 ns |    17.89 ns |     390 B |    3728 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     9,769.1 ns |    13.71 ns |    12.82 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    85,989.6 ns |   263.50 ns |   233.59 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |   106,061.6 ns |   263.43 ns |   233.53 ns |     310 B |   43744 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     9,693.2 ns |     7.24 ns |     6.77 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    89,443.3 ns |   245.83 ns |   229.95 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |    98,179.4 ns |   140.42 ns |   131.35 ns |     390 B |   10896 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   150,904.3 ns |   158.69 ns |   148.43 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,350,758.2 ns | 4,042.28 ns | 3,781.15 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,918,557.2 ns | 2,373.88 ns | 2,104.38 ns |     310 B |  658455 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   151,019.1 ns |   268.34 ns |   237.87 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,370,094.6 ns | 2,137.72 ns | 1,895.03 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,608,886.8 ns | 1,099.66 ns |   974.82 ns |     390 B |  133829 B |