| Description                                       | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       155.8 ns |      0.73 ns |      0.64 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 17B          |       195.1 ns |      0.51 ns |      0.45 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       572.2 ns |      1.30 ns |      1.22 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |       965.5 ns |      4.86 ns |      4.55 ns |     310 B |    1832 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       105.1 ns |      0.15 ns |      0.14 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 17B          |       211.2 ns |      0.86 ns |      0.72 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       511.8 ns |      1.62 ns |      1.43 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |       863.6 ns |      1.91 ns |      1.70 ns |     387 B |    1816 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       164.8 ns |      0.33 ns |      0.29 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 65B          |       202.2 ns |      0.55 ns |      0.49 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     1,024.5 ns |      2.70 ns |      2.52 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     1,326.5 ns |      2.97 ns |      2.78 ns |     310 B |    1832 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       114.7 ns |      0.18 ns |      0.15 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 65B          |       217.2 ns |      0.40 ns |      0.33 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |       968.6 ns |      3.16 ns |      2.80 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     1,186.6 ns |      3.57 ns |      3.34 ns |     387 B |    1816 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       173.6 ns |      0.29 ns |      0.25 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 128B         |       202.5 ns |      2.22 ns |      2.08 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     1,502.4 ns |      3.70 ns |      3.46 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |     1,667.9 ns |     16.10 ns |     12.57 ns |     310 B |    1832 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       112.1 ns |      0.18 ns |      0.16 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 128B         |       206.0 ns |      0.40 ns |      0.38 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     1,493.4 ns |      6.17 ns |      5.15 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |     1,516.5 ns |      2.40 ns |      2.25 ns |     387 B |    1816 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       197.9 ns |      0.43 ns |      0.40 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 152B         |       234.0 ns |      0.83 ns |      0.78 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     1,789.8 ns |      3.79 ns |      3.54 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |     1,893.0 ns |      6.86 ns |      6.08 ns |     310 B |    1832 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       153.8 ns |      0.34 ns |      0.28 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 152B         |       230.8 ns |      0.30 ns |      0.27 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |     1,750.8 ns |      3.49 ns |      3.27 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     1,782.3 ns |      2.78 ns |      2.60 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       216.5 ns |      0.46 ns |      0.43 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |       228.8 ns |      0.71 ns |      0.67 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |     2,521.9 ns |      7.93 ns |      7.03 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     2,764.4 ns |      6.27 ns |      5.56 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       157.3 ns |      0.29 ns |      0.26 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 256B         |       235.0 ns |      0.77 ns |      0.68 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |     2,402.7 ns |     13.51 ns |     11.97 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     2,708.7 ns |      4.87 ns |      4.07 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |       391.3 ns |      1.65 ns |      1.54 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       456.6 ns |      0.75 ns |      0.66 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |     7,770.9 ns |     48.30 ns |     37.71 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |    10,087.3 ns |     25.37 ns |     23.73 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |       401.8 ns |      0.91 ns |      0.81 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       407.2 ns |      0.86 ns |      0.72 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |     7,592.9 ns |     17.20 ns |     14.36 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |     9,978.2 ns |     13.74 ns |     12.85 ns |     390 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |     1,991.8 ns |      4.69 ns |      4.16 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     2,736.8 ns |      5.34 ns |      4.99 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    56,268.2 ns |    160.15 ns |    149.80 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |    78,313.2 ns |    225.53 ns |    210.96 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |     1,982.8 ns |      5.29 ns |      4.13 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     2,825.4 ns |      6.27 ns |      5.56 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    56,273.3 ns |    184.83 ns |    144.30 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |    80,761.0 ns |    363.09 ns |    321.87 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |    28,808.7 ns |     53.41 ns |     44.60 ns |   2,330 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    41,013.3 ns |     77.27 ns |     68.50 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        |   889,724.1 ns |  4,419.96 ns |  3,918.18 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 1,244,531.2 ns |  3,144.62 ns |  2,787.62 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |    28,724.6 ns |     77.88 ns |     65.04 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    43,503.9 ns |    115.75 ns |    102.61 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        |   886,479.7 ns |  2,399.22 ns |  2,126.85 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 1,252,007.3 ns | 14,354.50 ns | 13,427.21 ns |     387 B |         - |