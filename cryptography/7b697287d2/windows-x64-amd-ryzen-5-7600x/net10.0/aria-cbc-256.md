| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     2.208 μs | 0.0057 μs | 0.0050 μs |   1,289 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.690 μs | 0.0055 μs | 0.0051 μs |   2,903 B |    1416 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     2.212 μs | 0.0071 μs | 0.0066 μs |   1,285 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.595 μs | 0.0072 μs | 0.0067 μs |   2,901 B |    1416 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    15.858 μs | 0.0978 μs | 0.0915 μs |   1,289 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    23.237 μs | 0.0946 μs | 0.0885 μs |   2,905 B |    3656 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    15.848 μs | 0.0640 μs | 0.0599 μs |   1,285 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    23.242 μs | 0.0448 μs | 0.0419 μs |   2,903 B |    3656 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   125.066 μs | 0.7623 μs | 0.7130 μs |   1,289 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   179.868 μs | 0.5196 μs | 0.4861 μs |   2,905 B |   21576 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   124.226 μs | 0.3537 μs | 0.2954 μs |   1,283 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   181.230 μs | 0.2998 μs | 0.2804 μs |   2,905 B |   21576 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,998.407 μs | 8.4802 μs | 7.9324 μs |   1,289 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,853.170 μs | 5.2369 μs | 4.8986 μs |   2,903 B |  328776 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,988.481 μs | 8.0786 μs | 7.5567 μs |   1,289 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,885.769 μs | 4.8893 μs | 4.5735 μs |   2,903 B |  328776 B |