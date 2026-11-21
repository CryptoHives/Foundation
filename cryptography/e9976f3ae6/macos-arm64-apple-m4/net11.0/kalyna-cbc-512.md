| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     3.412 μs |  0.0159 μs |  0.0133 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     4.738 μs |  0.0096 μs |  0.0090 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     1.846 μs |  0.0053 μs |  0.0044 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     2.627 μs |  0.0089 μs |  0.0083 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    25.379 μs |  0.1619 μs |  0.1514 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    27.101 μs |  0.0211 μs |  0.0198 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    12.030 μs |  0.0548 μs |  0.0457 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    13.248 μs |  0.0554 μs |  0.0518 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   173.306 μs |  0.2637 μs |  0.2466 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   206.304 μs |  0.3118 μs |  0.2764 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |    93.668 μs |  0.3016 μs |  0.2821 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |    97.340 μs |  0.4666 μs |  0.3896 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,763.882 μs | 10.9408 μs | 10.2341 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,269.471 μs |  2.7996 μs |  2.6187 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 1,500.396 μs |  5.2229 μs |  4.3613 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 1,548.161 μs |  6.6583 μs |  5.9024 μs |    1784 B |