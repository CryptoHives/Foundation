| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       208.7 ns |     0.72 ns |     0.68 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 17B          |       268.0 ns |     0.54 ns |     0.42 ns |   2,390 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       757.8 ns |     2.53 ns |     2.37 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     1,240.9 ns |     3.42 ns |     3.03 ns |     310 B |    1832 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       144.2 ns |     0.09 ns |     0.08 ns |     390 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 17B          |       283.1 ns |     1.57 ns |     1.47 ns |   2,268 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       675.7 ns |     3.08 ns |     2.88 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     1,111.8 ns |     2.93 ns |     2.59 ns |     390 B |    1816 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       219.5 ns |     0.24 ns |     0.20 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 65B          |       279.4 ns |     0.35 ns |     0.29 ns |   2,390 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     1,322.6 ns |     2.93 ns |     2.60 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     1,665.9 ns |     5.05 ns |     4.48 ns |     310 B |    1832 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       162.6 ns |     1.87 ns |     1.66 ns |     390 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 65B          |       291.8 ns |     0.44 ns |     0.37 ns |   2,268 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     1,243.7 ns |     4.64 ns |     4.34 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     1,488.2 ns |     4.40 ns |     3.67 ns |     390 B |    1816 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       231.2 ns |     0.29 ns |     0.24 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 128B         |       273.7 ns |     0.61 ns |     0.51 ns |   2,390 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     1,910.5 ns |     9.79 ns |     8.68 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |     2,041.2 ns |     5.39 ns |     4.78 ns |     310 B |    1832 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       152.1 ns |     0.26 ns |     0.21 ns |     390 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 128B         |       282.6 ns |     0.35 ns |     0.31 ns |   2,268 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |     1,855.1 ns |     6.33 ns |     5.61 ns |     390 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     1,883.0 ns |     2.04 ns |     1.81 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       265.0 ns |     0.92 ns |     0.86 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 152B         |       306.7 ns |     0.56 ns |     0.50 ns |   2,390 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     2,274.2 ns |     4.61 ns |     4.31 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |     2,342.8 ns |    13.51 ns |    11.97 ns |     310 B |    1832 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       209.7 ns |     1.34 ns |     1.18 ns |     390 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 152B         |       312.2 ns |     1.61 ns |     1.51 ns |   2,268 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |     2,152.6 ns |     9.50 ns |     8.89 ns |     390 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     2,243.0 ns |     9.97 ns |     8.84 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       296.2 ns |     0.38 ns |     0.30 ns |     310 B |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |       309.6 ns |     0.40 ns |     0.36 ns |   2,390 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |     3,032.9 ns |     4.31 ns |     3.37 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     3,477.1 ns |    15.39 ns |    14.39 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       209.7 ns |     0.51 ns |     0.45 ns |     387 B |         - |
| Encrypt · AES-256-GCM (OS)                        | 256B         |       317.7 ns |     2.06 ns |     1.92 ns |   2,265 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |     2,882.3 ns |    20.61 ns |    18.27 ns |     387 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     3,371.6 ns |     6.12 ns |     4.78 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |       526.2 ns |     0.71 ns |     0.59 ns |   2,390 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       703.7 ns |     3.88 ns |     3.63 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |     9,046.7 ns |     9.92 ns |     8.80 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |    12,487.2 ns |    31.83 ns |    28.22 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |       537.8 ns |     0.40 ns |     0.31 ns |   2,268 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       563.0 ns |     0.79 ns |     0.74 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |     8,844.4 ns |     9.65 ns |     7.53 ns |     390 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |    12,413.7 ns |    15.22 ns |    13.49 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |     2,685.8 ns |    16.03 ns |    14.99 ns |   2,390 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     4,344.5 ns |     7.66 ns |     6.40 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    66,694.8 ns |   328.36 ns |   307.15 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |    96,913.1 ns |   409.50 ns |   383.05 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |     2,689.9 ns |     3.25 ns |     2.88 ns |   2,268 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,790.9 ns |     6.22 ns |     5.52 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    66,392.8 ns |   122.84 ns |   108.90 ns |     390 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |    96,119.5 ns |   121.14 ns |   107.38 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |    39,043.4 ns |   123.73 ns |   103.32 ns |   2,390 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    58,932.2 ns |   175.33 ns |   164.01 ns |     310 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 1,022,096.5 ns |   443.80 ns |   346.49 ns |     310 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 1,532,498.3 ns | 3,930.17 ns | 3,281.87 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |    39,752.3 ns |   150.12 ns |   140.42 ns |   2,268 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    58,945.1 ns |   145.02 ns |   135.65 ns |     390 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 1,051,151.8 ns | 1,765.05 ns | 1,473.90 ns |     390 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 1,538,367.1 ns | 6,570.90 ns | 5,824.94 ns |     390 B |         - |