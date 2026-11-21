| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |     1.395 μs | 0.0030 μs | 0.0028 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     2.067 μs | 0.0048 μs | 0.0045 μs |     310 B |    1408 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     2.325 μs | 0.0081 μs | 0.0068 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |     1.298 μs | 0.0005 μs | 0.0005 μs |     390 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1.909 μs | 0.0031 μs | 0.0029 μs |     390 B |    1392 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     2.216 μs | 0.0153 μs | 0.0136 μs |     390 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     9.048 μs | 0.0101 μs | 0.0089 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |    10.085 μs | 0.0117 μs | 0.0104 μs |     310 B |    3648 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |    15.137 μs | 0.0107 μs | 0.0090 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     9.069 μs | 0.0083 μs | 0.0078 μs |     390 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     9.750 μs | 0.0111 μs | 0.0104 μs |     390 B |    3632 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |    15.208 μs | 0.0356 μs | 0.0333 μs |     390 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    71.161 μs | 0.0294 μs | 0.0261 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    73.867 μs | 0.1229 μs | 0.1149 μs |     310 B |   21568 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |   117.996 μs | 0.3424 μs | 0.2860 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    70.611 μs | 0.0653 μs | 0.0611 μs |     390 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    73.023 μs | 0.0846 μs | 0.0792 μs |     390 B |   21552 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |   119.606 μs | 0.3366 μs | 0.2984 μs |     390 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        | 1,155.434 μs | 1.4980 μs | 1.4012 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        | 1,181.267 μs | 1.3956 μs | 1.3054 μs |     310 B |  328768 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,892.216 μs | 5.0706 μs | 4.4950 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        | 1,163.497 μs | 1.6994 μs | 1.5896 μs |     390 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        | 1,183.819 μs | 1.9179 μs | 1.7940 μs |     390 B |  328752 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,897.340 μs | 4.9056 μs | 4.0964 μs |     390 B |         - |