| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.345 μs | 0.0013 μs | 0.0012 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     2.362 μs | 0.0054 μs | 0.0045 μs |   2,935 B |     592 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.624 μs | 0.0016 μs | 0.0015 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     2.181 μs | 0.0146 μs | 0.0136 μs |   2,933 B |     592 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     9.439 μs | 0.0111 μs | 0.0104 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    15.475 μs | 0.0184 μs | 0.0154 μs |   2,933 B |    2832 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |    11.483 μs | 0.0139 μs | 0.0116 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    14.958 μs | 0.0366 μs | 0.0342 μs |   2,931 B |    2832 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    73.232 μs | 0.0397 μs | 0.0352 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |   118.956 μs | 0.2345 μs | 0.2079 μs |   2,933 B |   20752 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    89.893 μs | 0.0291 μs | 0.0243 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |   110.560 μs | 0.2656 μs | 0.2484 μs |   2,935 B |   20752 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,171.630 μs | 1.5193 μs | 1.4212 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,908.612 μs | 3.6643 μs | 3.4276 μs |   2,935 B |  327952 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,438.733 μs | 2.3909 μs | 2.2365 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,882.663 μs | 2.7809 μs | 2.3222 μs |   2,935 B |  327952 B |