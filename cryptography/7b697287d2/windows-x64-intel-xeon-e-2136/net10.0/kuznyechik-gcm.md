| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     2.099 μs |  0.0020 μs |  0.0018 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     3.133 μs |  0.0057 μs |  0.0050 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     2.017 μs |  0.0012 μs |  0.0011 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     3.194 μs |  0.0257 μs |  0.0241 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |    13.989 μs |  0.0107 μs |  0.0095 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    23.739 μs |  0.0308 μs |  0.0258 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |    17.028 μs |  0.0870 μs |  0.0679 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    21.092 μs |  0.0345 μs |  0.0288 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |   133.009 μs |  1.0250 μs |  0.9588 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |   165.287 μs |  0.3897 μs |  0.3454 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |   128.908 μs |  0.3061 μs |  0.2556 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |   185.754 μs |  0.3232 μs |  0.3023 μs |     387 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 2,272.586 μs | 43.4858 μs | 54.9956 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 2,930.014 μs | 16.1093 μs | 15.0686 μs |     310 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 2,047.077 μs |  1.2605 μs |  1.1174 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 3,008.941 μs | 21.6442 μs | 20.2460 μs |     387 B |         - |