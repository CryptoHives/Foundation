| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.023 μs | 0.0036 μs | 0.0033 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1.726 μs | 0.0045 μs | 0.0042 μs |   2,935 B |     584 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.220 μs | 0.0044 μs | 0.0041 μs |   1,307 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1.628 μs | 0.0038 μs | 0.0033 μs |   2,933 B |     584 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     7.019 μs | 0.0184 μs | 0.0172 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    11.645 μs | 0.0298 μs | 0.0279 μs |   2,933 B |    2824 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     8.613 μs | 0.0265 μs | 0.0207 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    11.195 μs | 0.0296 μs | 0.0262 μs |   2,933 B |    2824 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    55.363 μs | 0.1638 μs | 0.1532 μs |   1,298 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    89.154 μs | 0.3094 μs | 0.2742 μs |   2,935 B |   20744 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    67.507 μs | 0.2252 μs | 0.2107 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    83.260 μs | 0.2198 μs | 0.1949 μs |   2,933 B |   20744 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   880.850 μs | 2.6967 μs | 2.5225 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,455.691 μs | 4.2886 μs | 4.0115 μs |   2,935 B |  327944 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,078.088 μs | 3.8266 μs | 3.5794 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,415.541 μs | 6.4568 μs | 5.7238 μs |   2,935 B |  327944 B |