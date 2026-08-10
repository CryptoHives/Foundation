| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Median       | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|-------------:|----------:|
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.565 μs |  0.0505 μs |  0.0519 μs |     2.572 μs |    1288 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     2.618 μs |  0.0301 μs |  0.0281 μs |     2.615 μs |         - |
|                                             |              |              |            |            |              |           |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.283 μs |  0.0012 μs |  0.0010 μs |     2.284 μs |    1288 B |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     2.424 μs |  0.0472 μs |  0.0441 μs |     2.418 μs |         - |
|                                             |              |              |            |            |              |           |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    16.079 μs |  0.2921 μs |  0.4281 μs |    16.092 μs |    3528 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    19.021 μs |  0.1180 μs |  0.1104 μs |    19.067 μs |         - |
|                                             |              |              |            |            |              |           |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.615 μs |  0.1471 μs |  0.1376 μs |    15.632 μs |    3528 B |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    17.780 μs |  0.1723 μs |  0.1611 μs |    17.867 μs |         - |
|                                             |              |              |            |            |              |           |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   125.003 μs |  2.4931 μs |  4.3665 μs |   122.832 μs |   21448 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   151.731 μs |  1.7939 μs |  1.6780 μs |   151.675 μs |         - |
|                                             |              |              |            |            |              |           |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   118.059 μs |  1.8352 μs |  1.7166 μs |   118.476 μs |   21448 B |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   139.950 μs |  1.2344 μs |  1.0308 μs |   139.971 μs |         - |
|                                             |              |              |            |            |              |           |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,995.736 μs | 39.8199 μs | 94.6361 μs | 1,955.931 μs |  328648 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 2,446.076 μs | 14.0884 μs | 13.1783 μs | 2,445.980 μs |         - |
|                                             |              |              |            |            |              |           |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,980.068 μs | 39.2253 μs | 71.7257 μs | 1,939.091 μs |  328648 B |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 2,352.641 μs | 44.5210 μs | 73.1492 μs | 2,357.940 μs |         - |