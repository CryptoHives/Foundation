| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.726 μs |  0.0202 μs |  0.0189 μs |  10,737 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.676 μs |  0.0223 μs |  0.0208 μs |  13,883 B |    1208 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.695 μs |  0.0064 μs |  0.0057 μs |  10,332 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.484 μs |  0.0067 μs |  0.0059 μs |   7,734 B |    1208 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    12.395 μs |  0.1145 μs |  0.1071 μs |  10,522 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    16.542 μs |  0.1707 μs |  0.1597 μs |  13,907 B |    3448 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    12.087 μs |  0.0404 μs |  0.0358 μs |   3,997 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    16.275 μs |  0.1188 μs |  0.0992 μs |  13,883 B |    3448 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   103.446 μs |  1.1069 μs |  1.0354 μs |  10,332 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   127.030 μs |  1.0136 μs |  0.9481 μs |   7,729 B |   21368 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    95.087 μs |  0.2163 μs |  0.1917 μs |  10,332 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   125.285 μs |  0.2569 μs |  0.2277 μs |  13,883 B |   21368 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,549.979 μs | 19.5171 μs | 18.2563 μs |   3,997 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,005.117 μs |  4.4401 μs |  3.9361 μs |   7,740 B |  328568 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,520.292 μs |  3.9782 μs |  3.1059 μs |  10,522 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,043.404 μs | 24.2260 μs | 22.6610 μs |  13,880 B |  328568 B |