| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.227 μs | 0.0038 μs | 0.0035 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.813 μs | 0.0271 μs | 0.0227 μs |    1416 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.229 μs | 0.0047 μs | 0.0044 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.704 μs | 0.0107 μs | 0.0100 μs |    1416 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.744 μs | 0.0166 μs | 0.0148 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    17.523 μs | 0.0822 μs | 0.0729 μs |    3656 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.765 μs | 0.0236 μs | 0.0221 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    17.036 μs | 0.0444 μs | 0.0416 μs |    3656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.900 μs | 0.2511 μs | 0.2097 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   134.057 μs | 0.5114 μs | 0.4783 μs |   21576 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    69.142 μs | 0.3241 μs | 0.2706 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   131.919 μs | 0.4885 μs | 0.3814 μs |   21576 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,099.873 μs | 3.8615 μs | 3.6121 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,136.854 μs | 4.6798 μs | 4.3775 μs |  328776 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,105.023 μs | 3.2453 μs | 3.0357 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,090.664 μs | 6.8819 μs | 6.4374 μs |  328776 B |