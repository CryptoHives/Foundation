| Description                                       | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       205.3 ns |      0.10 ns |      0.09 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 17B          |       252.8 ns |      0.21 ns |      0.19 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |       703.0 ns |      1.55 ns |      1.37 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     1,101.4 ns |      4.14 ns |      3.87 ns |     310 B |    1624 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       131.7 ns |      0.07 ns |      0.06 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 17B          |       265.7 ns |      0.49 ns |      0.46 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |       623.8 ns |      8.15 ns |      7.22 ns |     390 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |       966.6 ns |      3.31 ns |      3.09 ns |     387 B |    1608 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       214.3 ns |      0.19 ns |      0.18 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 65B          |       263.8 ns |      0.39 ns |      0.37 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     1,276.0 ns |      8.06 ns |      7.54 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     1,484.2 ns |      3.04 ns |      2.70 ns |     310 B |    1624 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       140.4 ns |      0.18 ns |      0.15 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 65B          |       278.4 ns |      0.15 ns |      0.14 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     1,187.5 ns |     15.35 ns |     14.36 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     1,306.5 ns |      2.92 ns |      2.59 ns |     387 B |    1608 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       220.3 ns |      0.18 ns |      0.16 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 128B         |       260.4 ns |      0.22 ns |      0.21 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     1,816.6 ns |      3.80 ns |      3.37 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     1,827.1 ns |      9.48 ns |      7.92 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       136.7 ns |      0.18 ns |      0.17 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 128B         |       271.1 ns |      0.17 ns |      0.16 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     1,625.5 ns |      2.73 ns |      2.55 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     1,792.7 ns |      5.16 ns |      4.57 ns |     390 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       248.5 ns |      0.15 ns |      0.13 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |       292.0 ns |      0.17 ns |      0.15 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |     2,080.3 ns |      4.96 ns |      4.40 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     2,202.7 ns |     18.14 ns |     16.97 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       190.6 ns |      0.18 ns |      0.17 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |       292.4 ns |      0.41 ns |      0.36 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     1,891.1 ns |      5.51 ns |      5.15 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     2,155.0 ns |     14.93 ns |     13.24 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       282.6 ns |      0.15 ns |      0.14 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |       291.6 ns |      0.22 ns |      0.17 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |     2,715.6 ns |     13.36 ns |     11.84 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     3,359.0 ns |     23.71 ns |     22.18 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       184.0 ns |      0.20 ns |      0.16 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |       293.8 ns |      0.30 ns |      0.28 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |     2,530.8 ns |      5.52 ns |      5.16 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     3,278.5 ns |     25.18 ns |     22.33 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |       468.7 ns |      0.38 ns |      0.34 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       581.5 ns |      0.52 ns |      0.46 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     8,076.4 ns |     10.70 ns |      9.48 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |    12,253.4 ns |    115.13 ns |    102.06 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       468.9 ns |      1.02 ns |      0.96 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |       475.3 ns |      0.69 ns |      0.57 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     7,877.5 ns |     12.05 ns |     10.69 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |    12,075.6 ns |     48.46 ns |     37.83 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |     2,199.8 ns |      3.44 ns |      3.22 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,438.7 ns |      1.18 ns |      1.10 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    57,927.2 ns |     17.11 ns |     14.28 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    94,553.1 ns |    499.33 ns |    442.64 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |     2,219.7 ns |      3.02 ns |      2.83 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,148.5 ns |      5.75 ns |      5.38 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    57,773.8 ns |     57.77 ns |     51.21 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    94,273.6 ns |    375.96 ns |    351.67 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |    31,615.3 ns |     68.66 ns |     64.22 ns |   2,330 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    51,621.9 ns |     21.26 ns |     17.76 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   912,878.7 ns |    302.80 ns |    268.42 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 1,516,650.2 ns | 19,829.09 ns | 17,577.97 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |    31,844.6 ns |     68.12 ns |     56.89 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    48,778.5 ns |    110.63 ns |    103.49 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   912,733.0 ns |    490.33 ns |    434.67 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 1,506,499.4 ns |  7,476.57 ns |  5,837.21 ns |     387 B |         - |