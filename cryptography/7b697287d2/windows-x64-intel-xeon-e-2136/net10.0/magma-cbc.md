| Description                              | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.917 μs |  0.0327 μs |  0.0306 μs |   1,311 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     2.118 μs |  0.0386 μs |  0.0361 μs |  17,851 B |     848 B |
|                                          |              |              |            |            |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.990 μs |  0.0357 μs |  0.0334 μs |   1,307 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     2.137 μs |  0.0354 μs |  0.0295 μs |  16,264 B |     720 B |
|                                          |              |              |            |            |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    14.060 μs |  0.1921 μs |  0.1796 μs |  17,862 B |    3536 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    14.092 μs |  0.1961 μs |  0.1834 μs |   1,311 B |         - |
|                                          |              |              |            |            |           |           |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    14.254 μs |  0.2157 μs |  0.2018 μs |  16,263 B |    2512 B |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    14.609 μs |  0.1350 μs |  0.1263 μs |   1,305 B |         - |
|                                          |              |              |            |            |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |   109.535 μs |  1.7975 μs |  1.6814 μs |  16,978 B |   25040 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |   110.187 μs |  1.8666 μs |  1.7460 μs |   1,311 B |         - |
|                                          |              |              |            |            |           |           |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |   111.709 μs |  1.9449 μs |  1.8192 μs |  16,244 B |   16848 B |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |   114.919 μs |  1.6969 μs |  1.5873 μs |   1,305 B |         - |
|                                          |              |              |            |            |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,766.889 μs | 24.3321 μs | 22.7603 μs |   1,311 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 1,889.282 μs | 21.0567 μs | 19.6964 μs |  20,508 B |  393721 B |
|                                          |              |              |            |            |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,838.830 μs | 26.6585 μs | 24.9364 μs |   1,305 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 1,883.468 μs | 29.1184 μs | 27.2373 μs |  18,484 B |  262636 B |