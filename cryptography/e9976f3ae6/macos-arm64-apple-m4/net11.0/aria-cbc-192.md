| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.085 μs | 0.0014 μs | 0.0013 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.261 μs | 0.0081 μs | 0.0076 μs |    1312 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.084 μs | 0.0010 μs | 0.0009 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.195 μs | 0.0091 μs | 0.0085 μs |    1312 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.708 μs | 0.0063 μs | 0.0056 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    13.327 μs | 0.0267 μs | 0.0249 μs |    3552 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.705 μs | 0.0133 μs | 0.0125 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    14.242 μs | 0.0373 μs | 0.0349 μs |    3552 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.671 μs | 0.0639 μs | 0.0598 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   102.832 μs | 0.2862 μs | 0.2677 μs |   21472 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.689 μs | 0.0868 μs | 0.0812 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   111.595 μs | 0.2609 μs | 0.2440 μs |   21472 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   971.283 μs | 1.2413 μs | 1.1611 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,638.870 μs | 2.1942 μs | 1.8323 μs |  328672 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   970.083 μs | 0.8678 μs | 0.8117 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,765.105 μs | 2.8994 μs | 2.4211 μs |  328672 B |