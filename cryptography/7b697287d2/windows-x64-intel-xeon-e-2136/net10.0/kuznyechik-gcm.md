| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     1.611 μs |  0.0165 μs |  0.0154 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     2.356 μs |  0.0439 μs |  0.0411 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     1.544 μs |  0.0232 μs |  0.0217 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     2.334 μs |  0.0368 μs |  0.0344 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |    12.582 μs |  0.1276 μs |  0.1193 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    18.065 μs |  0.2651 μs |  0.2480 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |    12.475 μs |  0.1388 μs |  0.1299 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    17.940 μs |  0.3079 μs |  0.2880 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |    98.266 μs |  1.1948 μs |  1.1176 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |   126.297 μs |  0.9100 μs |  0.8067 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |    97.734 μs |  1.8047 μs |  1.6881 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |   141.197 μs |  1.9983 μs |  1.8693 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,312.082 μs | 20.2918 μs | 18.9810 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 2,030.874 μs | 35.1222 μs | 32.8533 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,565.826 μs |  9.6647 μs |  8.5675 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 2,257.699 μs | 27.3912 μs | 25.6218 μs |     387 B |         - |