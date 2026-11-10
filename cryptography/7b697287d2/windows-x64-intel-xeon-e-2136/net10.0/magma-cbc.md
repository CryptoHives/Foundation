| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     2.574 μs | 0.0041 μs | 0.0038 μs |   1,311 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     2.778 μs | 0.0029 μs | 0.0025 μs |  17,851 B |     848 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     2.613 μs | 0.0011 μs | 0.0011 μs |   1,307 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     2.810 μs | 0.0026 μs | 0.0025 μs |  16,253 B |     720 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    18.389 μs | 0.0279 μs | 0.0233 μs |   1,311 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    18.464 μs | 0.0188 μs | 0.0176 μs |  17,862 B |    3536 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    18.923 μs | 0.0199 μs | 0.0176 μs |  16,269 B |    2512 B |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    19.103 μs | 0.0151 μs | 0.0141 μs |   1,305 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |   143.995 μs | 0.1593 μs | 0.1412 μs |  16,976 B |   25040 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |   144.914 μs | 0.1734 μs | 0.1537 μs |   1,311 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |   147.918 μs | 0.1597 μs | 0.1493 μs |  16,244 B |   16848 B |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |   150.980 μs | 0.1774 μs | 0.1659 μs |   1,305 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 2,334.791 μs | 6.9869 μs | 6.5356 μs |   1,311 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 2,465.394 μs | 1.6974 μs | 1.3252 μs |  20,517 B |  393721 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 2,414.044 μs | 1.7211 μs | 1.6099 μs |   1,305 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 2,457.572 μs | 2.1543 μs | 1.9097 μs |  18,482 B |  262636 B |