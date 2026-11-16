| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       420.9 ns |     0.30 ns |     0.27 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |     2,158.7 ns |    27.87 ns |    23.28 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |     2,971.3 ns |     3.47 ns |     2.71 ns |     310 B |    2992 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       328.6 ns |     0.42 ns |     0.37 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,972.1 ns |    12.14 ns |    10.14 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |     2,713.9 ns |     4.56 ns |     4.04 ns |     387 B |    2544 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,299.6 ns |     3.72 ns |     3.48 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    10,760.1 ns |   109.80 ns |   102.71 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |    13,158.4 ns |    64.48 ns |    53.84 ns |     310 B |    7416 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,206.8 ns |     4.49 ns |     4.20 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    10,395.8 ns |    89.51 ns |    74.74 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |    12,253.8 ns |   139.90 ns |   116.83 ns |     387 B |    3312 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     8,276.2 ns |    35.09 ns |    32.82 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    81,480.0 ns | 1,257.99 ns | 1,115.17 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |    94,032.1 ns |   584.80 ns |   547.02 ns |     310 B |   43328 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     8,178.1 ns |    39.47 ns |    36.92 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    78,284.6 ns | 1,489.51 ns | 1,883.76 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |    88,278.6 ns |   576.12 ns |   538.90 ns |     387 B |   10480 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   128,517.5 ns |   504.64 ns |   472.04 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,283,699.3 ns | 8,671.23 ns | 6,769.93 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 1,716,388.5 ns | 3,352.95 ns | 2,972.30 ns |     310 B |  657936 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   128,127.3 ns |   533.14 ns |   498.70 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,279,718.1 ns | 8,593.73 ns | 6,709.42 ns |     387 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 1,452,299.8 ns | 1,397.38 ns | 1,307.11 ns |     387 B |  133388 B |