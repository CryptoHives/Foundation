| Description                                | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       534.4 ns |      1.03 ns |      0.91 ns |   9,642 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,574.7 ns |      3.15 ns |      2.46 ns |  10,611 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     3,390.8 ns |     59.32 ns |     55.49 ns |     310 B |    3016 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       483.0 ns |      0.74 ns |      0.66 ns |   9,605 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,576.9 ns |      2.67 ns |      2.49 ns |  10,574 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     3,456.0 ns |     38.44 ns |     35.96 ns |     390 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,980.7 ns |     52.57 ns |     49.17 ns |   9,649 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     9,862.6 ns |    107.86 ns |     95.61 ns |  10,618 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    17,862.5 ns |    354.51 ns |    348.18 ns |     310 B |    3912 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,933.1 ns |      4.12 ns |      3.86 ns |   9,612 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     9,965.6 ns |     45.88 ns |     38.31 ns |  10,581 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    18,262.8 ns |    149.54 ns |    132.56 ns |     387 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,255.3 ns |    181.32 ns |    160.74 ns |   9,653 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    75,219.3 ns |  1,348.81 ns |  1,261.68 ns |  10,622 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |   133,942.8 ns |  1,865.60 ns |  1,745.09 ns |     310 B |   11080 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,875.3 ns |    122.09 ns |    114.20 ns |   9,616 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    77,086.9 ns |    848.39 ns |    793.58 ns |  10,582 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |   133,184.6 ns |    665.37 ns |    622.38 ns |     387 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   338,401.7 ns |    575.20 ns |    538.04 ns |   9,650 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,187,842.0 ns | 19,204.32 ns | 17,963.74 ns |  10,622 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 2,118,432.9 ns | 30,639.93 ns | 28,660.61 ns |     310 B |  133973 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   339,669.9 ns |  4,045.48 ns |  3,784.14 ns |   9,613 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,183,595.6 ns |  2,841.06 ns |  2,657.53 ns |  10,582 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 2,088,656.1 ns | 40,625.34 ns | 46,784.20 ns |     387 B |    2904 B |