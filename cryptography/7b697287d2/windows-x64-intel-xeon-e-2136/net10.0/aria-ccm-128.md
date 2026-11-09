| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     5.993 μs |  0.0115 μs |  0.0102 μs |  14,355 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     8.236 μs |  0.1187 μs |  0.1110 μs |     310 B |    3448 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     5.929 μs |  0.0153 μs |  0.0143 μs |  14,408 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     8.154 μs |  0.0298 μs |  0.0265 μs |     390 B |    3336 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    38.757 μs |  0.1380 μs |  0.1224 μs |  14,362 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    44.796 μs |  0.0582 μs |  0.0486 μs |     310 B |    8824 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    38.662 μs |  0.0733 μs |  0.0685 μs |  14,415 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    45.433 μs |  0.1285 μs |  0.1202 μs |     387 B |    7816 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   301.209 μs |  0.5787 μs |  0.5413 μs |  14,366 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   348.876 μs |  1.1194 μs |  1.0470 μs |     310 B |   51832 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   300.830 μs |  0.5643 μs |  0.5003 μs |  14,416 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   350.806 μs |  0.8838 μs |  0.8267 μs |     387 B |   43656 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 4,805.703 μs | 17.0625 μs | 15.9602 μs |  14,366 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 5,521.120 μs | 10.1277 μs |  8.4571 μs |     310 B |  789125 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 4,791.994 μs |  8.6449 μs |  8.0865 μs |  14,419 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 5,422.991 μs | 15.5718 μs | 14.5659 μs |     387 B |  658056 B |