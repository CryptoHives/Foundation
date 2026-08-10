| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1.228 μs | 0.0020 μs | 0.0018 μs |     592 B |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.770 μs | 0.0012 μs | 0.0011 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1.228 μs | 0.0028 μs | 0.0027 μs |     592 B |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.782 μs | 0.0112 μs | 0.0094 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8.171 μs | 0.0246 μs | 0.0230 μs |    2832 B |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |    12.707 μs | 0.0343 μs | 0.0321 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8.054 μs | 0.0251 μs | 0.0235 μs |    2832 B |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |    12.680 μs | 0.0184 μs | 0.0163 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    63.813 μs | 0.3432 μs | 0.3211 μs |   20752 B |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |   100.675 μs | 0.2096 μs | 0.1961 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    63.168 μs | 0.1463 μs | 0.1369 μs |   20752 B |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    99.739 μs | 0.1687 μs | 0.1578 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,022.040 μs | 4.8671 μs | 4.0642 μs |  327952 B |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,594.247 μs | 3.9350 μs | 3.6808 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,005.791 μs | 3.9560 μs | 3.5069 μs |  327952 B |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,593.249 μs | 2.9679 μs | 2.7762 μs |         - |