| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     408.1 ns |     1.98 ns |     1.85 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,008.7 ns |     5.33 ns |     4.99 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,528.3 ns |    11.57 ns |    10.26 ns |    2616 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     347.4 ns |     0.72 ns |     0.67 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,017.1 ns |     8.06 ns |     7.54 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,467.7 ns |    12.03 ns |    10.67 ns |    2504 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,283.5 ns |     6.62 ns |     5.87 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,363.1 ns |    52.74 ns |    49.33 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,094.7 ns |    74.19 ns |    69.39 ns |    3512 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,232.8 ns |     7.39 ns |     6.55 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,328.9 ns |    34.04 ns |    31.84 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,005.9 ns |    66.48 ns |    62.18 ns |    2504 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,335.4 ns |    38.97 ns |    34.55 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  49,277.0 ns |   394.77 ns |   369.27 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  60,881.9 ns |   616.97 ns |   577.12 ns |   10680 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,292.2 ns |    40.54 ns |    37.92 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  49,047.3 ns |   243.27 ns |   227.56 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  59,844.0 ns |   302.55 ns |   283.00 ns |    2504 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 275,225.4 ns |   707.21 ns |   626.93 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 784,838.6 ns | 5,280.59 ns | 4,681.11 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 986,548.0 ns | 7,476.01 ns | 6,627.29 ns |  133574 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 275,137.6 ns |   849.80 ns |   753.33 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 783,191.4 ns | 3,297.23 ns | 2,753.34 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 951,167.7 ns | 3,836.43 ns | 3,588.60 ns |    2504 B |