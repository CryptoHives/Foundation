| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       715.4 ns |     0.65 ns |     0.57 ns |  25,232 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     2,089.9 ns |    10.60 ns |     8.85 ns |  20,972 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     3,990.2 ns |    14.84 ns |    13.15 ns |     310 B |    2984 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       620.1 ns |     0.79 ns |     0.70 ns |  22,345 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,999.4 ns |     3.31 ns |     2.94 ns |  22,720 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     3,937.2 ns |     9.93 ns |     8.29 ns |     390 B |    2832 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     3,826.2 ns |     1.40 ns |     1.31 ns |  19,985 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |    12,830.8 ns |    11.73 ns |     9.16 ns |  21,181 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    20,721.0 ns |    23.84 ns |    18.62 ns |     310 B |    3880 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     3,727.7 ns |     3.30 ns |     3.09 ns |  21,921 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |    12,809.0 ns |    23.12 ns |    20.50 ns |  22,738 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    20,024.8 ns |    91.97 ns |    81.53 ns |     390 B |    2832 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    28,165.7 ns |    28.51 ns |    26.67 ns |  21,530 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    98,360.2 ns |   196.43 ns |   164.03 ns |  41,274 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |   147,367.0 ns |   560.04 ns |   523.86 ns |     310 B |   11048 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    28,369.8 ns |    12.67 ns |    11.23 ns |  21,729 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    98,519.6 ns |   261.39 ns |   231.72 ns |  29,229 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |   148,415.6 ns | 1,100.68 ns | 1,029.58 ns |     390 B |    2832 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   445,405.2 ns |   211.52 ns |   165.14 ns |  13,895 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,568,395.9 ns | 3,586.14 ns | 3,179.02 ns |  14,855 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 2,518,570.5 ns | 2,182.40 ns | 1,934.64 ns |     310 B |  133979 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   450,686.5 ns |   121.50 ns |   101.46 ns |  31,281 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,575,842.1 ns | 7,266.01 ns | 6,796.63 ns |  22,834 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 2,399,638.3 ns | 2,726.19 ns | 2,276.49 ns |     390 B |    2832 B |