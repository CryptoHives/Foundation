| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.464 μs |  0.0084 μs |  0.0079 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.448 μs |  0.0246 μs |  0.0230 μs |    1208 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.493 μs |  0.0079 μs |  0.0074 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.357 μs |  0.0149 μs |  0.0139 μs |    1208 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.471 μs |  0.0461 μs |  0.0431 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.232 μs |  0.0953 μs |  0.0892 μs |    3448 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.476 μs |  0.0748 μs |  0.0700 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.288 μs |  0.0876 μs |  0.0820 μs |    3448 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    82.396 μs |  0.7672 μs |  0.7176 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   120.376 μs |  0.5547 μs |  0.5189 μs |   21368 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    82.460 μs |  0.4957 μs |  0.4394 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   119.151 μs |  0.5221 μs |  0.4883 μs |   21368 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,317.665 μs |  7.9385 μs |  7.4257 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,886.688 μs |  6.9576 μs |  6.5082 μs |  328568 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,317.648 μs | 12.3831 μs | 11.5831 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,901.632 μs | 11.2616 μs | 10.5341 μs |  328568 B |