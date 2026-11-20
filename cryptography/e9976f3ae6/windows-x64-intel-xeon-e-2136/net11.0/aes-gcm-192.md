| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       206.9 ns |     0.13 ns |     0.11 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 17B          |       268.1 ns |     0.55 ns |     0.46 ns |   2,390 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       734.6 ns |     3.97 ns |     3.72 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     1,144.8 ns |     4.44 ns |     3.93 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       137.6 ns |     0.17 ns |     0.15 ns |     390 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 17B          |       277.0 ns |     3.30 ns |     3.09 ns |   2,268 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       642.7 ns |     2.17 ns |     2.03 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     1,020.9 ns |     4.36 ns |     3.86 ns |     390 B |    1712 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       211.9 ns |     0.51 ns |     0.40 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 65B          |       267.7 ns |     1.32 ns |     1.24 ns |   2,390 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     1,255.4 ns |     9.41 ns |     8.80 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     1,541.7 ns |     2.48 ns |     2.32 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       154.2 ns |     0.89 ns |     0.70 ns |     390 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 65B          |       284.9 ns |     0.97 ns |     0.86 ns |  14,416 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     1,172.0 ns |     4.23 ns |     3.53 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     1,363.2 ns |     7.17 ns |     6.70 ns |     390 B |    1712 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       222.6 ns |     0.69 ns |     0.61 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 128B         |       267.0 ns |     0.91 ns |     0.76 ns |   2,390 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,802.4 ns |     7.07 ns |     6.61 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     1,870.1 ns |     4.10 ns |     3.64 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       145.8 ns |     0.62 ns |     0.58 ns |     390 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 128B         |       273.9 ns |     0.33 ns |     0.30 ns |   2,268 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     1,703.0 ns |     6.25 ns |     5.22 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,768.5 ns |     1.42 ns |     1.19 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       256.0 ns |     0.52 ns |     0.41 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |       298.6 ns |     1.00 ns |     0.83 ns |   2,390 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |     2,140.1 ns |     4.33 ns |     3.84 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     2,147.0 ns |     2.96 ns |     2.31 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       200.6 ns |     0.12 ns |     0.11 ns |     390 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 152B         |       299.0 ns |     1.13 ns |     1.00 ns |   2,268 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |     1,949.3 ns |     6.77 ns |     5.66 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     2,115.4 ns |    10.97 ns |    10.26 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       299.0 ns |     0.37 ns |     0.29 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |       303.2 ns |     0.59 ns |     0.50 ns |   2,390 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |     2,782.7 ns |     7.62 ns |     6.75 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     3,255.8 ns |     2.38 ns |     1.86 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       198.6 ns |     0.17 ns |     0.15 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |       305.3 ns |     0.51 ns |     0.40 ns |   2,265 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |     2,595.9 ns |    14.23 ns |    13.31 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     3,187.9 ns |    16.52 ns |    15.45 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |       500.8 ns |     0.58 ns |     0.45 ns |   2,390 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       619.3 ns |     1.35 ns |     1.26 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     8,240.0 ns |    17.50 ns |    14.61 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |    11,770.5 ns |    30.47 ns |    27.01 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |       505.0 ns |     0.77 ns |     0.64 ns |   2,268 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       510.9 ns |     0.48 ns |     0.40 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     8,025.6 ns |    14.37 ns |    13.44 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |    11,745.0 ns |    50.40 ns |    47.15 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |     2,406.0 ns |     2.75 ns |     2.30 ns |   2,390 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     4,139.4 ns |     2.79 ns |     2.18 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    58,724.0 ns |   113.64 ns |    94.89 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |    90,892.3 ns |   401.47 ns |   375.54 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |     2,387.6 ns |     6.31 ns |     5.90 ns |   2,268 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,486.4 ns |     8.83 ns |     8.26 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    58,537.6 ns |   136.36 ns |   113.87 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |    90,875.9 ns |   372.68 ns |   348.61 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |    34,893.0 ns |   162.41 ns |   151.92 ns |   2,390 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    62,828.8 ns |   100.89 ns |    89.44 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        |   932,197.5 ns | 1,765.13 ns | 1,473.96 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 1,440,402.9 ns | 3,158.77 ns | 2,637.71 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |    34,315.5 ns |    58.49 ns |    45.67 ns |   2,268 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    54,378.6 ns |    42.54 ns |    37.71 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        |   930,737.5 ns |   942.03 ns |   835.08 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 1,444,611.0 ns | 2,989.59 ns | 2,650.19 ns |     390 B |         - |