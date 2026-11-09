| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     2.203 μs |  0.0337 μs |  0.0315 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.006 μs |  0.1835 μs |  0.1716 μs |  22,965 B |    1024 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.754 μs |  0.0261 μs |  0.0244 μs |   1,313 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.327 μs |  0.0551 μs |  0.0515 μs |  19,221 B |     896 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |    15.303 μs |  0.1732 μs |  0.1620 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    53.064 μs |  0.4395 μs |  0.4111 μs |  23,005 B |    3712 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |    12.010 μs |  0.1703 μs |  0.1593 μs |   1,307 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    54.517 μs |  0.7907 μs |  0.7396 μs |  19,243 B |    2688 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |   119.711 μs |  1.4068 μs |  1.3159 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   397.075 μs |  4.7777 μs |  4.4691 μs |  22,938 B |   25216 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |   109.282 μs |  1.5111 μs |  1.4135 μs |   1,305 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   406.003 μs |  6.1589 μs |  5.7610 μs |  19,186 B |   17024 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,911.906 μs | 18.0028 μs | 16.8398 μs |   1,311 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,418.805 μs | 86.3392 μs | 80.7618 μs |  22,817 B |  393895 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,742.557 μs | 30.8404 μs | 28.8481 μs |   1,305 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,546.192 μs | 74.7315 μs | 69.9039 μs |  19,216 B |  262810 B |