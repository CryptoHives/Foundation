| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     3.371 μs |  0.0066 μs |  0.0055 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     4.797 μs |  0.0038 μs |  0.0036 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     1.869 μs |  0.0013 μs |  0.0010 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     2.585 μs |  0.0024 μs |  0.0022 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    22.073 μs |  0.0855 μs |  0.0714 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    27.741 μs |  0.0224 μs |  0.0187 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    12.130 μs |  0.0106 μs |  0.0089 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    13.397 μs |  0.0287 μs |  0.0255 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   171.704 μs |  0.5070 μs |  0.4742 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   207.023 μs |  0.2231 μs |  0.2087 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |    94.814 μs |  0.0714 μs |  0.0596 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |    97.301 μs |  0.2387 μs |  0.2233 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,736.148 μs | 11.6804 μs | 10.3544 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,325.850 μs |  5.1697 μs |  4.8358 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 1,516.000 μs |  6.7930 μs |  6.3542 μs |    1784 B |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 1,518.979 μs |  1.1743 μs |  1.0410 μs |         - |