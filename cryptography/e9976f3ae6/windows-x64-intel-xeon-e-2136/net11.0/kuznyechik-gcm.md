| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     2.093 μs |  0.0299 μs |  0.0279 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     3.370 μs |  0.0096 μs |  0.0090 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     2.012 μs |  0.0012 μs |  0.0010 μs |     390 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     3.285 μs |  0.0069 μs |  0.0061 μs |     390 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |    16.448 μs |  0.0047 μs |  0.0044 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    22.667 μs |  0.0819 μs |  0.0726 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |    16.355 μs |  0.0100 μs |  0.0089 μs |     390 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    20.560 μs |  0.3011 μs |  0.2669 μs |     390 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |   107.444 μs |  0.0322 μs |  0.0301 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |   155.878 μs |  0.5780 μs |  0.4826 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |   118.545 μs |  0.0197 μs |  0.0164 μs |     390 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |   176.046 μs |  0.7576 μs |  0.6716 μs |     390 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,713.253 μs |  0.6205 μs |  0.5500 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 2,803.120 μs | 13.4868 μs | 12.6155 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,713.396 μs |  0.5452 μs |  0.4833 μs |     390 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 2,811.137 μs | 21.2474 μs | 19.8748 μs |     390 B |         - |