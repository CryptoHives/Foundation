| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     7.072 μs |  0.0080 μs |  0.0067 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |    10.328 μs |  0.1178 μs |  0.1102 μs |   2,938 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     4.642 μs |  0.0081 μs |  0.0076 μs |   1,422 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     6.521 μs |  0.0134 μs |  0.0126 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    46.209 μs |  0.1096 μs |  0.0971 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    62.121 μs |  0.4561 μs |  0.3809 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    30.071 μs |  0.0569 μs |  0.0444 μs |   1,413 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    32.753 μs |  0.0454 μs |  0.0402 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   355.235 μs |  0.9269 μs |  0.8670 μs |   1,422 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   452.028 μs |  5.0855 μs |  4.5082 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   231.967 μs |  0.5203 μs |  0.4612 μs |   1,411 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   241.989 μs |  0.8001 μs |  0.7484 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 5,680.997 μs | 11.3080 μs | 10.5775 μs |   1,420 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 7,252.989 μs | 97.2504 μs | 86.2100 μs |   2,936 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 3,701.544 μs |  4.5681 μs |  4.2730 μs |   1,420 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,885.270 μs |  3.7650 μs |  3.5218 μs |   2,934 B |    1784 B |