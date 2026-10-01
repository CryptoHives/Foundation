| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.374 μs |  0.0177 μs |  0.0165 μs |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.095 μs |  0.0312 μs |  0.0291 μs |    1024 B |
|                                               |              |              |            |            |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.252 μs |  0.0156 μs |  0.0146 μs |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.563 μs |  0.0496 μs |  0.0464 μs |     896 B |
|                                               |              |              |            |            |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     9.695 μs |  0.1343 μs |  0.1256 μs |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    53.340 μs |  0.2066 μs |  0.1932 μs |    3712 B |
|                                               |              |              |            |            |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     8.818 μs |  0.0780 μs |  0.0691 μs |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    56.663 μs |  0.2309 μs |  0.2160 μs |    2688 B |
|                                               |              |              |            |            |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    76.294 μs |  1.0971 μs |  1.0262 μs |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   399.163 μs |  0.7728 μs |  0.6454 μs |   25216 B |
|                                               |              |              |            |            |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    69.532 μs |  1.0225 μs |  0.9564 μs |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   424.793 μs |  1.0407 μs |  0.9734 μs |   17024 B |
|                                               |              |              |            |            |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,217.283 μs |  7.3547 μs |  6.1415 μs |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,405.605 μs | 20.3004 μs | 18.9890 μs |  393895 B |
|                                               |              |              |            |            |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,115.724 μs | 14.2048 μs | 13.2872 μs |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,791.378 μs | 26.4489 μs | 24.7403 μs |  262810 B |