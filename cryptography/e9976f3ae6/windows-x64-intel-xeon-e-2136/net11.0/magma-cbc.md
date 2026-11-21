| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     2.396 μs | 0.0019 μs | 0.0018 μs |  10,551 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     2.790 μs | 0.0015 μs | 0.0014 μs |  19,235 B |     848 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     2.607 μs | 0.0020 μs | 0.0019 μs |   4,026 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     2.802 μs | 0.0010 μs | 0.0009 μs |  24,972 B |     720 B |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    17.850 μs | 0.0132 μs | 0.0123 μs |  10,361 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    18.458 μs | 0.0155 μs | 0.0145 μs |  25,592 B |    3536 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    18.692 μs | 0.0084 μs | 0.0074 μs |  18,654 B |    2512 B |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    19.399 μs | 0.0127 μs | 0.0113 μs |  10,361 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |   144.506 μs | 0.1489 μs | 0.1393 μs |  16,635 B |   25040 B |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |   144.919 μs | 0.1523 μs | 0.1424 μs |   4,026 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |   146.237 μs | 0.0690 μs | 0.0612 μs |  16,021 B |   16848 B |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |   153.703 μs | 0.0525 μs | 0.0491 μs |   4,026 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 2,262.787 μs | 0.8063 μs | 0.7148 μs |  10,312 B |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 2,493.709 μs | 2.2755 μs | 2.1285 μs |  16,626 B |  393837 B |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 2,456.839 μs | 1.7651 μs | 1.5647 μs |   4,026 B |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 2,478.409 μs | 1.1812 μs | 1.0471 μs |  16,001 B |  262714 B |