| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     5.488 μs |  0.0054 μs |  0.0045 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     6.342 μs |  0.0063 μs |  0.0059 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     5.341 μs |  0.0034 μs |  0.0030 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     6.197 μs |  0.0058 μs |  0.0048 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    33.698 μs |  0.0233 μs |  0.0194 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    39.055 μs |  0.0310 μs |  0.0290 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    33.549 μs |  0.0314 μs |  0.0294 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    39.056 μs |  0.0364 μs |  0.0340 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   259.930 μs |  0.1949 μs |  0.1628 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   269.323 μs |  3.7158 μs |  3.2940 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   262.352 μs |  1.1038 μs |  1.0325 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   301.417 μs |  0.2050 μs |  0.1918 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 3,461.519 μs |  2.5639 μs |  2.2729 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 4,270.914 μs | 23.2181 μs | 21.7182 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 4,119.390 μs |  2.2744 μs |  2.0162 μs |     390 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 4,765.984 μs |  3.0579 μs |  2.8604 μs |     390 B |         - |