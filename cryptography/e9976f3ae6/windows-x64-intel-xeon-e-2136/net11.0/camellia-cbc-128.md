| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     1.038 μs | 0.0016 μs | 0.0014 μs |  10,551 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     1.717 μs | 0.0039 μs | 0.0037 μs |   7,776 B |     576 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     1.290 μs | 0.0012 μs | 0.0011 μs |  10,361 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     1.644 μs | 0.0037 μs | 0.0035 μs |   7,776 B |     576 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |     7.202 μs | 0.0044 μs | 0.0042 μs |   4,026 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |    11.147 μs | 0.0273 μs | 0.0242 μs |  14,140 B |    2816 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |     9.008 μs | 0.0120 μs | 0.0100 μs |  10,551 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |    10.345 μs | 0.0183 μs | 0.0171 μs |   7,776 B |    2816 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    55.466 μs | 0.0218 μs | 0.0204 μs |  10,361 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    84.416 μs | 0.4510 μs | 0.3998 μs |   7,776 B |   20736 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    69.915 μs | 0.0098 μs | 0.0087 μs |   4,026 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    85.418 μs | 0.0660 μs | 0.0585 μs |  13,735 B |   20736 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        |   894.097 μs | 0.5331 μs | 0.4726 μs |  10,551 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 1,385.118 μs | 6.3285 μs | 5.6101 μs |  13,927 B |  327936 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 1,117.539 μs | 0.3827 μs | 0.3580 μs |  10,361 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 1,285.081 μs | 1.4631 μs | 1.2970 μs |  13,735 B |  327936 B |