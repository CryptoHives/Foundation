| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     3.188 μs | 0.0025 μs | 0.0024 μs |  23,239 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     4.030 μs | 0.0153 μs | 0.0143 μs |     310 B |    2152 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     3.112 μs | 0.0015 μs | 0.0013 μs |  24,826 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     3.925 μs | 0.0074 μs | 0.0066 μs |     390 B |    2000 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    19.860 μs | 0.0090 μs | 0.0084 μs |  32,181 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    22.032 μs | 0.0371 μs | 0.0329 μs |     310 B |    7528 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    20.046 μs | 0.0091 μs | 0.0085 μs |  27,282 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    22.262 μs | 0.1876 μs | 0.1465 μs |     390 B |    6480 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |   154.671 μs | 0.0437 μs | 0.0387 μs |  30,933 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   169.729 μs | 0.3172 μs | 0.2967 μs |     310 B |   50536 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |   153.378 μs | 0.1114 μs | 0.1042 μs |  35,362 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   172.362 μs | 0.5636 μs | 0.4996 μs |     390 B |   42320 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 2,446.370 μs | 0.7545 μs | 0.6689 μs |  23,028 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 2,774.403 μs | 6.0296 μs | 5.6401 μs |     310 B |  787867 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 2,442.194 μs | 0.8067 μs | 0.7151 μs |  31,103 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 2,632.295 μs | 3.2951 μs | 2.9210 μs |     390 B |  656720 B |