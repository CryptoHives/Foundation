| Description                                       | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       209.6 ns |      0.05 ns |      0.04 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 17B          |       266.6 ns |      0.28 ns |      0.26 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       772.7 ns |      7.75 ns |      6.87 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     1,287.1 ns |      4.29 ns |      3.80 ns |     310 B |    1832 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       142.4 ns |      0.11 ns |      0.10 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 17B          |       283.1 ns |      0.17 ns |      0.15 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       694.3 ns |      4.51 ns |      3.77 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     1,157.3 ns |      4.73 ns |      4.42 ns |     387 B |    1816 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       223.4 ns |      0.46 ns |      0.43 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 65B          |       275.6 ns |      0.14 ns |      0.12 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     1,398.2 ns |     12.50 ns |     11.69 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     1,788.8 ns |      3.49 ns |      3.27 ns |     310 B |    1832 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       155.3 ns |      0.73 ns |      0.64 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 65B          |       290.7 ns |      0.29 ns |      0.27 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     1,317.8 ns |     13.63 ns |     12.08 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     1,605.3 ns |      5.32 ns |      4.72 ns |     387 B |    1816 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       233.1 ns |      1.70 ns |      1.59 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 128B         |       270.8 ns |      0.28 ns |      0.24 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     2,043.2 ns |     14.38 ns |     11.23 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |     2,216.5 ns |      4.20 ns |      3.93 ns |     310 B |    1832 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       150.7 ns |      0.19 ns |      0.17 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 128B         |       297.9 ns |      0.05 ns |      0.04 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     2,033.4 ns |     26.39 ns |     24.69 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |     2,036.2 ns |      6.15 ns |      5.46 ns |     387 B |    1816 B |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       273.5 ns |      3.49 ns |      3.09 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 152B         |       303.7 ns |      0.31 ns |      0.29 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     2,451.9 ns |     37.62 ns |     33.35 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |     2,553.5 ns |      4.00 ns |      3.55 ns |     310 B |    1832 B |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       208.7 ns |      0.28 ns |      0.26 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 152B         |       315.6 ns |      0.33 ns |      0.31 ns |   2,216 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |     2,360.7 ns |      7.51 ns |      7.03 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     2,423.2 ns |     38.07 ns |     33.75 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       293.3 ns |      0.21 ns |      0.19 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |       312.8 ns |      0.43 ns |      0.40 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |     3,386.5 ns |      4.20 ns |      3.72 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     3,739.2 ns |     13.66 ns |     12.10 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       208.6 ns |      0.68 ns |      0.57 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 256B         |       321.5 ns |      0.28 ns |      0.25 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |     3,205.6 ns |      4.81 ns |      4.50 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     3,651.1 ns |      8.15 ns |      6.80 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |       532.5 ns |      1.02 ns |      0.91 ns |   2,253 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       609.9 ns |      0.60 ns |      0.56 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |    10,425.4 ns |      5.82 ns |      4.54 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |    13,681.9 ns |     58.98 ns |     49.25 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |       534.4 ns |      0.38 ns |      0.33 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       557.0 ns |      3.51 ns |      3.28 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |    10,232.8 ns |     11.77 ns |     10.43 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |    13,535.7 ns |     26.44 ns |     22.07 ns |     390 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |     2,674.5 ns |      3.77 ns |      3.34 ns |   2,414 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,608.8 ns |      1.09 ns |      0.97 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    76,043.1 ns |    108.73 ns |     96.39 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |   106,731.3 ns |  1,189.13 ns |  1,112.31 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |     2,715.2 ns |      7.15 ns |      6.69 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,846.8 ns |     33.07 ns |     30.94 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    75,575.2 ns |     22.73 ns |     17.75 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |   106,126.6 ns |    930.90 ns |    825.22 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |    38,945.3 ns |     89.16 ns |     79.04 ns |   2,330 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    54,070.0 ns |     29.71 ns |     24.81 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 1,197,459.3 ns |    447.18 ns |    396.42 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 1,693,729.7 ns | 14,682.72 ns | 13,734.22 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |    38,929.8 ns |    129.71 ns |    114.98 ns |   2,213 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    59,046.8 ns |    269.85 ns |    252.42 ns |     387 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 1,196,109.9 ns |    522.48 ns |    463.16 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 1,708,496.7 ns | 25,702.43 ns | 24,042.07 ns |     387 B |         - |