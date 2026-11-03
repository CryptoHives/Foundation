| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.338 μs | 0.0048 μs | 0.0045 μs |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     1.434 μs | 0.0009 μs | 0.0009 μs |     848 B |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.583 μs | 0.0041 μs | 0.0039 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     1.720 μs | 0.0005 μs | 0.0005 μs |     720 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    10.028 μs | 0.0035 μs | 0.0032 μs |    3536 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    10.057 μs | 0.0354 μs | 0.0331 μs |         - |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    12.057 μs | 0.0355 μs | 0.0332 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    12.445 μs | 0.0028 μs | 0.0026 μs |    2512 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |    78.615 μs | 0.0329 μs | 0.0291 μs |   25040 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    79.754 μs | 0.2740 μs | 0.2563 μs |         - |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    95.700 μs | 0.3419 μs | 0.3198 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |    98.268 μs | 0.0488 μs | 0.0408 μs |   16848 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 1,269.014 μs | 1.0004 μs | 0.9358 μs |  393763 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,277.275 μs | 4.6946 μs | 4.3913 μs |         - |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,529.992 μs | 5.9158 μs | 5.5336 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 1,584.665 μs | 0.9717 μs | 0.9089 μs |  262663 B |