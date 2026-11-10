| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       610.2 ns |     0.48 ns |     0.42 ns |   9,642 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,617.0 ns |     1.81 ns |     1.69 ns |  10,611 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     3,506.9 ns |     6.38 ns |     5.97 ns |     310 B |    2616 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       520.4 ns |     0.30 ns |     0.26 ns |   9,605 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,524.3 ns |     1.74 ns |     1.54 ns |  10,574 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     3,374.2 ns |     2.90 ns |     2.57 ns |     387 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     3,130.7 ns |     1.31 ns |     1.22 ns |   9,649 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     9,880.7 ns |     8.17 ns |     7.24 ns |  10,611 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |    18,621.8 ns |    35.97 ns |    33.65 ns |     310 B |    3512 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     3,079.7 ns |     1.14 ns |     1.01 ns |   9,612 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     9,788.7 ns |     5.40 ns |     4.21 ns |  10,581 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |    18,617.4 ns |    52.40 ns |    46.45 ns |     387 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    23,132.2 ns |     9.13 ns |     8.54 ns |   9,653 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    76,209.1 ns |    62.12 ns |    58.11 ns |  10,616 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |   140,361.3 ns |   137.53 ns |   107.37 ns |     310 B |   10680 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    23,020.8 ns |     9.06 ns |     8.47 ns |   9,613 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    75,187.6 ns |    50.28 ns |    44.57 ns |  10,578 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |   139,864.9 ns |   498.16 ns |   465.98 ns |     387 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   368,164.8 ns |   169.24 ns |   158.30 ns |   9,653 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 1,195,606.6 ns |   319.26 ns |   249.26 ns |  10,619 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 2,275,747.4 ns | 2,725.95 ns | 2,276.29 ns |     310 B |  133573 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   365,570.9 ns |   286.22 ns |   253.72 ns |   9,613 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 1,204,575.2 ns |   601.65 ns |   562.79 ns |  10,582 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 2,213,426.4 ns | 7,833.71 ns | 6,541.50 ns |     387 B |    2504 B |