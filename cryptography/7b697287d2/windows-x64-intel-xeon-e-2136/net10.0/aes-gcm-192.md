| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       209.1 ns |     0.10 ns |     0.09 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 17B          |       260.1 ns |     0.30 ns |     0.25 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       742.0 ns |     4.25 ns |     3.55 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     1,205.4 ns |     1.93 ns |     1.61 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       137.9 ns |     0.09 ns |     0.08 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 17B          |       270.5 ns |     0.34 ns |     0.32 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       658.7 ns |     2.14 ns |     2.00 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     1,061.6 ns |     2.19 ns |     1.94 ns |     387 B |    1712 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       216.3 ns |     0.61 ns |     0.57 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 65B          |       270.4 ns |     0.49 ns |     0.46 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     1,328.3 ns |     4.10 ns |     3.83 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     1,632.7 ns |     2.09 ns |     1.85 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       149.1 ns |     0.24 ns |     0.21 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 65B          |       287.4 ns |     0.22 ns |     0.19 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     1,240.4 ns |     2.54 ns |     1.98 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     1,456.5 ns |     2.51 ns |     2.34 ns |     387 B |    1712 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       228.4 ns |     0.33 ns |     0.27 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 128B         |       269.0 ns |     0.40 ns |     0.34 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,938.5 ns |     5.03 ns |     4.71 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     2,027.3 ns |     4.90 ns |     4.58 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       144.3 ns |     0.09 ns |     0.08 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 128B         |       274.1 ns |     0.25 ns |     0.22 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     1,830.6 ns |     7.96 ns |     7.06 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,905.4 ns |     3.98 ns |     3.33 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       258.7 ns |     0.48 ns |     0.45 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |       294.0 ns |     0.23 ns |     0.18 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     2,311.2 ns |     6.29 ns |     5.88 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |     2,318.4 ns |     2.78 ns |     2.46 ns |     310 B |    1728 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       197.6 ns |     0.12 ns |     0.11 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 152B         |       297.0 ns |     0.22 ns |     0.20 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |     2,117.9 ns |     5.19 ns |     4.86 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     2,284.3 ns |    10.70 ns |    10.01 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       287.4 ns |     0.37 ns |     0.33 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |       297.7 ns |     0.72 ns |     0.67 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |     3,060.8 ns |     5.56 ns |     4.34 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     3,556.8 ns |    17.61 ns |    16.47 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       198.7 ns |     0.29 ns |     0.25 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |       302.2 ns |     0.21 ns |     0.19 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |     2,887.3 ns |     5.32 ns |     4.98 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     3,465.6 ns |    13.73 ns |    12.17 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |       497.3 ns |     1.28 ns |     1.14 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       600.5 ns |     0.78 ns |     0.69 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     9,302.7 ns |    15.80 ns |    14.78 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |    12,965.9 ns |    37.23 ns |    33.00 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |       504.9 ns |     0.72 ns |     0.67 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       509.3 ns |     0.79 ns |     0.70 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     9,059.5 ns |     6.99 ns |     6.20 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |    12,791.5 ns |    37.29 ns |    33.06 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |     2,402.5 ns |     5.09 ns |     4.76 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,571.7 ns |     2.86 ns |     2.54 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    67,158.0 ns |    94.45 ns |    83.73 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |   100,382.4 ns |   279.08 ns |   261.06 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |     2,381.6 ns |     2.24 ns |     1.99 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,489.2 ns |     5.41 ns |     5.06 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    66,748.2 ns |    51.80 ns |    45.92 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |    99,986.2 ns |   314.45 ns |   278.75 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |    35,079.0 ns |    70.41 ns |    65.86 ns |   2,330 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    53,589.3 ns |    38.53 ns |    36.04 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 1,058,554.2 ns | 1,659.91 ns | 1,552.68 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 1,598,467.8 ns | 4,965.11 ns | 4,644.37 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |    34,380.3 ns |    94.34 ns |    83.63 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    53,799.5 ns |   111.22 ns |   104.04 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 1,054,411.5 ns |   428.27 ns |   379.65 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 1,596,225.6 ns | 6,288.50 ns | 5,882.27 ns |     387 B |         - |