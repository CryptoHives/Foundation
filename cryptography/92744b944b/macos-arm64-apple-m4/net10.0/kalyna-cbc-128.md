| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |    10.647 μs |  0.0055 μs |  0.0051 μs |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |    11.408 μs |  0.0098 μs |  0.0092 μs |     872 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     5.975 μs |  0.0042 μs |  0.0037 μs |     872 B |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     9.549 μs |  0.0290 μs |  0.0271 μs |         - |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    72.699 μs |  0.0466 μs |  0.0436 μs |     872 B |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |    76.134 μs |  0.0295 μs |  0.0246 μs |         - |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    33.716 μs |  0.0235 μs |  0.0196 μs |     872 B |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |    68.741 μs |  0.2542 μs |  0.2122 μs |         - |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   562.699 μs |  0.4849 μs |  0.4299 μs |     872 B |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |   601.110 μs |  0.4157 μs |  0.3685 μs |         - |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   255.848 μs |  0.1039 μs |  0.0868 μs |     872 B |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |   542.563 μs |  2.6695 μs |  2.4971 μs |         - |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 8,970.836 μs | 10.4951 μs |  8.7639 μs |     872 B |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 9,627.223 μs | 28.4509 μs | 26.6130 μs |         - |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 4,066.766 μs |  2.7149 μs |  2.1196 μs |     872 B |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 8,725.221 μs | 23.8144 μs | 22.2760 μs |         - |