| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       526.8 ns |     0.47 ns |     0.42 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     2,641.4 ns |     9.87 ns |     9.23 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     3,876.5 ns |    26.99 ns |    22.54 ns |     310 B |    3408 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       433.7 ns |     0.29 ns |     0.27 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     2,517.9 ns |    17.42 ns |    16.30 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     3,631.3 ns |     6.34 ns |     5.93 ns |     390 B |    2960 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,562.0 ns |     1.83 ns |     1.71 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    12,459.4 ns |    39.13 ns |    32.67 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |    16,277.9 ns |    31.55 ns |    26.34 ns |     310 B |    7832 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,470.4 ns |     1.81 ns |     1.69 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    12,291.8 ns |    33.08 ns |    29.33 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |    15,077.6 ns |    31.30 ns |    29.27 ns |     387 B |    3728 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     9,783.0 ns |    19.55 ns |    18.29 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    89,798.8 ns |   588.93 ns |   550.88 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |   113,613.8 ns |   203.18 ns |   190.05 ns |     310 B |   43744 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     9,700.6 ns |     9.04 ns |     8.46 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    92,922.0 ns |   354.74 ns |   331.82 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |   108,467.9 ns |   201.73 ns |   188.69 ns |     387 B |   10896 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   151,135.8 ns |   261.43 ns |   244.54 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,423,446.7 ns | 6,414.99 ns | 6,000.59 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,993,388.2 ns | 5,775.56 ns | 5,402.46 ns |     310 B |  658350 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   151,168.9 ns |   143.25 ns |   134.00 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,405,936.4 ns | 6,294.65 ns | 5,580.05 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,732,064.4 ns | 1,283.60 ns | 1,071.87 ns |     387 B |  133804 B |