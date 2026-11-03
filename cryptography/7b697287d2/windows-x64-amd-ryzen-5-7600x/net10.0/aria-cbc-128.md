| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.704 μs | 0.0040 μs | 0.0036 μs |   1,289 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.840 μs | 0.0081 μs | 0.0076 μs |   2,913 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.696 μs | 0.0064 μs | 0.0059 μs |   1,285 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.714 μs | 0.0092 μs | 0.0086 μs |   2,909 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    12.188 μs | 0.0448 μs | 0.0419 μs |   1,289 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    17.644 μs | 0.0728 μs | 0.0646 μs |   2,909 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    12.097 μs | 0.0307 μs | 0.0272 μs |   1,285 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    17.683 μs | 0.0507 μs | 0.0474 μs |   2,909 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    95.814 μs | 0.3162 μs | 0.2640 μs |   1,289 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   137.310 μs | 0.3450 μs | 0.3059 μs |   2,911 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    95.247 μs | 0.3505 μs | 0.3107 μs |   1,283 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   137.636 μs | 0.3761 μs | 0.3518 μs |   2,911 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,534.488 μs | 8.5189 μs | 7.5518 μs |   1,289 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,169.067 μs | 4.5738 μs | 4.0546 μs |   2,911 B |  328568 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,525.725 μs | 3.1384 μs | 2.9356 μs |   1,283 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,199.367 μs | 8.7227 μs | 8.1592 μs |   2,909 B |  328568 B |