| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       426.6 ns |     0.34 ns |     0.30 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |     2,172.5 ns |     5.97 ns |     5.29 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |     2,989.5 ns |     7.69 ns |     7.19 ns |     310 B |    2992 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       329.5 ns |     0.24 ns |     0.23 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,950.2 ns |     7.07 ns |     6.62 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |     2,755.0 ns |     7.84 ns |     7.34 ns |     387 B |    2544 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,309.1 ns |     1.34 ns |     1.12 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    10,687.1 ns |    37.18 ns |    34.78 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |    13,165.7 ns |    30.68 ns |    28.70 ns |     310 B |    7416 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,214.6 ns |     1.56 ns |     1.46 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    10,541.9 ns |   146.82 ns |   163.19 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |    12,254.9 ns |    31.26 ns |    29.24 ns |     387 B |    3312 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     8,318.3 ns |    12.89 ns |    12.06 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    77,455.1 ns |   283.24 ns |   251.08 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |    96,390.2 ns |   465.30 ns |   412.48 ns |     310 B |   43328 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     8,236.7 ns |    17.16 ns |    16.05 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    77,094.6 ns |   258.79 ns |   242.07 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |    87,913.1 ns |   149.67 ns |   124.98 ns |     387 B |   10480 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   128,951.3 ns |   319.58 ns |   283.30 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,274,731.4 ns | 4,913.63 ns | 4,355.81 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 1,691,769.3 ns | 3,377.06 ns | 3,158.90 ns |     310 B |  657936 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   129,005.7 ns |   172.44 ns |   152.86 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,181,716.6 ns | 2,758.68 ns | 2,445.50 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 1,476,360.9 ns | 1,900.19 ns | 1,586.74 ns |     387 B |  133388 B |