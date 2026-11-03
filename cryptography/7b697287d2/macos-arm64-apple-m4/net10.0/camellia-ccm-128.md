| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.536 μs | 0.0041 μs | 0.0038 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.178 μs | 0.0063 μs | 0.0059 μs |    2184 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.487 μs | 0.0050 μs | 0.0047 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.114 μs | 0.0101 μs | 0.0095 μs |    2072 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |     9.675 μs | 0.0242 μs | 0.0226 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    12.695 μs | 0.0353 μs | 0.0330 μs |    7560 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |     9.620 μs | 0.0429 μs | 0.0401 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    12.207 μs | 0.0363 μs | 0.0340 μs |    6552 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    74.954 μs | 0.2043 μs | 0.1911 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |    92.743 μs | 0.3116 μs | 0.2915 μs |   50568 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    74.989 μs | 0.2957 μs | 0.2766 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |    92.517 μs | 0.3668 μs | 0.3431 μs |   42392 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,193.610 μs | 5.0736 μs | 4.7458 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,524.507 μs | 5.2472 μs | 4.9082 μs |  787876 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,195.348 μs | 4.0883 μs | 3.8242 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,471.803 μs | 7.1737 μs | 6.7102 μs |  656792 B |