| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     4.469 μs | 0.0084 μs | 0.0079 μs |   1,402 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     6.205 μs | 0.0108 μs | 0.0101 μs |   2,914 B |    1784 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     2.814 μs | 0.0067 μs | 0.0063 μs |   1,404 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     3.795 μs | 0.0043 μs | 0.0034 μs |   2,912 B |    1784 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    29.474 μs | 0.0384 μs | 0.0321 μs |   1,402 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    35.310 μs | 0.1174 μs | 0.1098 μs |   2,914 B |    1784 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    18.430 μs | 0.0464 μs | 0.0434 μs |   1,404 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    19.921 μs | 0.0260 μs | 0.0243 μs |   2,910 B |    1784 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   227.958 μs | 0.3421 μs | 0.3032 μs |   1,402 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   267.702 μs | 0.5696 μs | 0.5050 μs |   2,912 B |    1784 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   143.141 μs | 0.2707 μs | 0.2532 μs |   1,393 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   150.604 μs | 0.2489 μs | 0.2328 μs |   2,912 B |    1784 B |
|                                               |              |              |           |           |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 3,630.305 μs | 4.7315 μs | 4.1944 μs |   1,402 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 4,249.412 μs | 6.9786 μs | 6.1863 μs |   2,910 B |    1784 B |
|                                               |              |              |           |           |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,276.995 μs | 4.5328 μs | 4.2400 μs |   1,393 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 2,346.690 μs | 7.1175 μs | 6.6577 μs |   2,912 B |    1784 B |