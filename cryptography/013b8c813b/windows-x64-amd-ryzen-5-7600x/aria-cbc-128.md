| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Median       | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.480 μs | 0.0050 μs | 0.0044 μs |     1.480 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.587 μs | 0.0038 μs | 0.0034 μs |     2.587 μs |    1288 B |
|                                             |              |              |           |           |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.503 μs | 0.0158 μs | 0.0280 μs |     1.489 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.395 μs | 0.0049 μs | 0.0046 μs |     2.396 μs |    1288 B |
|                                             |              |              |           |           |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.607 μs | 0.0172 μs | 0.0144 μs |    10.605 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.412 μs | 0.0470 μs | 0.0440 μs |    15.405 μs |    3528 B |
|                                             |              |              |           |           |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.656 μs | 0.0220 μs | 0.0206 μs |    10.656 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.449 μs | 0.0170 μs | 0.0142 μs |    15.447 μs |    3528 B |
|                                             |              |              |           |           |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    83.686 μs | 0.1391 μs | 0.1233 μs |    83.671 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   118.785 μs | 0.1506 μs | 0.1257 μs |   118.777 μs |   21448 B |
|                                             |              |              |           |           |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    83.098 μs | 0.0940 μs | 0.0734 μs |    83.093 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   122.575 μs | 0.3250 μs | 0.2881 μs |   122.520 μs |   21448 B |
|                                             |              |              |           |           |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,335.802 μs | 2.8293 μs | 2.5081 μs | 1,335.501 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,894.525 μs | 1.7955 μs | 1.5917 μs | 1,894.395 μs |  328648 B |
|                                             |              |              |           |           |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,327.938 μs | 2.1681 μs | 2.0281 μs | 1,327.733 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,914.929 μs | 2.1421 μs | 1.7888 μs | 1,915.559 μs |  328648 B |