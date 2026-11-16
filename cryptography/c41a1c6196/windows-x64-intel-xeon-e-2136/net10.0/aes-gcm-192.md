| Description                                       | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       208.4 ns |      0.04 ns |      0.03 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 17B          |       265.4 ns |      0.26 ns |      0.25 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       731.6 ns |      2.15 ns |      1.68 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     1,190.7 ns |      4.79 ns |      4.48 ns |     310 B |    1728 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       137.6 ns |      0.06 ns |      0.05 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 17B          |       277.9 ns |      0.37 ns |      0.35 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       657.3 ns |      2.49 ns |      2.08 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     1,052.4 ns |      4.46 ns |      3.72 ns |     390 B |    1712 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       217.1 ns |      0.92 ns |      0.86 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 65B          |       265.3 ns |      0.18 ns |      0.17 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     1,329.9 ns |     16.07 ns |     15.03 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     1,621.1 ns |      2.67 ns |      2.36 ns |     310 B |    1728 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       148.2 ns |      1.35 ns |      1.26 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 65B          |       296.2 ns |      0.07 ns |      0.07 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     1,253.1 ns |     15.66 ns |     14.65 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     1,445.9 ns |      2.48 ns |      2.32 ns |     387 B |    1712 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       227.7 ns |      0.26 ns |      0.25 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 128B         |       265.4 ns |      0.23 ns |      0.22 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,949.0 ns |     11.46 ns |      9.57 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     2,024.4 ns |      3.85 ns |      3.21 ns |     310 B |    1728 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       144.6 ns |      0.26 ns |      0.24 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 128B         |       271.1 ns |      0.17 ns |      0.16 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     1,814.6 ns |      2.99 ns |      2.65 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,909.0 ns |     23.78 ns |     22.24 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       257.7 ns |      0.77 ns |      0.64 ns |     310 B |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |       296.3 ns |      0.46 ns |      0.43 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     2,303.7 ns |      8.85 ns |      7.39 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |     2,328.4 ns |      4.91 ns |      4.35 ns |     310 B |    1728 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       199.3 ns |      0.12 ns |      0.10 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 152B         |       297.5 ns |      0.24 ns |      0.20 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |     2,122.9 ns |      5.04 ns |      4.71 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     2,287.5 ns |     18.33 ns |     17.15 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                        | 256B         |       296.9 ns |      0.17 ns |      0.15 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       297.5 ns |      0.08 ns |      0.06 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |     3,039.9 ns |      6.02 ns |      5.63 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     3,558.3 ns |     22.87 ns |     20.27 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       196.8 ns |      0.13 ns |      0.11 ns |     387 B |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |       301.0 ns |      0.28 ns |      0.26 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |     2,862.9 ns |      5.05 ns |      4.48 ns |     390 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     3,474.7 ns |     26.23 ns |     24.54 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |       491.7 ns |      0.87 ns |      0.82 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       589.6 ns |      0.58 ns |      0.49 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     9,247.6 ns |      9.04 ns |      7.55 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |    12,939.4 ns |     34.07 ns |     28.45 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |       497.0 ns |      0.41 ns |      0.32 ns |   2,216 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       507.7 ns |      0.86 ns |      0.80 ns |     390 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     9,071.7 ns |     15.40 ns |     14.40 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |    12,841.7 ns |     77.87 ns |     72.84 ns |     390 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |     2,399.3 ns |      7.27 ns |      6.80 ns |   2,253 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,494.4 ns |      2.01 ns |      1.88 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    66,931.4 ns |     32.79 ns |     29.07 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |   100,427.1 ns |    304.99 ns |    285.29 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |     2,411.7 ns |      3.16 ns |      2.80 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,478.6 ns |      7.25 ns |      6.78 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    66,676.8 ns |     34.01 ns |     30.15 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |   100,384.2 ns |    730.72 ns |    647.77 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |    34,801.6 ns |    157.08 ns |    146.93 ns |   2,330 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    52,186.1 ns |     30.35 ns |     25.35 ns |     310 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 1,054,440.5 ns |    526.69 ns |    492.67 ns |     310 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 1,615,934.5 ns | 25,888.91 ns | 24,216.50 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |    34,379.4 ns |     90.55 ns |     70.70 ns |   2,213 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    54,211.4 ns |    106.27 ns |     99.41 ns |     387 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 1,054,384.6 ns |    588.31 ns |    550.31 ns |     387 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 1,600,941.1 ns | 12,698.12 ns | 11,256.56 ns |     387 B |         - |