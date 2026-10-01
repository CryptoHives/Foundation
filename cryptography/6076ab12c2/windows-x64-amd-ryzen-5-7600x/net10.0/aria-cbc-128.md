| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.710 μs |  0.0248 μs |  0.0232 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.855 μs |  0.0325 μs |  0.0304 μs |    1208 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.803 μs |  0.0173 μs |  0.0161 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.733 μs |  0.0292 μs |  0.0273 μs |    1208 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    12.192 μs |  0.0991 μs |  0.0927 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    17.750 μs |  0.2028 μs |  0.1897 μs |    3448 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    12.178 μs |  0.1804 μs |  0.1687 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    17.855 μs |  0.0979 μs |  0.0817 μs |    3448 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    95.817 μs |  1.3631 μs |  1.2751 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   137.414 μs |  1.6593 μs |  1.5521 μs |   21368 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    96.104 μs |  1.2979 μs |  1.2141 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   138.630 μs |  1.7783 μs |  1.6634 μs |   21368 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,535.383 μs | 20.7592 μs | 19.4182 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,178.647 μs | 20.1814 μs | 18.8777 μs |  328568 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,536.344 μs | 24.3730 μs | 22.7985 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,212.922 μs |  8.8137 μs |  8.2444 μs |  328568 B |