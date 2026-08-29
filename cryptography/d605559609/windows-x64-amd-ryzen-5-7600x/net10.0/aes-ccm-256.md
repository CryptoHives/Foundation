| Description                                | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       455.2 ns |     7.06 ns |     8.40 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,202.8 ns |     8.52 ns |     7.56 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,924.6 ns |     7.84 ns |     6.12 ns |    3016 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       415.1 ns |     2.55 ns |     1.99 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,163.5 ns |     7.19 ns |     6.73 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,873.8 ns |    11.48 ns |    10.18 ns |    2904 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,746.0 ns |    12.43 ns |     9.71 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,146.0 ns |    52.69 ns |    49.29 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,326.9 ns |    57.40 ns |    47.93 ns |    3912 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,740.5 ns |    53.21 ns |    54.64 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     7,560.0 ns |    36.36 ns |    32.24 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,247.9 ns |    58.38 ns |    54.61 ns |    2904 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,053.1 ns |    36.80 ns |    30.73 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    59,125.8 ns |   406.40 ns |   380.15 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    77,418.7 ns |   324.03 ns |   287.24 ns |   11080 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,077.4 ns |   102.81 ns |    80.27 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    63,123.6 ns |   303.49 ns |   269.03 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    76,972.4 ns |   531.28 ns |   470.97 ns |    2904 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   327,682.5 ns |   715.56 ns |   669.33 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   938,588.8 ns | 5,474.99 ns | 4,853.44 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,255,108.6 ns | 5,799.80 ns | 5,425.14 ns |  133974 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   335,341.5 ns |   789.00 ns |   699.43 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   935,942.2 ns | 4,043.92 ns | 3,376.86 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,217,795.2 ns | 5,078.53 ns | 4,240.80 ns |    2904 B |