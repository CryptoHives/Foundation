| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.344 μs |  0.0118 μs |  0.0099 μs |   3,992 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.036 μs |  0.0159 μs |  0.0141 μs |  24,803 B |    1024 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.239 μs |  0.0061 μs |  0.0054 μs |  10,338 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.510 μs |  0.0264 μs |  0.0234 μs |  22,115 B |     896 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     9.705 μs |  0.1852 μs |  0.1902 μs |  10,327 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    53.465 μs |  0.1783 μs |  0.1581 μs |  31,176 B |    3712 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     8.780 μs |  0.0690 μs |  0.0645 μs |   3,992 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    56.563 μs |  0.1208 μs |  0.1130 μs |  28,385 B |    2688 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    75.848 μs |  0.9523 μs |  0.8442 μs |   3,992 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   400.132 μs |  1.1291 μs |  1.0562 μs |  22,194 B |   25216 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    68.819 μs |  0.3739 μs |  0.3498 μs |   3,992 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   424.753 μs |  0.8686 μs |  0.8125 μs |  19,410 B |   17024 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,243.644 μs |  9.6166 μs |  8.9954 μs |  10,468 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,730.711 μs | 17.2765 μs | 15.3152 μs |  22,243 B |  394008 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,097.800 μs |  7.1153 μs |  6.6557 μs |   3,992 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,808.304 μs | 14.0281 μs | 13.1219 μs |  19,452 B |  262885 B |