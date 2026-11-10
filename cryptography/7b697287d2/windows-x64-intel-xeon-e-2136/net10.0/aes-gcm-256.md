| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       211.6 ns |     0.25 ns |     0.24 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 17B          |       271.7 ns |     0.24 ns |     0.21 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       778.4 ns |     3.44 ns |     3.22 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     1,312.2 ns |     3.85 ns |     3.60 ns |     310 B |    1832 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       142.9 ns |     0.09 ns |     0.08 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 17B          |       282.2 ns |     0.52 ns |     0.49 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       695.8 ns |     1.53 ns |     1.19 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     1,162.4 ns |     2.39 ns |     2.24 ns |     387 B |    1816 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       225.6 ns |     0.23 ns |     0.19 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 65B          |       274.7 ns |     0.44 ns |     0.41 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     1,395.1 ns |     4.19 ns |     3.92 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     1,798.2 ns |     4.67 ns |     4.37 ns |     310 B |    1832 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       155.4 ns |     0.21 ns |     0.19 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 65B          |       290.9 ns |     0.33 ns |     0.30 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     1,319.9 ns |    11.37 ns |    10.64 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     1,606.1 ns |     1.55 ns |     1.38 ns |     387 B |    1816 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       232.2 ns |     0.26 ns |     0.22 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 128B         |       275.2 ns |     0.58 ns |     0.54 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     2,038.8 ns |     4.51 ns |     3.77 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |     2,247.5 ns |     4.31 ns |     4.03 ns |     310 B |    1832 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       155.5 ns |     0.12 ns |     0.11 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 128B         |       278.9 ns |     0.26 ns |     0.23 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     2,011.8 ns |     6.11 ns |     5.11 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |     2,046.2 ns |     4.16 ns |     3.89 ns |     387 B |    1816 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       267.8 ns |     0.77 ns |     0.64 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 152B         |       305.7 ns |     0.23 ns |     0.20 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     2,436.2 ns |    11.10 ns |    10.38 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |     2,585.3 ns |     6.04 ns |     5.36 ns |     310 B |    1832 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       208.7 ns |     0.22 ns |     0.20 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 152B         |       309.2 ns |     0.40 ns |     0.38 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |     2,374.0 ns |     4.50 ns |     4.21 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     2,413.8 ns |    10.24 ns |     9.58 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       293.8 ns |     0.23 ns |     0.18 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |       309.7 ns |     0.29 ns |     0.26 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |     3,418.2 ns |     5.53 ns |     5.17 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     3,742.5 ns |    14.06 ns |    13.15 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       213.1 ns |     0.32 ns |     0.30 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 256B         |       314.9 ns |     0.34 ns |     0.28 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |     3,234.8 ns |     4.53 ns |     4.24 ns |     390 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     3,658.1 ns |     8.47 ns |     7.92 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |       532.9 ns |     0.63 ns |     0.56 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       617.1 ns |     0.58 ns |     0.51 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |    10,488.6 ns |    18.81 ns |    17.59 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |    13,710.4 ns |    59.45 ns |    55.61 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |       536.1 ns |     1.02 ns |     0.95 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       551.7 ns |     0.66 ns |     0.59 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |    10,300.8 ns |    24.57 ns |    22.99 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |    13,565.7 ns |    65.82 ns |    58.35 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |     2,668.8 ns |     2.93 ns |     2.60 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,685.4 ns |     3.45 ns |     2.88 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    76,245.6 ns |    97.22 ns |    86.19 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |   106,112.6 ns |   203.01 ns |   179.96 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |     2,670.2 ns |     3.48 ns |     3.08 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,789.7 ns |     4.75 ns |     4.44 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    75,760.3 ns |    48.66 ns |    40.63 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |   105,967.6 ns |   222.16 ns |   196.94 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |    38,925.7 ns |    78.61 ns |    73.53 ns |   2,330 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    55,471.9 ns |    53.55 ns |    47.47 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 1,200,187.2 ns | 1,097.27 ns |   972.70 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 1,688,341.1 ns | 2,459.11 ns | 2,179.93 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |    38,976.2 ns |    40.00 ns |    35.46 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    58,883.7 ns |    77.72 ns |    60.68 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 1,200,086.4 ns | 1,402.43 ns | 1,311.84 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 1,688,089.1 ns | 3,334.02 ns | 3,118.64 ns |     387 B |         - |