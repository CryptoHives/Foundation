| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.190 μs |  0.0114 μs |  0.0101 μs |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |     8.618 μs |  0.0199 μs |  0.0166 μs |    1024 B |
|                                               |              |              |            |            |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.087 μs |  0.0055 μs |  0.0043 μs |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |     9.001 μs |  0.0281 μs |  0.0263 μs |     896 B |
|                                               |              |              |            |            |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     8.383 μs |  0.0489 μs |  0.0382 μs |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    45.599 μs |  0.1148 μs |  0.1073 μs |    3712 B |
|                                               |              |              |            |            |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     7.751 μs |  0.0892 μs |  0.0745 μs |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    48.389 μs |  0.0727 μs |  0.0607 μs |    2688 B |
|                                               |              |              |            |            |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    66.191 μs |  0.4718 μs |  0.4182 μs |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   341.249 μs |  0.8048 μs |  0.7135 μs |   25216 B |
|                                               |              |              |            |            |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    60.797 μs |  0.1156 μs |  0.0965 μs |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   364.708 μs |  0.4505 μs |  0.3517 μs |   17024 B |
|                                               |              |              |            |            |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,056.799 μs |  6.7414 μs |  5.6294 μs |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 5,496.237 μs | 29.2966 μs | 25.9707 μs |  393895 B |
|                                               |              |              |            |            |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   968.673 μs |  6.1007 μs |  5.7066 μs |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 5,810.559 μs | 12.6717 μs | 10.5814 μs |  262810 B |