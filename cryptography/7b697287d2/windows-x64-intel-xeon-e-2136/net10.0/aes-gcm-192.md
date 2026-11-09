| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       153.1 ns |     0.24 ns |     0.20 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 17B          |       193.4 ns |     0.45 ns |     0.42 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       545.7 ns |     1.07 ns |     0.89 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |       894.4 ns |     4.69 ns |     4.39 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       101.6 ns |     0.19 ns |     0.18 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 17B          |       204.0 ns |     0.52 ns |     0.46 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       486.0 ns |     1.17 ns |     1.10 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |       778.3 ns |     1.38 ns |     1.15 ns |     387 B |    1712 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       158.7 ns |     0.51 ns |     0.45 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 65B          |       197.3 ns |     0.48 ns |     0.45 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |       975.0 ns |     2.41 ns |     2.25 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     1,202.6 ns |     2.99 ns |     2.80 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       110.1 ns |     0.14 ns |     0.12 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 65B          |       206.4 ns |     0.35 ns |     0.33 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |       918.5 ns |     1.77 ns |     1.48 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     1,076.4 ns |     4.64 ns |     4.34 ns |     390 B |    1712 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       171.9 ns |     0.59 ns |     0.53 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 128B         |       196.5 ns |     0.38 ns |     0.35 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,429.5 ns |     4.24 ns |     3.54 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     1,494.0 ns |     2.84 ns |     2.52 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       106.7 ns |     0.30 ns |     0.24 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 128B         |       200.4 ns |     0.50 ns |     0.44 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     1,348.3 ns |     3.70 ns |     3.28 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,419.5 ns |     2.77 ns |     2.45 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       190.8 ns |     0.27 ns |     0.25 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |       224.6 ns |     0.54 ns |     0.50 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     1,699.6 ns |     4.58 ns |     4.28 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |     1,710.0 ns |     2.77 ns |     2.46 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       146.4 ns |     0.37 ns |     0.35 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 152B         |       219.8 ns |     0.40 ns |     0.35 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |     1,562.3 ns |     4.14 ns |     3.87 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     1,690.3 ns |     2.97 ns |     2.78 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       213.0 ns |     1.05 ns |     0.98 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |       221.7 ns |     0.90 ns |     0.80 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |     2,264.7 ns |    20.98 ns |    23.31 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     2,621.5 ns |     5.52 ns |     4.61 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       145.7 ns |     0.46 ns |     0.43 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |       222.9 ns |     0.55 ns |     0.46 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |     2,124.9 ns |     8.06 ns |     7.14 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     2,569.6 ns |     4.78 ns |     4.47 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |       364.2 ns |     1.17 ns |     1.10 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       443.9 ns |     0.72 ns |     0.60 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     6,853.7 ns |    13.30 ns |    12.44 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |     9,558.0 ns |    17.20 ns |    15.25 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |       370.1 ns |     0.81 ns |     0.76 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       378.0 ns |     0.61 ns |     0.57 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     6,702.9 ns |    11.11 ns |     9.85 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |     9,447.0 ns |    18.43 ns |    17.24 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |     1,798.2 ns |     2.67 ns |     2.09 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     2,646.9 ns |     4.98 ns |     4.41 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    49,616.2 ns |   126.80 ns |   118.61 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |    73,905.9 ns |   156.24 ns |   146.14 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |     1,795.8 ns |     3.29 ns |     2.91 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     2,575.8 ns |     5.67 ns |     5.02 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    49,381.1 ns |    85.83 ns |    80.29 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |    73,813.1 ns |   183.99 ns |   172.10 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |    25,733.1 ns |    27.32 ns |    25.56 ns |   2,330 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    39,636.8 ns |    85.59 ns |    75.87 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        |   784,652.4 ns | 1,548.59 ns | 1,372.78 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 1,174,789.5 ns | 1,845.09 ns | 1,540.73 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |    25,357.7 ns |    49.46 ns |    43.85 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    39,845.8 ns |    78.95 ns |    73.85 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        |   779,855.0 ns | 1,599.28 ns | 1,495.96 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 1,175,912.0 ns | 3,064.36 ns | 2,866.40 ns |     387 B |         - |