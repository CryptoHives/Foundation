| Description                                           | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       524.7 ns |      1.08 ns |      1.01 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     2,619.7 ns |     18.75 ns |     16.62 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     3,778.9 ns |      9.52 ns |      8.91 ns |     310 B |    3408 B |
|                                                       |              |                |              |              |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       434.3 ns |      1.18 ns |      1.10 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     2,496.7 ns |     36.25 ns |     33.91 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     3,572.9 ns |      9.38 ns |      8.32 ns |     387 B |    2960 B |
|                                                       |              |                |              |              |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,558.7 ns |      4.17 ns |      3.90 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    12,131.0 ns |    120.01 ns |    100.22 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |    15,981.6 ns |     84.47 ns |     74.88 ns |     310 B |    7832 B |
|                                                       |              |                |              |              |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,468.6 ns |      1.14 ns |      1.01 ns |     390 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    12,261.9 ns |    117.29 ns |    103.97 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |    15,165.3 ns |    125.24 ns |    117.15 ns |     387 B |    3728 B |
|                                                       |              |                |              |              |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     9,745.0 ns |     44.87 ns |     41.97 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    92,053.8 ns |  1,683.51 ns |  1,653.43 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |   114,386.1 ns |    380.71 ns |    356.12 ns |     310 B |   43744 B |
|                                                       |              |                |              |              |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     9,663.6 ns |     25.38 ns |     23.74 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    90,158.5 ns |  1,758.55 ns |  1,805.90 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |   106,292.6 ns |    581.80 ns |    515.75 ns |     387 B |   10896 B |
|                                                       |              |                |              |              |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   150,913.7 ns |    361.59 ns |    338.23 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,469,884.8 ns | 11,192.78 ns |  8,738.59 ns |     310 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,978,965.3 ns |  9,600.36 ns |  8,510.47 ns |     310 B |  658350 B |
|                                                       |              |                |              |              |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   150,754.9 ns |    559.20 ns |    523.08 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,434,845.8 ns | 22,227.96 ns | 19,704.51 ns |     387 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,759,294.7 ns |  3,721.63 ns |  3,481.22 ns |     387 B |  133804 B |