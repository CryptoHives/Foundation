| Description                                | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       516.8 ns |      0.96 ns |      0.90 ns |  95,777 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,326.1 ns |     20.01 ns |     18.71 ns |  21,890 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,055.4 ns |     40.86 ns |     40.13 ns |     306 B |    2984 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       447.0 ns |      1.04 ns |      0.97 ns |  22,164 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,252.3 ns |     16.03 ns |     15.00 ns |  22,739 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,012.5 ns |     22.81 ns |     21.34 ns |     386 B |    2832 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,790.1 ns |      1.57 ns |      1.46 ns |  19,888 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,101.1 ns |     84.29 ns |     78.84 ns |  26,219 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,958.8 ns |    135.09 ns |    119.75 ns |     306 B |    3880 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,733.0 ns |      1.38 ns |      1.23 ns |  21,660 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,065.6 ns |    104.28 ns |     92.44 ns |  22,710 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,943.2 ns |    122.05 ns |    114.17 ns |     386 B |    2832 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,141.8 ns |     11.22 ns |     10.49 ns |  19,892 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    62,357.5 ns |    462.81 ns |    432.91 ns |  23,637 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    81,901.5 ns |    768.16 ns |    680.96 ns |     306 B |   11048 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,119.9 ns |      9.84 ns |      9.21 ns |  23,841 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    62,456.6 ns |    777.11 ns |    726.91 ns |  23,569 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    82,210.1 ns |    983.33 ns |    919.81 ns |     386 B |    2832 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   350,642.3 ns |    734.38 ns |    686.94 ns |  13,767 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   993,114.6 ns | 14,067.81 ns | 13,159.04 ns |  17,240 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,344,207.3 ns | 14,069.52 ns | 12,472.27 ns |     306 B |  133981 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   514,128.8 ns |    364.83 ns |    341.27 ns |  26,682 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   992,603.0 ns | 12,048.66 ns | 10,680.83 ns |  22,742 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,297,486.0 ns | 17,535.21 ns | 16,402.45 ns |     386 B |    2832 B |