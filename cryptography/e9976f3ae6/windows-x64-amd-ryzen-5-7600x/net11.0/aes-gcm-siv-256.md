| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |     331.7 ns |     0.85 ns |     0.71 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |   1,475.2 ns |     8.00 ns |     7.09 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |   1,803.6 ns |     4.68 ns |     3.91 ns |     306 B |    3408 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |     298.4 ns |     0.45 ns |     0.42 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |   1,454.4 ns |    15.94 ns |    14.91 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |   1,710.6 ns |     4.26 ns |     3.56 ns |     386 B |    2960 B |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     972.8 ns |     1.41 ns |     1.25 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |   7,190.4 ns |    17.06 ns |    14.25 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |   7,681.8 ns |    25.93 ns |    22.99 ns |     306 B |    7832 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     935.6 ns |     1.29 ns |     1.07 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |   7,148.4 ns |     9.24 ns |     7.72 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |   7,207.7 ns |    24.25 ns |    20.25 ns |     386 B |    3728 B |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |   6,111.3 ns |     9.99 ns |     8.85 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |  52,669.7 ns |   167.57 ns |   148.54 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |  54,800.3 ns |   229.14 ns |   203.13 ns |     306 B |   43744 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |   6,042.7 ns |     8.50 ns |     7.53 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |  50,920.7 ns |   118.71 ns |    92.68 ns |     386 B |   10896 B |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |  52,970.1 ns |   202.45 ns |   169.06 ns |     386 B |         - |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |  94,321.5 ns |   210.71 ns |   186.79 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 833,312.8 ns | 4,134.61 ns | 3,228.03 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 988,328.4 ns | 3,366.22 ns | 2,984.06 ns |     306 B |  658455 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |  94,334.7 ns |   122.69 ns |   114.76 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 836,213.0 ns | 1,434.70 ns | 1,198.04 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 837,996.9 ns | 3,642.97 ns | 3,042.05 ns |     386 B |  133829 B |