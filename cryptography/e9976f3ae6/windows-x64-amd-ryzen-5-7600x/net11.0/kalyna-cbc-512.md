| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     4.522 μs |  0.0275 μs |  0.0244 μs |   4,189 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     6.185 μs |  0.0447 μs |  0.0418 μs |  13,698 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     2.761 μs |  0.0165 μs |  0.0155 μs |   4,189 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     3.788 μs |  0.0221 μs |  0.0207 μs |   7,739 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    29.664 μs |  0.1412 μs |  0.1252 μs |   4,189 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    35.277 μs |  0.1986 μs |  0.1858 μs |  13,702 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    17.834 μs |  0.1008 μs |  0.0943 μs |   4,189 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    19.372 μs |  0.1295 μs |  0.1148 μs |  13,698 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   230.965 μs |  0.7870 μs |  0.6976 μs |   4,189 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   267.946 μs |  1.4091 μs |  1.3180 μs |   7,734 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   138.585 μs |  0.9224 μs |  0.8177 μs |   4,189 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   145.107 μs |  1.3475 μs |  1.2604 μs |  13,716 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 3,682.404 μs | 15.8465 μs | 14.8228 μs |  10,524 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 4,247.528 μs | 37.3294 μs | 34.9180 μs |  13,693 B |    1784 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,199.200 μs |  9.9508 μs |  8.8211 μs |  10,714 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 2,294.893 μs | 17.3975 μs | 16.2736 μs |   7,743 B |    1784 B |