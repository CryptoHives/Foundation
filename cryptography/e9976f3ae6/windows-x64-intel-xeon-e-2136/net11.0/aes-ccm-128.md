| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       612.1 ns |     1.23 ns |     1.02 ns |  21,440 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,636.1 ns |     8.11 ns |     7.59 ns |  21,157 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     3,251.1 ns |     7.79 ns |     7.28 ns |     310 B |    2584 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       522.2 ns |     0.54 ns |     0.42 ns |  27,066 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,542.3 ns |     2.03 ns |     1.80 ns |  16,634 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     3,207.2 ns |    10.36 ns |     9.70 ns |     390 B |    2432 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     3,144.2 ns |     1.47 ns |     1.30 ns |  19,985 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     9,901.9 ns |     9.71 ns |     8.11 ns |  21,623 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |    17,093.2 ns |    70.95 ns |    66.37 ns |     310 B |    3480 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     3,079.6 ns |     0.76 ns |     0.59 ns |  15,470 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     9,907.0 ns |    41.14 ns |    36.47 ns |  23,141 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |    16,970.6 ns |    99.24 ns |    92.83 ns |     390 B |    2432 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    23,155.6 ns |    15.99 ns |    13.36 ns |  25,959 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    75,221.8 ns |   108.46 ns |    84.68 ns |  15,471 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |   123,786.2 ns |   259.50 ns |   216.69 ns |     310 B |   10648 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    23,204.2 ns |    13.58 ns |    11.34 ns |  21,843 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    75,529.6 ns |   125.49 ns |   104.79 ns |  16,952 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |   120,232.0 ns |   505.88 ns |   473.20 ns |     390 B |    2432 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   365,540.0 ns |   224.61 ns |   210.10 ns |  13,886 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 1,200,682.1 ns | 2,847.80 ns | 2,378.04 ns |  21,787 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 2,019,535.0 ns | 4,299.53 ns | 3,590.30 ns |     310 B |  133579 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   370,935.2 ns |   276.25 ns |   244.89 ns |  16,121 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 1,207,918.5 ns | 4,917.25 ns | 4,599.60 ns |  22,468 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,988,263.4 ns | 5,795.74 ns | 5,137.77 ns |     390 B |    2432 B |