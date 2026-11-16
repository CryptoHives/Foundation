| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.960 μs | 0.0117 μs | 0.0109 μs |   1,289 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     3.248 μs | 0.0119 μs | 0.0106 μs |   2,905 B |    1312 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.955 μs | 0.0123 μs | 0.0103 μs |   1,285 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     3.124 μs | 0.0067 μs | 0.0056 μs |   2,889 B |    1312 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    13.964 μs | 0.0277 μs | 0.0246 μs |   1,289 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    20.380 μs | 0.1010 μs | 0.0843 μs |   2,905 B |    3552 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    13.956 μs | 0.0317 μs | 0.0281 μs |   1,285 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    20.632 μs | 0.0598 μs | 0.0530 μs |   2,905 B |    3552 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   110.100 μs | 0.2852 μs | 0.2528 μs |   1,289 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   157.739 μs | 0.6119 μs | 0.5424 μs |   2,903 B |   21472 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   110.197 μs | 0.1723 μs | 0.1439 μs |   1,283 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   159.750 μs | 0.4376 μs | 0.4094 μs |   2,905 B |   21472 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,756.911 μs | 5.2006 μs | 4.6102 μs |   1,289 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,507.445 μs | 7.1212 μs | 6.3127 μs |   2,903 B |  328672 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,754.218 μs | 5.6044 μs | 4.9681 μs |   1,283 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,540.877 μs | 6.2156 μs | 5.5099 μs |   2,903 B |  328672 B |