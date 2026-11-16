| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.336 μs | 0.0046 μs | 0.0043 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     2.357 μs | 0.0053 μs | 0.0050 μs |   2,935 B |     592 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.625 μs | 0.0008 μs | 0.0007 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     2.198 μs | 0.0176 μs | 0.0147 μs |   2,933 B |     592 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     9.321 μs | 0.0073 μs | 0.0068 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    15.524 μs | 0.0429 μs | 0.0381 μs |   2,933 B |    2832 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |    11.495 μs | 0.0033 μs | 0.0029 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    14.389 μs | 0.0282 μs | 0.0250 μs |   2,931 B |    2832 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    74.186 μs | 0.0990 μs | 0.0926 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |   117.475 μs | 0.3162 μs | 0.2957 μs |   2,935 B |   20752 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    89.586 μs | 0.0256 μs | 0.0227 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |   111.011 μs | 0.3503 μs | 0.3277 μs |   2,935 B |   20752 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,172.854 μs | 0.5579 μs | 0.4946 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,863.177 μs | 5.1814 μs | 4.5932 μs |   2,935 B |  327952 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,429.184 μs | 0.3296 μs | 0.2753 μs |   1,307 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,872.991 μs | 4.7980 μs | 4.0066 μs |   2,935 B |  327952 B |