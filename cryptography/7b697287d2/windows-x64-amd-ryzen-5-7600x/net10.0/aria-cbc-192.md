| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.965 μs | 0.0179 μs | 0.0167 μs |   1,289 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     3.278 μs | 0.0084 μs | 0.0079 μs |   2,905 B |    1312 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.957 μs | 0.0094 μs | 0.0083 μs |   1,285 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     3.134 μs | 0.0057 μs | 0.0050 μs |   2,903 B |    1312 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    14.012 μs | 0.0256 μs | 0.0227 μs |   1,289 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    20.457 μs | 0.0630 μs | 0.0558 μs |   2,905 B |    3552 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    14.053 μs | 0.0346 μs | 0.0324 μs |   1,285 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    20.920 μs | 0.0497 μs | 0.0465 μs |   2,893 B |    3552 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   110.076 μs | 0.2242 μs | 0.2097 μs |   1,289 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   157.379 μs | 0.3229 μs | 0.2862 μs |   2,903 B |   21472 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   111.912 μs | 0.2428 μs | 0.2271 μs |   1,283 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   159.762 μs | 0.4608 μs | 0.4311 μs |   2,905 B |   21472 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,754.622 μs | 3.1689 μs | 2.9642 μs |   1,289 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,505.590 μs | 6.0077 μs | 5.6196 μs |   2,903 B |  328672 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,767.735 μs | 3.5790 μs | 3.3478 μs |   1,289 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,559.070 μs | 6.8584 μs | 6.4154 μs |   2,903 B |  328672 B |