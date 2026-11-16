| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       412.7 ns |     0.36 ns |     0.32 ns |   9,490 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,009.9 ns |     3.58 ns |     3.17 ns |  10,459 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,741.4 ns |     9.07 ns |     8.49 ns |     306 B |    2616 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       358.8 ns |     0.27 ns |     0.23 ns |   9,435 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |       956.8 ns |     6.47 ns |     5.74 ns |  10,407 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,700.2 ns |     3.48 ns |     3.09 ns |     383 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,315.6 ns |     1.79 ns |     1.68 ns |   9,489 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     6,170.3 ns |    35.60 ns |    29.73 ns |  10,451 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     9,253.1 ns |    27.65 ns |    24.51 ns |     306 B |    3512 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,269.3 ns |     1.37 ns |     1.28 ns |   9,445 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     6,088.0 ns |    26.52 ns |    23.51 ns |  10,399 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     9,161.3 ns |    31.14 ns |    26.01 ns |     383 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,494.4 ns |    11.60 ns |    10.85 ns |   9,504 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    47,152.4 ns |   125.88 ns |   111.59 ns |  10,473 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    69,923.8 ns |   913.36 ns |   809.67 ns |     306 B |   10680 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,451.6 ns |     6.12 ns |     5.72 ns |   9,449 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    47,151.7 ns |   193.11 ns |   171.19 ns |  10,418 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    68,754.9 ns |   164.04 ns |   136.98 ns |     383 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   277,692.5 ns |   232.82 ns |   217.78 ns |   9,504 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   750,063.6 ns | 2,895.71 ns | 2,418.05 ns |  10,473 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,135,234.0 ns | 4,685.30 ns | 4,382.64 ns |     306 B |  133574 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   277,657.7 ns |   249.49 ns |   221.16 ns |   9,449 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   749,882.7 ns | 2,097.73 ns | 1,962.22 ns |  10,418 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,092,309.1 ns | 5,020.91 ns | 4,450.90 ns |     383 B |    2504 B |