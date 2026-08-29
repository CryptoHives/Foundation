| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.090 μs | 0.0007 μs | 0.0006 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.504 μs | 0.0013 μs | 0.0012 μs |    1312 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.078 μs | 0.0016 μs | 0.0014 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.424 μs | 0.0013 μs | 0.0012 μs |    1312 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.646 μs | 0.0064 μs | 0.0060 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    15.478 μs | 0.0695 μs | 0.0580 μs |    3552 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.678 μs | 0.0028 μs | 0.0023 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    15.417 μs | 0.3058 μs | 0.3522 μs |    3552 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.203 μs | 0.0324 μs | 0.0303 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   120.345 μs | 0.9641 μs | 0.8546 μs |   21472 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.618 μs | 0.0240 μs | 0.0201 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   115.599 μs | 0.0497 μs | 0.0415 μs |   21472 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   964.548 μs | 0.6461 μs | 0.6043 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,890.379 μs | 0.7388 μs | 0.6169 μs |  328672 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   966.988 μs | 0.2935 μs | 0.2602 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,854.257 μs | 0.3604 μs | 0.3371 μs |  328672 B |