| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     2.884 μs | 0.0037 μs | 0.0031 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    13.173 μs | 0.0145 μs | 0.0121 μs |  22,965 B |    1024 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     2.285 μs | 0.0036 μs | 0.0033 μs |   1,313 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    13.463 μs | 0.0066 μs | 0.0058 μs |  19,221 B |     896 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |    20.038 μs | 0.0352 μs | 0.0312 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    69.749 μs | 0.1045 μs | 0.0977 μs |  23,012 B |    3712 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |    15.720 μs | 0.0281 μs | 0.0263 μs |   1,307 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    71.389 μs | 0.0666 μs | 0.0590 μs |  19,243 B |    2688 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |   157.014 μs | 0.1722 μs | 0.1438 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   521.789 μs | 0.7938 μs | 0.7037 μs |  22,949 B |   25216 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |   146.119 μs | 1.4639 μs | 1.2977 μs |   1,311 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   538.104 μs | 0.5814 μs | 0.5439 μs |  19,187 B |   17024 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 2,462.334 μs | 4.0988 μs | 3.8340 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 8,416.345 μs | 4.9422 μs | 4.1270 μs |  22,817 B |  393893 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 2,297.436 μs | 6.0814 μs | 5.6885 μs |   1,311 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 8,624.415 μs | 8.2191 μs | 7.6882 μs |  19,219 B |  262810 B |