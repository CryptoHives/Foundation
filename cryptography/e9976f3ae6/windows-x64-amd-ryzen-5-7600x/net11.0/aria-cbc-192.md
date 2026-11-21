| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.949 μs |  0.0074 μs |  0.0065 μs |  10,522 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     3.045 μs |  0.0327 μs |  0.0290 μs |  14,100 B |    1312 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.988 μs |  0.0046 μs |  0.0039 μs |  10,332 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.862 μs |  0.0049 μs |  0.0043 μs |  13,885 B |    1312 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    14.157 μs |  0.1201 μs |  0.1003 μs |   3,997 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    19.327 μs |  0.1916 μs |  0.1792 μs |  13,695 B |    3552 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    13.959 μs |  0.0900 μs |  0.0798 μs |  10,522 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    18.762 μs |  0.0278 μs |  0.0217 μs |  13,699 B |    3552 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   111.753 μs |  1.3274 μs |  1.2416 μs |  10,533 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   147.832 μs |  1.3119 μs |  1.2272 μs |  13,699 B |   21472 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   109.951 μs |  0.1723 μs |  0.1439 μs |   3,997 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   145.426 μs |  0.3308 μs |  0.2932 μs |  13,880 B |   21472 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,780.038 μs | 17.9766 μs | 16.8153 μs |   3,997 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,350.025 μs | 13.7401 μs | 12.8525 μs |  13,905 B |  328672 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,753.264 μs |  8.2838 μs |  7.7487 μs |  10,473 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,318.431 μs |  5.3727 μs |  5.0256 μs |  13,690 B |  328672 B |