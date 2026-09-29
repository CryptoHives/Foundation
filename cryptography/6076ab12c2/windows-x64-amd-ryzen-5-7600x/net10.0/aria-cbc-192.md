| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.974 μs |  0.0191 μs |  0.0179 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     3.306 μs |  0.0409 μs |  0.0383 μs |    1312 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.963 μs |  0.0320 μs |  0.0300 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     3.154 μs |  0.0295 μs |  0.0276 μs |    1312 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    14.059 μs |  0.1421 μs |  0.1329 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    20.524 μs |  0.2142 μs |  0.2004 μs |    3552 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    14.073 μs |  0.2079 μs |  0.1945 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    20.596 μs |  0.1443 μs |  0.1205 μs |    3552 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   110.676 μs |  1.2285 μs |  1.1491 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   159.749 μs |  0.9709 μs |  0.8607 μs |   21472 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   111.494 μs |  1.3272 μs |  1.1765 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   161.087 μs |  1.6720 μs |  1.5640 μs |   21472 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,765.678 μs | 22.7849 μs | 21.3130 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,531.419 μs | 26.8576 μs | 25.1226 μs |  328672 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,772.489 μs | 20.1830 μs | 18.8792 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,559.876 μs | 23.3999 μs | 21.8883 μs |  328672 B |