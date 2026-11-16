| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.553 μs | 0.0063 μs | 0.0059 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.213 μs | 0.0098 μs | 0.0092 μs |    2184 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.507 μs | 0.0025 μs | 0.0023 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.138 μs | 0.0091 μs | 0.0085 μs |    2072 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |     9.809 μs | 0.0353 μs | 0.0330 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    12.508 μs | 0.0469 μs | 0.0415 μs |    7560 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |     9.765 μs | 0.0750 μs | 0.0701 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    12.393 μs | 0.0403 μs | 0.0377 μs |    6552 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    75.985 μs | 0.3659 μs | 0.3422 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |    94.965 μs | 0.4346 μs | 0.4065 μs |   50568 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    76.115 μs | 0.3534 μs | 0.3306 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |    93.813 μs | 0.3161 μs | 0.2957 μs |   42392 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,212.050 μs | 5.4749 μs | 5.1213 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,529.109 μs | 4.9520 μs | 4.1351 μs |  787876 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,212.108 μs | 5.3282 μs | 4.9840 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,489.871 μs | 4.7175 μs | 4.1819 μs |  656792 B |