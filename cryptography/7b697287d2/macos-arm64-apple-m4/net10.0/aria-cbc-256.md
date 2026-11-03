| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.228 μs | 0.0006 μs | 0.0006 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.720 μs | 0.0081 μs | 0.0076 μs |    1416 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.221 μs | 0.0005 μs | 0.0004 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.652 μs | 0.0079 μs | 0.0074 μs |    1416 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.665 μs | 0.0044 μs | 0.0041 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    16.740 μs | 0.0724 μs | 0.0677 μs |    3656 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.712 μs | 0.0045 μs | 0.0042 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    16.582 μs | 0.0541 μs | 0.0506 μs |    3656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.782 μs | 0.0439 μs | 0.0411 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   130.266 μs | 0.4012 μs | 0.3753 μs |   21576 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    69.093 μs | 0.0457 μs | 0.0428 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   128.645 μs | 0.3766 μs | 0.3523 μs |   21576 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,096.870 μs | 0.6041 μs | 0.5651 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,070.171 μs | 7.3532 μs | 6.8781 μs |  328776 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,095.535 μs | 0.5332 μs | 0.4727 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,044.746 μs | 9.6143 μs | 8.9932 μs |  328776 B |