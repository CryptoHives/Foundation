| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     4.535 μs |  0.0234 μs |  0.0219 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     6.349 μs |  0.0978 μs |  0.0915 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     2.859 μs |  0.0341 μs |  0.0319 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     3.931 μs |  0.0555 μs |  0.0519 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    29.822 μs |  0.2255 μs |  0.1883 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    35.965 μs |  0.3959 μs |  0.3703 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    18.627 μs |  0.1868 μs |  0.1747 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    20.226 μs |  0.2383 μs |  0.2229 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   230.502 μs |  2.7369 μs |  2.5601 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   273.346 μs |  3.1225 μs |  2.9208 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   145.360 μs |  1.5850 μs |  1.4050 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   149.160 μs |  1.5517 μs |  1.4515 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 3,680.839 μs | 13.2706 μs | 11.7641 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 4,330.052 μs | 37.7907 μs | 33.5005 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,321.081 μs | 24.6032 μs | 23.0139 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 2,357.126 μs | 31.7129 μs | 29.6642 μs |    1784 B |