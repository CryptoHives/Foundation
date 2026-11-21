| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     3.378 μs | 0.0033 μs | 0.0030 μs |  10,361 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     4.452 μs | 0.0061 μs | 0.0057 μs |  13,735 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     3.383 μs | 0.0073 μs | 0.0065 μs |  10,551 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     4.182 μs | 0.0035 μs | 0.0029 μs |   7,776 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    23.846 μs | 0.0256 μs | 0.0239 μs |  10,551 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    25.809 μs | 0.0331 μs | 0.0293 μs |  13,735 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    24.023 μs | 0.0073 μs | 0.0057 μs |   4,026 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    25.034 μs | 0.0230 μs | 0.0216 μs |  13,925 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   187.758 μs | 0.2817 μs | 0.2635 μs |  10,361 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   191.392 μs | 0.2486 μs | 0.2204 μs |   7,776 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   188.139 μs | 0.2221 μs | 0.1855 μs |   4,026 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   190.713 μs | 0.1324 μs | 0.1174 μs |   7,776 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 2,992.891 μs | 1.9546 μs | 1.7327 μs |  10,361 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 3,093.918 μs | 3.9423 μs | 3.4948 μs |  13,927 B |  328568 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 2,993.205 μs | 3.3464 μs | 2.9665 μs |  10,551 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 3,051.919 μs | 2.6673 μs | 2.4950 μs |   7,778 B |  328568 B |