| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     3.423 μs |  0.0173 μs |  0.0162 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     4.866 μs |  0.0095 μs |  0.0089 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     1.880 μs |  0.0037 μs |  0.0032 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     2.625 μs |  0.0022 μs |  0.0020 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    22.342 μs |  0.0819 μs |  0.0726 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    27.951 μs |  0.0541 μs |  0.0506 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    12.280 μs |  0.0428 μs |  0.0379 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    13.281 μs |  0.0276 μs |  0.0258 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   174.011 μs |  0.5062 μs |  0.4488 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   210.101 μs |  0.3383 μs |  0.3165 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |    96.010 μs |  0.1757 μs |  0.1371 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |    97.194 μs |  0.3138 μs |  0.2935 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,775.779 μs |  7.0900 μs |  5.9204 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,385.132 μs | 16.7471 μs | 15.6652 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 1,521.297 μs |  3.1285 μs |  2.7733 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 1,534.585 μs |  4.6497 μs |  4.3494 μs |    1784 B |