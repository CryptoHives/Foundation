| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     4.564 μs |  0.0547 μs |  0.0512 μs |   1,402 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     6.407 μs |  0.0852 μs |  0.0797 μs |   2,914 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     2.869 μs |  0.0307 μs |  0.0287 μs |   1,404 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     3.979 μs |  0.0543 μs |  0.0508 μs |   2,912 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    29.904 μs |  0.3251 μs |  0.3041 μs |   1,402 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    36.171 μs |  0.4924 μs |  0.4365 μs |   2,914 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    18.717 μs |  0.2277 μs |  0.2130 μs |   1,395 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    20.119 μs |  0.1430 μs |  0.1268 μs |   2,910 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   232.659 μs |  2.8454 μs |  2.6616 μs |   1,402 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   274.982 μs |  2.6592 μs |  2.4874 μs |   2,912 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   146.124 μs |  1.8557 μs |  1.7358 μs |   1,393 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   152.108 μs |  1.7710 μs |  1.5700 μs |   2,912 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 3,701.814 μs | 39.8988 μs | 37.3214 μs |   1,402 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 4,374.876 μs | 52.5146 μs | 49.1221 μs |   2,910 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,333.393 μs | 27.6082 μs | 25.8247 μs |   1,393 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 2,396.561 μs | 36.6381 μs | 34.2713 μs |   2,912 B |    1784 B |