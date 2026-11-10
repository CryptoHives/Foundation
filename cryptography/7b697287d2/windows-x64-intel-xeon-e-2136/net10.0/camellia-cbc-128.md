| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     1.016 μs | 0.0017 μs | 0.0015 μs |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     1.853 μs | 0.0046 μs | 0.0041 μs |   2,935 B |     576 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     1.281 μs | 0.0009 μs | 0.0008 μs |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     1.758 μs | 0.0043 μs | 0.0040 μs |   2,923 B |     576 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |     7.135 μs | 0.0072 μs | 0.0064 μs |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |    12.545 μs | 0.0179 μs | 0.0167 μs |   2,937 B |    2816 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |     9.011 μs | 0.0099 μs | 0.0083 μs |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |    11.851 μs | 0.0236 μs | 0.0209 μs |   2,935 B |    2816 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    55.519 μs | 0.0375 μs | 0.0313 μs |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    97.546 μs | 0.1650 μs | 0.1543 μs |   2,935 B |   20736 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    70.393 μs | 0.0776 μs | 0.0688 μs |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    89.035 μs | 0.2969 μs | 0.2777 μs |   2,935 B |   20736 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        |   891.843 μs | 0.6255 μs | 0.5545 μs |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 1,499.546 μs | 3.4805 μs | 3.2557 μs |   2,933 B |  327936 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 1,117.103 μs | 1.0359 μs | 0.9689 μs |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 1,426.909 μs | 2.2199 μs | 1.9679 μs |   2,935 B |  327936 B |