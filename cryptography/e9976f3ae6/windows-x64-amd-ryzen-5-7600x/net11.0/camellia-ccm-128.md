| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.786 μs |  0.0058 μs |  0.0054 μs |  30,193 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.518 μs |  0.0161 μs |  0.0143 μs |     306 B |    2152 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.754 μs |  0.0112 μs |  0.0105 μs |  30,862 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.484 μs |  0.0130 μs |  0.0115 μs |     386 B |    2000 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    14.862 μs |  0.0157 μs |  0.0123 μs |     306 B |    7528 B |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    17.212 μs |  0.0702 μs |  0.0623 μs |  35,469 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    11.177 μs |  0.0626 μs |  0.0585 μs |  30,985 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    14.771 μs |  0.1188 μs |  0.1112 μs |     386 B |    6480 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    86.538 μs |  0.0697 μs |  0.0617 μs |  23,808 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   113.656 μs |  0.2409 μs |  0.1881 μs |     306 B |   50536 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    88.999 μs |  0.4441 μs |  0.4154 μs |  31,047 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   110.862 μs |  0.1476 μs |  0.1232 μs |     386 B |   42320 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,364.081 μs |  3.0760 μs |  2.5686 μs |  29,438 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,880.124 μs | 12.6430 μs | 11.8263 μs |     306 B |  787869 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,375.944 μs |  2.5487 μs |  2.1283 μs |  35,706 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,769.517 μs |  5.0162 μs |  4.4467 μs |     386 B |  656720 B |