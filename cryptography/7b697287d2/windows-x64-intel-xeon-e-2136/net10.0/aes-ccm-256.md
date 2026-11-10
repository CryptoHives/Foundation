| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       712.2 ns |     0.28 ns |     0.26 ns |   9,642 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     2,085.2 ns |     4.05 ns |     3.38 ns |  10,611 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     4,361.0 ns |     6.81 ns |     6.37 ns |     310 B |    3016 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       613.4 ns |     0.27 ns |     0.26 ns |   9,605 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,991.8 ns |     4.93 ns |     4.61 ns |  10,574 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     4,245.6 ns |     5.25 ns |     4.66 ns |     390 B |    2904 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     3,820.3 ns |     1.43 ns |     1.27 ns |   9,649 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |    12,865.3 ns |    22.40 ns |    20.95 ns |  10,618 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    23,396.4 ns |    56.39 ns |    52.74 ns |     310 B |    3912 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     3,724.8 ns |     0.81 ns |     0.76 ns |   9,605 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |    12,742.8 ns |    11.18 ns |     9.91 ns |  10,578 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    23,163.1 ns |    27.51 ns |    24.39 ns |     387 B |    2904 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    28,303.9 ns |    10.73 ns |    10.04 ns |   9,647 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    98,179.5 ns |    69.94 ns |    58.41 ns |  10,622 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |   176,740.3 ns |   242.77 ns |   227.09 ns |     310 B |   11080 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    28,025.1 ns |     4.89 ns |     4.58 ns |   9,610 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    98,185.1 ns |   156.56 ns |   146.45 ns |  10,582 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |   172,076.4 ns |   287.08 ns |   268.54 ns |     387 B |    2904 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   448,369.7 ns |   378.27 ns |   335.33 ns |   9,653 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,561,893.8 ns | 2,164.18 ns | 2,024.37 ns |  10,616 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 2,859,236.1 ns | 2,616.34 ns | 2,447.33 ns |     310 B |  133973 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   445,314.3 ns |   227.32 ns |   201.52 ns |   9,613 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,567,924.1 ns | 2,032.51 ns | 1,901.21 ns |  10,582 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 2,718,070.2 ns | 5,234.61 ns | 4,896.45 ns |     387 B |    2904 B |