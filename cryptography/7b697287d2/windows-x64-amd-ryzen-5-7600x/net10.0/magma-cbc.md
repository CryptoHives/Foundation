| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.596 μs | 0.0010 μs | 0.0008 μs |   1,289 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     1.782 μs | 0.0020 μs | 0.0019 μs |  17,827 B |     848 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.658 μs | 0.0011 μs | 0.0010 μs |   1,291 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     1.790 μs | 0.0027 μs | 0.0022 μs |  16,236 B |     720 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    12.020 μs | 0.0069 μs | 0.0064 μs |   1,289 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    12.427 μs | 0.0119 μs | 0.0111 μs |  17,837 B |    3536 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    12.461 μs | 0.0092 μs | 0.0086 μs |   1,283 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    12.640 μs | 0.0130 μs | 0.0121 μs |  16,238 B |    2512 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    95.187 μs | 0.0837 μs | 0.0742 μs |   1,283 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |    97.782 μs | 0.1099 μs | 0.1028 μs |  17,676 B |   25040 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    98.847 μs | 0.0747 μs | 0.0699 μs |   1,283 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |    99.220 μs | 0.0910 μs | 0.0760 μs |  16,213 B |   16848 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,548.804 μs | 1.2880 μs | 1.2048 μs |   1,289 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 1,640.850 μs | 1.5954 μs | 1.4143 μs |  20,479 B |  393721 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,579.633 μs | 0.4708 μs | 0.4173 μs |   1,283 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 1,640.964 μs | 0.9148 μs | 0.8109 μs |  18,460 B |  262636 B |