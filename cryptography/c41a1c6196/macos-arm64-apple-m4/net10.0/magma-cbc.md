| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.364 μs | 0.0054 μs | 0.0050 μs |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     1.468 μs | 0.0038 μs | 0.0035 μs |     848 B |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.614 μs | 0.0035 μs | 0.0033 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     1.750 μs | 0.0051 μs | 0.0048 μs |     720 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    10.214 μs | 0.0120 μs | 0.0112 μs |    3536 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    10.270 μs | 0.0466 μs | 0.0436 μs |         - |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    12.269 μs | 0.0193 μs | 0.0161 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    12.614 μs | 0.0327 μs | 0.0306 μs |    2512 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |    80.706 μs | 0.2300 μs | 0.2151 μs |   25040 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    81.267 μs | 0.1790 μs | 0.1674 μs |         - |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    97.324 μs | 0.3068 μs | 0.2720 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |   100.602 μs | 0.2699 μs | 0.2524 μs |   16848 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 1,285.758 μs | 1.8326 μs | 1.7142 μs |  393763 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,301.817 μs | 5.1980 μs | 4.8622 μs |         - |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,558.207 μs | 4.8269 μs | 4.5151 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 1,601.927 μs | 1.5287 μs | 1.4299 μs |  262663 B |