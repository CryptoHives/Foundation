| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |     1.430 μs | 0.0022 μs | 0.0020 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     2.311 μs | 0.0040 μs | 0.0034 μs |     310 B |    1408 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     2.477 μs | 0.0046 μs | 0.0043 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |     1.345 μs | 0.0014 μs | 0.0013 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     2.090 μs | 0.0070 μs | 0.0066 μs |     387 B |    1392 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     2.393 μs | 0.0057 μs | 0.0053 μs |     387 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     9.401 μs | 0.0059 μs | 0.0053 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |    11.361 μs | 0.0195 μs | 0.0183 μs |     310 B |    3648 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |    16.773 μs | 0.0348 μs | 0.0325 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     9.289 μs | 0.0085 μs | 0.0075 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |    11.075 μs | 0.0420 μs | 0.0393 μs |     387 B |    3632 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |    16.638 μs | 0.0667 μs | 0.0623 μs |     390 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    74.787 μs | 0.0565 μs | 0.0501 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    83.133 μs | 0.1245 μs | 0.1165 μs |     310 B |   21568 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |   130.714 μs | 0.2604 μs | 0.2175 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    73.261 μs | 0.1049 μs | 0.0981 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    83.627 μs | 0.0570 μs | 0.0506 μs |     387 B |   21552 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |   130.028 μs | 0.1960 μs | 0.1636 μs |     387 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        | 1,173.052 μs | 1.7204 μs | 1.5251 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        | 1,316.850 μs | 1.5628 μs | 1.3853 μs |     310 B |  328768 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 2,082.508 μs | 4.4044 μs | 4.1199 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        | 1,190.173 μs | 8.4289 μs | 7.8844 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        | 1,331.291 μs | 1.4635 μs | 1.2973 μs |     387 B |  328752 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 2,085.945 μs | 6.7819 μs | 6.3438 μs |     387 B |         - |