| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       206.5 ns |     0.14 ns |     0.13 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 17B          |       258.0 ns |     0.18 ns |     0.16 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |       705.2 ns |     1.59 ns |     1.49 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     1,109.2 ns |     3.24 ns |     3.03 ns |     310 B |    1624 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       132.4 ns |     0.10 ns |     0.09 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 17B          |       262.6 ns |     0.64 ns |     0.60 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |       624.9 ns |     1.37 ns |     1.21 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |       967.7 ns |     1.53 ns |     1.36 ns |     390 B |    1608 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       212.9 ns |     0.13 ns |     0.11 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 65B          |       264.2 ns |     0.27 ns |     0.25 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     1,257.6 ns |     2.94 ns |     2.75 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     1,491.2 ns |     1.72 ns |     1.53 ns |     310 B |    1624 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       141.8 ns |     0.21 ns |     0.19 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 65B          |       271.5 ns |     0.36 ns |     0.34 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     1,180.3 ns |     6.18 ns |     5.78 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     1,306.7 ns |     2.26 ns |     2.12 ns |     387 B |    1608 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       221.3 ns |     0.15 ns |     0.14 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 128B         |       258.5 ns |     0.22 ns |     0.18 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     1,818.3 ns |     1.97 ns |     1.84 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     1,832.2 ns |     6.40 ns |     5.99 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       137.7 ns |     0.17 ns |     0.16 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 128B         |       264.2 ns |     0.28 ns |     0.24 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     1,628.2 ns |     1.90 ns |     1.78 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     1,800.5 ns |     4.72 ns |     4.41 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       249.2 ns |     0.22 ns |     0.21 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |       290.2 ns |     0.19 ns |     0.18 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |     2,088.2 ns |     2.07 ns |     1.73 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     2,189.2 ns |     9.33 ns |     7.79 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       189.6 ns |     0.18 ns |     0.16 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |       285.3 ns |     0.18 ns |     0.15 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     1,895.8 ns |     1.76 ns |     1.64 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     2,152.8 ns |     8.78 ns |     8.21 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       283.2 ns |     0.23 ns |     0.21 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |       296.8 ns |     0.37 ns |     0.30 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |     2,717.3 ns |     7.66 ns |     6.39 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     3,350.8 ns |     8.89 ns |     8.32 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       183.7 ns |     0.15 ns |     0.13 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |       292.3 ns |     0.22 ns |     0.20 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |     2,533.9 ns |     5.22 ns |     4.89 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     3,274.7 ns |     5.77 ns |     5.12 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |       471.9 ns |     0.28 ns |     0.23 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       575.0 ns |     0.59 ns |     0.52 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     8,109.4 ns |    11.68 ns |    10.92 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |    12,201.5 ns |    15.90 ns |    14.87 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       468.7 ns |     0.41 ns |     0.38 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |       479.6 ns |     0.43 ns |     0.40 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     7,905.3 ns |     9.72 ns |     8.62 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |    12,076.1 ns |    34.52 ns |    30.60 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |     2,202.4 ns |     2.82 ns |     2.20 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,372.7 ns |     2.38 ns |     1.99 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    58,015.0 ns |    39.72 ns |    33.16 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    94,502.7 ns |   215.73 ns |   201.79 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |     2,175.6 ns |     2.01 ns |     1.78 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,164.3 ns |     2.66 ns |     2.49 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    57,742.3 ns |    45.86 ns |    40.66 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    94,335.8 ns |   196.92 ns |   184.20 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |    35,817.2 ns |    81.24 ns |    72.02 ns |   2,330 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    50,369.8 ns |    22.04 ns |    20.61 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   919,405.1 ns |   646.29 ns |   604.54 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 1,503,449.9 ns | 3,022.90 ns | 2,679.72 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |    31,432.1 ns |    29.91 ns |    26.51 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    48,838.3 ns |    51.04 ns |    47.74 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   911,875.2 ns |   949.38 ns |   888.05 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 1,502,210.1 ns | 2,657.29 ns | 2,355.62 ns |     387 B |         - |