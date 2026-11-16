| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.387 μs |  0.0094 μs |  0.0083 μs |   1,289 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.092 μs |  0.0300 μs |  0.0281 μs |  22,936 B |    1024 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.266 μs |  0.0150 μs |  0.0140 μs |   1,285 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10.539 μs |  0.0462 μs |  0.0432 μs |  19,192 B |     896 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     9.805 μs |  0.1187 μs |  0.1110 μs |   1,289 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    53.406 μs |  0.1247 μs |  0.1105 μs |  22,969 B |    3712 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     9.017 μs |  0.1252 μs |  0.1171 μs |   1,285 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    56.751 μs |  0.1663 μs |  0.1555 μs |  19,213 B |    2688 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    77.061 μs |  0.7588 μs |  0.7098 μs |   1,289 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   400.500 μs |  1.5196 μs |  1.1864 μs |  22,924 B |   25216 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    70.560 μs |  0.9948 μs |  0.9306 μs |   1,283 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   426.081 μs |  0.9988 μs |  0.9343 μs |  19,148 B |   17024 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,242.094 μs | 15.1180 μs | 14.1414 μs |   1,289 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,422.374 μs | 18.4801 μs | 17.2863 μs |  22,788 B |  393895 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,125.441 μs | 12.0644 μs | 11.2850 μs |   1,283 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,810.184 μs | 20.6648 μs | 19.3298 μs |  19,038 B |  262810 B |