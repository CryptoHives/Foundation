| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3.197 μs |  0.0154 μs |  0.0144 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     6.990 μs |  0.0165 μs |  0.0155 μs |         - |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1.730 μs |  0.0034 μs |  0.0030 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     4.950 μs |  0.0113 μs |  0.0100 μs |         - |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    19.554 μs |  0.0696 μs |  0.0651 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    50.070 μs |  0.0529 μs |  0.0469 μs |         - |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9.425 μs |  0.0239 μs |  0.0224 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    35.668 μs |  0.1717 μs |  0.1606 μs |         - |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   150.010 μs |  0.3986 μs |  0.3729 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |   396.756 μs |  1.1871 μs |  1.0523 μs |         - |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    70.744 μs |  0.1432 μs |  0.1340 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |   285.500 μs |  0.7955 μs |  0.7442 μs |         - |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,387.112 μs |  9.0364 μs |  8.4527 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 6,303.839 μs | 25.1612 μs | 23.5358 μs |         - |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,120.473 μs |  2.2923 μs |  2.1442 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 4,492.113 μs | 16.7600 μs | 15.6773 μs |         - |