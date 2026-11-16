| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     2.485 μs | 0.0073 μs | 0.0068 μs |   1,311 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     2.758 μs | 0.0034 μs | 0.0030 μs |  17,852 B |     848 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     2.605 μs | 0.0038 μs | 0.0036 μs |   1,307 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     2.787 μs | 0.0017 μs | 0.0014 μs |  16,269 B |     720 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    18.310 μs | 0.0556 μs | 0.0521 μs |   1,311 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    18.430 μs | 0.0195 μs | 0.0152 μs |  17,862 B |    3536 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    18.765 μs | 0.0087 μs | 0.0068 μs |  16,273 B |    2512 B |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    19.068 μs | 0.0271 μs | 0.0254 μs |   1,305 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |   143.675 μs | 0.1098 μs | 0.0917 μs |  16,978 B |   25040 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |   145.015 μs | 0.4442 μs | 0.4155 μs |   1,311 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |   147.001 μs | 0.1394 μs | 0.1304 μs |  16,244 B |   16848 B |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |   150.734 μs | 0.2634 μs | 0.2464 μs |   1,305 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 2,319.251 μs | 6.2677 μs | 5.8628 μs |   1,311 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 2,461.381 μs | 1.7841 μs | 1.6688 μs |  20,515 B |  393721 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 2,408.588 μs | 4.5435 μs | 4.2500 μs |   1,305 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 2,454.283 μs | 6.3782 μs | 5.9661 μs |  18,492 B |  262636 B |