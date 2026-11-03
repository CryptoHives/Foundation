| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.326 μs |  0.0081 μs |  0.0076 μs |  18,613 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     3.340 μs |  0.0092 μs |  0.0086 μs |     306 B |    2232 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.244 μs |  0.0096 μs |  0.0090 μs |  18,651 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     3.373 μs |  0.0057 μs |  0.0053 μs |     383 B |    2120 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    14.577 μs |  0.0216 μs |  0.0192 μs |  18,623 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    20.007 μs |  0.0610 μs |  0.0571 μs |     306 B |    7608 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    14.417 μs |  0.0334 μs |  0.0313 μs |  18,661 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    19.843 μs |  0.0751 μs |  0.0703 μs |     383 B |    6600 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   112.852 μs |  0.1800 μs |  0.1595 μs |  18,627 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   152.378 μs |  0.7912 μs |  0.7401 μs |     306 B |   50616 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   112.103 μs |  0.2180 μs |  0.2039 μs |  18,665 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   152.099 μs |  0.3689 μs |  0.3451 μs |     383 B |   42440 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,820.498 μs |  2.7688 μs |  2.4544 μs |  18,627 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 2,506.838 μs | 11.1579 μs | 10.4371 μs |     306 B |  787909 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,789.959 μs |  2.3039 μs |  2.0423 μs |  18,665 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 2,418.154 μs |  8.3570 μs |  7.4082 μs |     383 B |  656840 B |