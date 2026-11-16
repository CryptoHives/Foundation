| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     1.027 μs |  0.0022 μs |  0.0020 μs |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     1.846 μs |  0.0063 μs |  0.0059 μs |   2,921 B |     576 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     1.276 μs |  0.0014 μs |  0.0011 μs |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     1.734 μs |  0.0055 μs |  0.0046 μs |   2,935 B |     576 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |     7.115 μs |  0.0022 μs |  0.0021 μs |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |    12.485 μs |  0.0306 μs |  0.0271 μs |   2,937 B |    2816 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |     8.963 μs |  0.0062 μs |  0.0055 μs |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |    11.467 μs |  0.0394 μs |  0.0349 μs |   2,935 B |    2816 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    55.528 μs |  0.0184 μs |  0.0164 μs |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    94.664 μs |  0.3134 μs |  0.2778 μs |   2,935 B |   20736 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    69.908 μs |  0.0274 μs |  0.0256 μs |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    87.381 μs |  0.6170 μs |  0.5772 μs |   2,935 B |   20736 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        |   890.069 μs |  0.6017 μs |  0.5629 μs |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 1,555.540 μs | 10.8127 μs | 10.1142 μs |   2,933 B |  327936 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 1,119.588 μs |  0.4904 μs |  0.3829 μs |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 1,422.232 μs |  6.4664 μs |  5.7323 μs |   2,935 B |  327936 B |