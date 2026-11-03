| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.356 μs | 0.0018 μs | 0.0016 μs |   1,289 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.023 μs | 0.0063 μs | 0.0059 μs |  22,936 B |    1024 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.256 μs | 0.0026 μs | 0.0024 μs |   1,285 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.442 μs | 0.0087 μs | 0.0081 μs |  19,192 B |     896 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     9.594 μs | 0.0138 μs | 0.0129 μs |   1,289 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    53.018 μs | 0.0443 μs | 0.0393 μs |  22,969 B |    3712 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     8.846 μs | 0.0214 μs | 0.0201 μs |   1,285 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    56.295 μs | 0.0224 μs | 0.0198 μs |  19,213 B |    2688 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    75.550 μs | 0.1491 μs | 0.1395 μs |   1,289 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   397.411 μs | 0.1812 μs | 0.1695 μs |  22,924 B |   25216 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    69.461 μs | 0.4017 μs | 0.3758 μs |   1,283 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   422.528 μs | 0.1337 μs | 0.1186 μs |  19,157 B |   17024 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,210.375 μs | 2.9672 μs | 2.7755 μs |   1,289 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,372.625 μs | 8.6495 μs | 7.2228 μs |  22,788 B |  393895 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,101.522 μs | 1.7373 μs | 1.6251 μs |   1,283 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,768.253 μs | 5.9120 μs | 5.5301 μs |  19,038 B |  262810 B |