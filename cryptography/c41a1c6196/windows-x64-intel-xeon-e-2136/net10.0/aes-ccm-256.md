| Description                                | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       713.5 ns |      0.51 ns |      0.47 ns |   9,642 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     2,094.2 ns |     15.75 ns |     13.15 ns |  10,611 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     4,365.1 ns |     11.28 ns |     10.00 ns |     310 B |    3016 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       612.6 ns |      0.28 ns |      0.26 ns |   9,605 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,992.2 ns |     15.96 ns |     14.93 ns |  10,574 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     4,225.8 ns |      8.21 ns |      7.68 ns |     390 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     3,829.1 ns |      2.48 ns |      2.32 ns |   9,649 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |    12,863.2 ns |     25.76 ns |     21.51 ns |  10,618 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    23,316.5 ns |     46.50 ns |     41.22 ns |     310 B |    3912 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     3,727.8 ns |      1.62 ns |      1.51 ns |   9,612 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |    12,743.3 ns |     24.71 ns |     20.63 ns |  10,581 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    23,107.1 ns |     61.16 ns |     54.21 ns |     387 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    28,126.3 ns |     10.87 ns |     10.16 ns |   9,653 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    98,112.6 ns |    146.71 ns |    122.51 ns |  10,622 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |   176,836.5 ns |    292.51 ns |    259.30 ns |     310 B |   11080 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    28,018.9 ns |     14.50 ns |     13.56 ns |   9,613 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    98,131.9 ns |    139.74 ns |    123.87 ns |  10,571 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |   171,818.3 ns |    430.27 ns |    359.29 ns |     387 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   448,386.7 ns |    849.12 ns |    752.72 ns |   9,653 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,564,129.5 ns |  2,611.70 ns |  2,442.98 ns |  10,619 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 2,844,813.2 ns |  1,450.03 ns |  1,210.84 ns |     310 B |  133973 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   445,760.9 ns |    779.63 ns |    691.12 ns |   9,613 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,569,682.1 ns |  3,964.31 ns |  3,310.38 ns |  10,582 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 2,722,994.1 ns | 11,634.18 ns | 10,882.62 ns |     387 B |    2904 B |