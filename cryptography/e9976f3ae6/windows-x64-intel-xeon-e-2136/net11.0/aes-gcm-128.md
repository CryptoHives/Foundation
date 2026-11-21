| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       203.4 ns |     0.28 ns |     0.25 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 17B          |       254.9 ns |     0.38 ns |     0.32 ns |   2,390 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |       694.9 ns |     3.66 ns |     3.42 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     1,072.2 ns |     2.86 ns |     2.39 ns |     310 B |    1624 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 17B          |       132.3 ns |     0.33 ns |     0.27 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 17B          |       265.5 ns |     0.81 ns |     0.72 ns |   2,268 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |       620.5 ns |     4.07 ns |     3.81 ns |     390 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |       934.6 ns |     3.66 ns |     3.42 ns |     390 B |    1608 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       219.1 ns |     0.59 ns |     0.52 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 65B          |       263.3 ns |     1.18 ns |     1.11 ns |   2,390 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     1,194.1 ns |     2.51 ns |     2.22 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     1,427.0 ns |     3.68 ns |     3.44 ns |     310 B |    1624 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 65B          |       145.3 ns |     1.45 ns |     1.29 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 65B          |       273.8 ns |     0.68 ns |     0.57 ns |   2,268 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     1,132.2 ns |    22.34 ns |    20.90 ns |     390 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     1,250.5 ns |    15.12 ns |    12.63 ns |     390 B |    1608 B |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       219.7 ns |     0.23 ns |     0.20 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 128B         |       262.2 ns |     0.30 ns |     0.27 ns |   2,390 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     1,705.4 ns |     7.50 ns |     7.01 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     1,706.9 ns |     5.02 ns |     4.19 ns |     310 B |    1624 B |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128B         |       140.5 ns |     0.28 ns |     0.25 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 128B         |       265.5 ns |     0.44 ns |     0.37 ns |   2,268 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     1,517.9 ns |     4.71 ns |     4.17 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     1,616.4 ns |     4.74 ns |     4.20 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       252.0 ns |     0.32 ns |     0.28 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |       292.0 ns |     0.37 ns |     0.33 ns |   2,390 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |     1,951.3 ns |     6.61 ns |     5.52 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     2,034.2 ns |     8.86 ns |     8.29 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 152B         |       189.4 ns |     1.16 ns |     1.02 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |       287.7 ns |     0.52 ns |     0.41 ns |   2,268 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     1,749.6 ns |     4.61 ns |     4.08 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     1,990.1 ns |     3.20 ns |     2.67 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       280.5 ns |     0.42 ns |     0.35 ns |     310 B |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |       294.5 ns |     0.64 ns |     0.57 ns |   2,390 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |     2,487.8 ns |     4.85 ns |     4.05 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     3,070.0 ns |     4.82 ns |     3.77 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 256B         |       185.0 ns |     0.29 ns |     0.24 ns |     387 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |       294.6 ns |     0.36 ns |     0.28 ns |   2,265 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |     2,315.0 ns |     5.79 ns |     4.84 ns |     387 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     2,996.6 ns |    15.17 ns |    14.19 ns |     387 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |       473.3 ns |     0.52 ns |     0.44 ns |   2,390 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       597.2 ns |     2.77 ns |     2.59 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     7,202.9 ns |    10.48 ns |     8.19 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |    11,093.7 ns |    58.08 ns |    54.33 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 1KB          |       470.7 ns |     1.77 ns |     1.66 ns |     390 B |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |       480.4 ns |     1.04 ns |     0.81 ns |   2,268 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     7,014.7 ns |     9.11 ns |     8.07 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |    10,901.1 ns |    49.44 ns |    43.83 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |     2,216.6 ns |     2.81 ns |     2.35 ns |   2,390 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,520.8 ns |     9.21 ns |     8.61 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    51,028.3 ns |   116.20 ns |   103.01 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    84,909.1 ns |   186.05 ns |   155.36 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |     2,183.9 ns |     7.43 ns |     6.59 ns |   2,268 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 8KB          |     3,165.5 ns |     6.58 ns |     6.16 ns |     390 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    50,805.3 ns |    58.89 ns |    45.97 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    84,868.0 ns |   152.17 ns |   118.81 ns |     390 B |         - |
|                                                   |              |                |             |             |           |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |    31,777.4 ns |    66.09 ns |    55.19 ns |   2,390 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    61,903.5 ns |    90.99 ns |    80.66 ns |     310 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   808,039.8 ns | 1,669.01 ns | 1,479.53 ns |     310 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 1,352,263.7 ns | 1,700.72 ns | 1,327.81 ns |     310 B |         - |
|                                                   |              |                |             |             |           |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |    31,390.2 ns |   145.78 ns |   121.73 ns |   2,268 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul) | 128KB        |    49,751.9 ns |   119.39 ns |   105.84 ns |     390 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   806,014.1 ns |   528.80 ns |   468.77 ns |     390 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 1,352,034.7 ns | 4,923.80 ns | 4,605.73 ns |     390 B |         - |