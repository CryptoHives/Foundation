| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     4.230 μs |  0.0133 μs |  0.0118 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     4.841 μs |  0.0739 μs |  0.0692 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     4.083 μs |  0.0562 μs |  0.0526 μs |     390 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     4.754 μs |  0.0553 μs |  0.0517 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    25.661 μs |  0.3060 μs |  0.2862 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    26.231 μs |  0.3919 μs |  0.3666 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    25.518 μs |  0.4122 μs |  0.3856 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    29.800 μs |  0.3566 μs |  0.3336 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   170.361 μs |  3.1972 μs |  2.9907 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   198.885 μs |  3.2769 μs |  3.0652 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   197.496 μs |  2.2627 μs |  2.1165 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   228.275 μs |  3.3784 μs |  3.1602 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 2,650.688 μs | 26.4929 μs | 24.7815 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 3,273.020 μs | 45.8287 μs | 42.8682 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 3,132.030 μs | 45.9753 μs | 43.0053 μs |     387 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 3,637.557 μs | 49.9119 μs | 46.6877 μs |     387 B |         - |