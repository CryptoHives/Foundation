| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     2.832 μs |  0.0188 μs |  0.0176 μs |   1,308 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    13.152 μs |  0.0098 μs |  0.0082 μs |  22,965 B |    1024 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     2.648 μs |  0.0117 μs |  0.0109 μs |   1,307 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    13.477 μs |  0.0238 μs |  0.0223 μs |  19,221 B |     896 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |    19.982 μs |  0.0859 μs |  0.0761 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    70.029 μs |  0.0478 μs |  0.0424 μs |  23,005 B |    3712 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |    16.415 μs |  0.2145 μs |  0.2006 μs |   1,307 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    71.309 μs |  0.0866 μs |  0.0767 μs |  19,243 B |    2688 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |   155.057 μs |  0.5557 μs |  0.4640 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   521.264 μs |  0.7834 μs |  0.6944 μs |  22,953 B |   25216 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |   142.495 μs |  1.0506 μs |  0.9827 μs |   1,305 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   534.159 μs |  0.4060 μs |  0.3391 μs |  19,173 B |   17024 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 2,471.544 μs |  7.4349 μs |  6.5908 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 8,417.662 μs |  5.2481 μs |  4.9091 μs |  22,817 B |  393893 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 2,261.896 μs | 22.9423 μs | 21.4602 μs |   1,305 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 8,556.884 μs |  6.8379 μs |  6.3961 μs |  19,216 B |  262810 B |