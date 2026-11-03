| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       417.8 ns |     0.53 ns |     0.49 ns |   9,490 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,003.1 ns |     3.86 ns |     3.61 ns |  10,459 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,719.7 ns |     3.23 ns |     2.70 ns |     306 B |    2616 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       355.5 ns |     0.27 ns |     0.24 ns |   9,438 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |       949.4 ns |     1.22 ns |     1.02 ns |  10,407 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,665.0 ns |     3.90 ns |     3.26 ns |     383 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,325.9 ns |     0.89 ns |     0.83 ns |   9,497 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     6,109.2 ns |    13.01 ns |    11.53 ns |  10,451 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     9,189.3 ns |    32.42 ns |    28.74 ns |     306 B |    3512 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,273.0 ns |     0.67 ns |     0.63 ns |   9,445 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     6,058.9 ns |    10.12 ns |     8.97 ns |  10,414 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     9,084.9 ns |    30.76 ns |    27.27 ns |     383 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,446.1 ns |     4.88 ns |     4.56 ns |   9,501 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    46,712.9 ns |    81.54 ns |    72.28 ns |  10,473 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    68,816.9 ns |   134.82 ns |   126.11 ns |     306 B |   10680 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,423.3 ns |     4.78 ns |     4.47 ns |   9,452 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    46,802.6 ns |    95.79 ns |    89.60 ns |  10,418 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    68,472.1 ns |   200.84 ns |   187.86 ns |     383 B |    2504 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   279,470.2 ns |    56.35 ns |    52.71 ns |   9,501 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   744,239.5 ns | 2,257.00 ns | 2,111.20 ns |  10,473 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,122,360.8 ns | 3,132.07 ns | 2,776.50 ns |     306 B |  133574 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   277,298.9 ns |    36.75 ns |    28.69 ns |   9,446 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   745,560.3 ns | 1,394.46 ns | 1,164.44 ns |  10,418 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,087,291.7 ns | 8,631.15 ns | 7,207.40 ns |     383 B |    2504 B |