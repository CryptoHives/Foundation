| Description                                       | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       156.2 ns |      3.14 ns |      3.97 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 17B          |       188.9 ns |      0.27 ns |      0.24 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |       533.6 ns |     10.63 ns |     13.82 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |       825.1 ns |      5.63 ns |      4.70 ns |     310 B |    1624 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       101.2 ns |      1.24 ns |      1.16 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 17B          |       202.3 ns |      2.04 ns |      1.81 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |       478.8 ns |      9.33 ns |      8.73 ns |     390 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |       758.4 ns |     15.06 ns |     15.47 ns |     390 B |    1608 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       159.2 ns |      0.58 ns |      0.52 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 65B          |       196.9 ns |      0.77 ns |      0.72 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |       927.3 ns |      2.90 ns |      2.71 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     1,131.1 ns |      6.31 ns |      5.90 ns |     310 B |    1624 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       107.1 ns |      0.23 ns |      0.19 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 65B          |       209.4 ns |      2.68 ns |      2.51 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |       889.2 ns |      4.39 ns |      3.89 ns |     390 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     1,007.7 ns |     19.89 ns |     30.97 ns |     390 B |    1608 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       167.4 ns |      0.70 ns |      0.55 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 128B         |       192.6 ns |      0.38 ns |      0.35 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     1,351.4 ns |      4.55 ns |      4.04 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     1,355.0 ns |      4.31 ns |      4.03 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       105.6 ns |      1.55 ns |      1.45 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 128B         |       202.5 ns |      1.87 ns |      1.75 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     1,241.2 ns |     20.48 ns |     18.16 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     1,377.9 ns |     26.14 ns |     24.45 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       187.0 ns |      0.33 ns |      0.29 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |       218.8 ns |      0.32 ns |      0.29 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |     1,542.3 ns |      5.29 ns |      4.69 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     1,609.3 ns |      3.13 ns |      2.61 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       144.3 ns |      1.26 ns |      1.18 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |       217.8 ns |      4.11 ns |      3.85 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     1,449.1 ns |     28.86 ns |     25.58 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     1,652.7 ns |     29.25 ns |     27.36 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       207.6 ns |      0.43 ns |      0.40 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |       216.8 ns |      0.44 ns |      0.39 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |     2,009.9 ns |      4.79 ns |      4.48 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     2,487.3 ns |      6.76 ns |      6.32 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       144.1 ns |      1.81 ns |      1.52 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |       223.3 ns |      4.46 ns |      4.18 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |     1,950.3 ns |     38.45 ns |     53.91 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     2,536.0 ns |     33.25 ns |     31.11 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |       356.5 ns |      0.71 ns |      0.66 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       424.5 ns |      0.61 ns |      0.57 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     5,992.5 ns |     18.80 ns |     17.58 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |     9,045.1 ns |     28.49 ns |     25.25 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       355.3 ns |      7.00 ns |      7.78 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |       363.6 ns |      2.72 ns |      2.41 ns |   2,216 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     6,002.5 ns |    112.48 ns |    115.50 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |     9,234.4 ns |    177.12 ns |    181.89 ns |     390 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |     1,648.9 ns |      3.03 ns |      2.83 ns |   2,253 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     2,502.0 ns |      6.70 ns |      5.23 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    42,933.0 ns |    136.02 ns |    127.24 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    69,798.4 ns |    183.64 ns |    171.78 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |     1,714.9 ns |     29.69 ns |     27.77 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     2,431.9 ns |     16.23 ns |     13.56 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    43,775.1 ns |    252.50 ns |    223.83 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    71,659.1 ns |  1,413.04 ns |  1,387.80 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |    23,500.9 ns |    105.75 ns |     98.91 ns |   2,330 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    37,287.9 ns |     83.76 ns |     78.35 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   675,811.7 ns |  1,737.43 ns |  1,625.19 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 1,110,615.0 ns |  4,469.44 ns |  3,962.05 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |    23,520.3 ns |    459.85 ns |    407.64 ns |   2,213 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    37,819.7 ns |    732.72 ns |    843.80 ns |     387 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   702,933.0 ns | 13,747.42 ns | 13,501.81 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 1,149,132.3 ns | 15,767.77 ns | 14,749.18 ns |     387 B |         - |