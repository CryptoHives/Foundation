| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.601 μs | 0.0012 μs | 0.0011 μs |   1,289 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     1.787 μs | 0.0023 μs | 0.0019 μs |  17,827 B |     848 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.665 μs | 0.0030 μs | 0.0028 μs |   1,285 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     1.800 μs | 0.0027 μs | 0.0025 μs |  16,234 B |     720 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    12.031 μs | 0.0104 μs | 0.0092 μs |   1,289 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    12.510 μs | 0.0173 μs | 0.0153 μs |  17,837 B |    3536 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    12.509 μs | 0.0197 μs | 0.0184 μs |   1,283 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    12.701 μs | 0.0152 μs | 0.0143 μs |  16,239 B |    2512 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    95.642 μs | 0.1091 μs | 0.0967 μs |   1,289 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |    98.395 μs | 0.1582 μs | 0.1403 μs |  17,676 B |   25040 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    99.200 μs | 0.0546 μs | 0.0484 μs |   1,283 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |    99.720 μs | 0.1244 μs | 0.1039 μs |  16,213 B |   16848 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,530.898 μs | 1.8912 μs | 1.6765 μs |   1,289 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 1,650.993 μs | 2.4750 μs | 2.1940 μs |  20,479 B |  393721 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,586.570 μs | 1.2503 μs | 1.1084 μs |   1,283 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 1,651.266 μs | 1.9559 μs | 1.7339 μs |  18,460 B |  262636 B |