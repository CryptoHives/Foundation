| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     3.260 μs | 0.0061 μs | 0.0057 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     4.121 μs | 0.0080 μs | 0.0071 μs |   2,927 B |    1312 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     3.307 μs | 0.0052 μs | 0.0043 μs |   1,307 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     3.910 μs | 0.0118 μs | 0.0110 μs |   2,925 B |    1312 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    22.894 μs | 0.0362 μs | 0.0321 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    24.736 μs | 0.0537 μs | 0.0476 μs |   2,927 B |    3552 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    23.368 μs | 0.0892 μs | 0.0745 μs |   1,307 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    24.047 μs | 0.0438 μs | 0.0388 μs |   2,929 B |    3552 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   179.988 μs | 0.2573 μs | 0.2406 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   188.559 μs | 0.3288 μs | 0.3076 μs |   2,929 B |   21472 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   183.539 μs | 0.2287 μs | 0.2139 μs |   1,305 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   187.018 μs | 0.4759 μs | 0.4452 μs |   2,929 B |   21472 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 2,875.275 μs | 7.2201 μs | 6.4005 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 3,019.352 μs | 5.9831 μs | 5.3039 μs |   2,927 B |  328672 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 2,929.932 μs | 6.3869 μs | 5.9743 μs |   1,305 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 3,001.524 μs | 6.4487 μs | 6.0321 μs |   2,927 B |  328672 B |