| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.573 μs | 0.0061 μs | 0.0054 μs |  10,522 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     1.800 μs | 0.0067 μs | 0.0059 μs |  25,714 B |     848 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.639 μs | 0.0040 μs | 0.0033 μs |  10,332 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     1.815 μs | 0.0074 μs | 0.0062 μs |  24,934 B |     720 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    11.767 μs | 0.0139 μs | 0.0116 μs |  10,332 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    12.528 μs | 0.0258 μs | 0.0241 μs |  25,566 B |    3536 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    12.284 μs | 0.0122 μs | 0.0102 μs |  10,522 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    12.662 μs | 0.0149 μs | 0.0132 μs |  18,612 B |    2512 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    93.553 μs | 0.3600 μs | 0.3006 μs |  10,332 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |    99.004 μs | 0.2369 μs | 0.2216 μs |  16,596 B |   25040 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    97.720 μs | 0.0429 μs | 0.0335 μs |  10,332 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |    99.402 μs | 0.0916 μs | 0.0812 μs |  15,979 B |   16848 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,494.176 μs | 2.9415 μs | 2.7515 μs |  10,332 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 1,673.960 μs | 6.8467 μs | 6.4044 μs |  16,580 B |  393839 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,555.614 μs | 0.9625 μs | 0.8037 μs |  10,332 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 1,660.292 μs | 1.8091 μs | 1.5107 μs |  15,961 B |  262714 B |