| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.698 μs | 0.0045 μs | 0.0040 μs |   1,289 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.815 μs | 0.0083 μs | 0.0077 μs |   2,913 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.695 μs | 0.0047 μs | 0.0042 μs |   1,291 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.713 μs | 0.0105 μs | 0.0093 μs |   2,909 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    12.230 μs | 0.0302 μs | 0.0268 μs |   1,289 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    17.592 μs | 0.0653 μs | 0.0611 μs |   2,909 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    12.125 μs | 0.0320 μs | 0.0299 μs |   1,285 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    17.623 μs | 0.0320 μs | 0.0284 μs |   2,897 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    95.590 μs | 0.2241 μs | 0.1749 μs |   1,289 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   135.879 μs | 0.2254 μs | 0.1998 μs |   2,911 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    95.629 μs | 0.2510 μs | 0.2225 μs |   1,283 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   137.319 μs | 0.1662 μs | 0.1388 μs |   2,911 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,526.872 μs | 6.1467 μs | 5.7496 μs |   1,289 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,165.230 μs | 6.3668 μs | 5.6440 μs |   2,911 B |  328568 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,523.510 μs | 3.3520 μs | 2.7990 μs |   1,283 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,191.690 μs | 6.6103 μs | 5.8599 μs |   2,909 B |  328568 B |