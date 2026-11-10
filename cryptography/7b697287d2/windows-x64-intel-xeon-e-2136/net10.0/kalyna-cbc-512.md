| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     7.089 μs |  0.0057 μs |  0.0053 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |    10.239 μs |  0.0291 μs |  0.0272 μs |   2,938 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     4.633 μs |  0.0044 μs |  0.0039 μs |   1,422 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     6.545 μs |  0.0098 μs |  0.0092 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    45.894 μs |  0.0405 μs |  0.0379 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    59.302 μs |  0.1523 μs |  0.1350 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    30.066 μs |  0.0364 μs |  0.0323 μs |   1,413 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    30.846 μs |  0.0365 μs |  0.0323 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   359.899 μs |  0.2992 μs |  0.2799 μs |   1,422 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   455.159 μs |  1.1744 μs |  0.9807 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   229.735 μs |  0.2421 μs |  0.2022 μs |   2,936 B |    1784 B |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   231.785 μs |  0.1546 μs |  0.1446 μs |   1,420 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 5,731.388 μs |  5.9806 μs |  4.9941 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 7,308.696 μs | 12.8231 μs | 11.3674 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 3,699.560 μs |  2.7256 μs |  2.2760 μs |   1,420 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,769.933 μs |  2.9072 μs |  2.5772 μs |   2,934 B |    1784 B |