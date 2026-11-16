| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       614.4 ns |     0.36 ns |     0.34 ns |   9,642 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,613.9 ns |     3.26 ns |     3.05 ns |  10,611 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     3,482.2 ns |     7.20 ns |     6.73 ns |     310 B |    2616 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       515.2 ns |     0.16 ns |     0.15 ns |   9,605 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,519.3 ns |     1.60 ns |     1.33 ns |  10,574 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     3,370.4 ns |     7.06 ns |     5.89 ns |     387 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     3,129.6 ns |     1.59 ns |     1.49 ns |   9,649 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     9,870.8 ns |     2.82 ns |     2.50 ns |  10,618 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |    18,632.0 ns |   103.03 ns |    91.33 ns |     310 B |    3512 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     3,055.8 ns |     0.30 ns |     0.26 ns |   9,597 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     9,797.6 ns |     4.38 ns |     4.10 ns |  10,574 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |    18,471.4 ns |    98.60 ns |    92.23 ns |     387 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    23,277.2 ns |     1.72 ns |     1.35 ns |   9,653 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    75,446.8 ns |    37.92 ns |    33.61 ns |  10,622 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |   140,321.3 ns |   194.15 ns |   172.11 ns |     310 B |   10680 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    23,011.5 ns |    12.84 ns |    12.01 ns |   9,610 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    75,196.8 ns |    46.37 ns |    43.37 ns |  10,582 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |   135,305.3 ns |   440.53 ns |   412.07 ns |     387 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   365,867.4 ns |   466.64 ns |   436.50 ns |   9,653 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 1,197,409.2 ns |   685.63 ns |   607.79 ns |  10,622 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 2,214,918.5 ns | 1,716.31 ns | 1,605.44 ns |     310 B |  133573 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   366,556.8 ns |   927.25 ns |   867.35 ns |   9,613 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 1,199,775.5 ns |   298.96 ns |   249.65 ns |  10,582 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 2,211,483.5 ns | 7,355.20 ns | 6,141.93 ns |     387 B |    2504 B |