| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.933 μs |  0.0163 μs |  0.0144 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.226 μs |  0.0176 μs |  0.0156 μs |    1496 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.928 μs |  0.0055 μs |  0.0049 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.099 μs |  0.0167 μs |  0.0140 μs |    1496 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.885 μs |  0.1390 μs |  0.1232 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.315 μs |  0.3263 μs |  0.3052 μs |    3736 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.811 μs |  0.0720 μs |  0.0638 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.260 μs |  0.1431 μs |  0.1339 μs |    3736 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   108.963 μs |  0.6806 μs |  0.6366 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   156.393 μs |  0.9280 μs |  0.8227 μs |   21656 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   108.842 μs |  0.8366 μs |  0.7416 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   157.715 μs |  0.7364 μs |  0.6528 μs |   21656 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,741.652 μs | 10.8927 μs | 10.1890 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,486.743 μs | 24.2572 μs | 18.9384 μs |  328856 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,744.804 μs | 13.7247 μs | 12.8381 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,519.849 μs | 11.3392 μs | 10.6067 μs |  328856 B |