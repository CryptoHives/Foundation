| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.830 μs | 0.0008 μs | 0.0007 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     2.741 μs | 0.0053 μs | 0.0049 μs |     310 B |    1440 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     2.876 μs | 0.0090 μs | 0.0080 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.736 μs | 0.0013 μs | 0.0012 μs |     390 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     2.540 μs | 0.0039 μs | 0.0037 μs |     387 B |    1424 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     2.803 μs | 0.0055 μs | 0.0046 μs |     387 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |    12.277 μs | 0.0161 μs | 0.0151 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |    14.280 μs | 0.0196 μs | 0.0183 μs |     310 B |    3680 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    19.736 μs | 0.0308 μs | 0.0273 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |    12.110 μs | 0.0090 μs | 0.0080 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |    14.136 μs | 0.0121 μs | 0.0107 μs |     387 B |    3664 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    19.354 μs | 0.0366 μs | 0.0324 μs |     387 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    97.144 μs | 0.0669 μs | 0.0559 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |   107.187 μs | 0.1188 μs | 0.1111 μs |     310 B |   21600 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |   152.180 μs | 0.2415 μs | 0.2141 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    94.881 μs | 0.0735 μs | 0.0688 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |   106.645 μs | 0.0849 μs | 0.0663 μs |     387 B |   21584 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |   152.482 μs | 0.6616 μs | 0.5865 μs |     387 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,541.363 μs | 1.9873 μs | 1.8589 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,681.356 μs | 2.6697 μs | 2.4972 μs |     310 B |  328800 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 2,438.214 μs | 7.9115 μs | 7.4004 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,557.808 μs | 1.1483 μs | 1.0179 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,684.929 μs | 2.3552 μs | 2.2031 μs |     387 B |  328784 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 2,432.172 μs | 5.5685 μs | 4.9363 μs |     387 B |         - |