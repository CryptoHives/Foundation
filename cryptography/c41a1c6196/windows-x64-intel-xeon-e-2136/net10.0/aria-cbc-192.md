| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     4.425 μs |  0.0322 μs |  0.0302 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     5.631 μs |  0.0150 μs |  0.0133 μs |   2,927 B |    1312 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     4.487 μs |  0.0156 μs |  0.0130 μs |   1,307 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     5.302 μs |  0.0107 μs |  0.0094 μs |   2,925 B |    1312 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    31.123 μs |  0.1034 μs |  0.0807 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    33.608 μs |  0.1183 μs |  0.1107 μs |   2,927 B |    3552 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    31.686 μs |  0.0597 μs |  0.0499 μs |   1,307 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    32.146 μs |  0.0585 μs |  0.0488 μs |   2,929 B |    3552 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   246.145 μs |  1.7791 μs |  1.6642 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   254.149 μs |  0.4462 μs |  0.4174 μs |   2,929 B |   21472 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   250.682 μs |  1.5736 μs |  1.4719 μs |   1,305 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   255.192 μs |  0.3344 μs |  0.2964 μs |   2,929 B |   21472 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 3,912.027 μs | 19.1076 μs | 15.9557 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 4,038.939 μs |  8.3988 μs |  7.8563 μs |   2,927 B |  328672 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 3,998.102 μs | 32.0326 μs | 29.9633 μs |   1,305 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 4,059.358 μs | 19.2017 μs | 17.9612 μs |   2,927 B |  328672 B |