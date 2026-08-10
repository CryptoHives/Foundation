| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.424 μs |  0.0065 μs |  0.0058 μs |    1288 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     2.426 μs |  0.0089 μs |  0.0084 μs |         - |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.334 μs |  0.0100 μs |  0.0094 μs |    1288 B |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     2.438 μs |  0.0058 μs |  0.0052 μs |         - |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.032 μs |  0.0367 μs |  0.0325 μs |    3528 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    17.548 μs |  0.0907 μs |  0.0849 μs |         - |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.108 μs |  0.0511 μs |  0.0478 μs |    3528 B |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    17.744 μs |  0.0466 μs |  0.0436 μs |         - |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   116.269 μs |  0.3350 μs |  0.3133 μs |   21448 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   137.312 μs |  0.3094 μs |  0.2894 μs |         - |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   126.286 μs |  1.4071 μs |  1.3162 μs |   21448 B |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   138.259 μs |  0.8980 μs |  0.8400 μs |         - |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,845.168 μs |  3.0399 μs |  2.8435 μs |  328648 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 2,197.193 μs |  6.3168 μs |  5.9087 μs |         - |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,869.519 μs |  6.8654 μs |  5.7330 μs |  328648 B |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 2,206.402 μs | 12.2004 μs | 11.4123 μs |         - |