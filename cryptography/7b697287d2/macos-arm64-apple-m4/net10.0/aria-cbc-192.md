| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.084 μs | 0.0004 μs | 0.0003 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.467 μs | 0.0063 μs | 0.0059 μs |    1312 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.077 μs | 0.0003 μs | 0.0003 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.361 μs | 0.0082 μs | 0.0076 μs |    1312 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.651 μs | 0.0063 μs | 0.0059 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    15.145 μs | 0.0365 μs | 0.0342 μs |    3552 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.676 μs | 0.0037 μs | 0.0034 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    14.833 μs | 0.0200 μs | 0.0187 μs |    3552 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.686 μs | 0.0723 μs | 0.0676 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   116.701 μs | 0.3615 μs | 0.3381 μs |   21472 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.421 μs | 0.0189 μs | 0.0168 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   113.837 μs | 0.2626 μs | 0.2328 μs |   21472 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   964.680 μs | 0.6450 μs | 0.5718 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,852.657 μs | 4.9423 μs | 4.6231 μs |  328672 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   965.463 μs | 0.3943 μs | 0.3689 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,814.117 μs | 3.7867 μs | 3.5420 μs |  328672 B |