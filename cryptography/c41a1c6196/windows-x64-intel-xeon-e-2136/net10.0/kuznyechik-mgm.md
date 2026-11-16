| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Median       | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     5.511 μs |   0.0235 μs |   0.0436 μs |     5.509 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     6.133 μs |   0.1830 μs |   0.3438 μs |     6.352 μs |     310 B |         - |
|                                               |              |              |             |             |              |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     5.419 μs |   0.0283 μs |   0.0532 μs |     5.414 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     6.013 μs |   0.1734 μs |   0.3257 μs |     6.217 μs |     390 B |         - |
|                                               |              |              |             |             |              |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    31.915 μs |   1.4436 μs |   2.6032 μs |    33.676 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    38.030 μs |   1.3103 μs |   2.4286 μs |    39.344 μs |     310 B |         - |
|                                               |              |              |             |             |              |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    32.082 μs |   1.3328 μs |   2.5358 μs |    33.695 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    39.157 μs |   0.1026 μs |   0.1902 μs |    39.160 μs |     387 B |         - |
|                                               |              |              |             |             |              |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   218.806 μs |   0.6211 μs |   1.1513 μs |   218.271 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   270.779 μs |   3.0461 μs |   5.6462 μs |   273.278 μs |     310 B |         - |
|                                               |              |              |             |             |              |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   260.142 μs |   0.7806 μs |   1.3465 μs |   260.064 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   302.294 μs |   0.9968 μs |   1.8227 μs |   301.835 μs |     387 B |         - |
|                                               |              |              |             |             |              |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 3,481.394 μs |   9.3148 μs |  17.7224 μs | 3,477.543 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 4,158.558 μs |  19.2125 μs |  36.0856 μs | 4,147.537 μs |     310 B |         - |
|                                               |              |              |             |             |              |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 3,909.416 μs | 170.3321 μs | 315.7215 μs | 4,123.196 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 4,820.739 μs |  15.1934 μs |  28.9070 μs | 4,809.524 μs |     390 B |         - |