| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       452.1 ns |     1.68 ns |     1.57 ns |   9,642 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,194.3 ns |     1.48 ns |     1.32 ns |  10,611 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     2,597.9 ns |     8.69 ns |     8.13 ns |     310 B |    2616 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       392.1 ns |     6.06 ns |     5.67 ns |   9,602 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,143.0 ns |     4.51 ns |     4.00 ns |  10,574 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     2,547.9 ns |     8.84 ns |     7.84 ns |     390 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,326.0 ns |     3.47 ns |     3.25 ns |   9,649 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     7,545.8 ns |   142.23 ns |   152.19 ns |  10,618 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |    13,928.6 ns |    61.07 ns |    54.13 ns |     310 B |    3512 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,303.2 ns |    16.98 ns |    14.18 ns |   9,612 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     7,267.3 ns |    15.85 ns |    13.23 ns |  10,581 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |    13,724.6 ns |    23.11 ns |    20.49 ns |     387 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,284.7 ns |    55.46 ns |    51.88 ns |   9,653 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    57,677.4 ns |   595.02 ns |   556.58 ns |  10,622 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |   102,931.2 ns |   333.75 ns |   278.70 ns |     310 B |   10680 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,183.0 ns |    25.78 ns |    24.11 ns |   9,607 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    55,695.3 ns |   103.36 ns |    91.62 ns |  10,582 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |   100,032.6 ns |   316.34 ns |   295.91 ns |     387 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   275,691.5 ns |   429.13 ns |   358.34 ns |   9,653 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   941,092.6 ns | 5,702.03 ns | 5,333.68 ns |  10,622 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,814,596.7 ns | 8,590.93 ns | 8,035.96 ns |     310 B |  133574 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   272,354.0 ns |   803.06 ns |   751.18 ns |   9,613 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   889,542.6 ns | 1,904.31 ns | 1,781.29 ns |  10,579 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,582,259.2 ns | 2,057.45 ns | 1,924.54 ns |     387 B |    2504 B |