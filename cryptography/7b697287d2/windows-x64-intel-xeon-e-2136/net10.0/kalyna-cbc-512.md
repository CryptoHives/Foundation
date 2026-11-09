| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     5.461 μs |  0.0725 μs |  0.0678 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     7.889 μs |  0.0213 μs |  0.0199 μs |   2,938 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     3.537 μs |  0.0463 μs |  0.0433 μs |   1,422 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     5.011 μs |  0.0269 μs |  0.0252 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    35.167 μs |  0.1309 μs |  0.1224 μs |   1,417 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    46.292 μs |  0.3166 μs |  0.2961 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    22.876 μs |  0.3271 μs |  0.3060 μs |   1,413 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    25.189 μs |  0.4097 μs |  0.3832 μs |   2,934 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   274.398 μs |  2.9950 μs |  2.8015 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   345.282 μs |  5.8809 μs |  5.5010 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   172.064 μs |  2.4997 μs |  2.3382 μs |   2,936 B |    1784 B |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   177.649 μs |  1.4187 μs |  1.3271 μs |   1,411 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 4,384.579 μs | 51.5998 μs | 48.2665 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 5,614.131 μs | 81.1564 μs | 75.9137 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,815.883 μs | 45.7955 μs | 42.8371 μs |   1,411 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 2,865.376 μs | 50.0923 μs | 46.8564 μs |   2,934 B |    1784 B |