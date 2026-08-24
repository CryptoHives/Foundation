| Description                                | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       456.2 ns |      1.23 ns |      1.03 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,839.5 ns |      9.45 ns |      8.38 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,944.7 ns |      6.75 ns |      5.64 ns |    3016 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       414.9 ns |      0.57 ns |      0.51 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,790.0 ns |     20.30 ns |     16.95 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,902.5 ns |     18.06 ns |     16.01 ns |    2904 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,801.5 ns |     17.16 ns |     14.33 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,333.4 ns |     43.05 ns |     38.16 ns |    3912 B |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |    12,020.0 ns |    239.58 ns |    212.38 ns |         - |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,718.5 ns |      2.87 ns |      2.40 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,379.4 ns |     56.56 ns |     50.14 ns |    2904 B |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |    12,361.0 ns |     50.36 ns |     42.05 ns |         - |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,063.0 ns |      9.55 ns |      7.45 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    77,380.9 ns |    417.59 ns |    348.71 ns |   11080 B |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    90,920.8 ns |    160.43 ns |    133.97 ns |         - |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,229.3 ns |     52.47 ns |     49.08 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    77,649.2 ns |    477.48 ns |    398.72 ns |    2904 B |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    92,605.3 ns |    817.21 ns |    724.44 ns |         - |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   335,497.0 ns |    407.04 ns |    360.83 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,253,377.0 ns |  5,441.06 ns |  4,823.35 ns |  133974 B |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,447,373.2 ns |  2,886.12 ns |  2,410.04 ns |         - |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   337,496.5 ns |  1,194.93 ns |  1,059.28 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,238,694.2 ns | 19,065.55 ns | 17,833.93 ns |    2904 B |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,550,324.3 ns | 12,567.01 ns | 11,755.19 ns |         - |