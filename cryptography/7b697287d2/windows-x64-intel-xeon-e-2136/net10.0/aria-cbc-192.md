| Description                                 | TestDataSize | Mean         | Error      | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     4.400 μs |  0.0051 μs | 0.0047 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     5.638 μs |  0.0173 μs | 0.0161 μs |   2,927 B |    1312 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     4.468 μs |  0.0060 μs | 0.0057 μs |   1,313 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     5.273 μs |  0.0155 μs | 0.0137 μs |   2,927 B |    1312 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    31.025 μs |  0.0612 μs | 0.0572 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    33.480 μs |  0.0656 μs | 0.0614 μs |   2,927 B |    3552 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    31.606 μs |  0.0210 μs | 0.0164 μs |   1,307 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    33.157 μs |  0.0493 μs | 0.0461 μs |   2,929 B |    3552 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   244.000 μs |  0.3621 μs | 0.3024 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   254.428 μs |  0.3289 μs | 0.2916 μs |   2,929 B |   21472 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   248.645 μs |  0.3010 μs | 0.2816 μs |   1,305 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   255.776 μs |  0.6142 μs | 0.5745 μs |   2,929 B |   21472 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 3,910.760 μs |  3.4901 μs | 2.9144 μs |   1,311 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 4,088.704 μs | 10.4843 μs | 9.8071 μs |   2,927 B |  328672 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 3,969.170 μs |  5.4038 μs | 5.0548 μs |   1,305 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 4,088.215 μs | 10.4017 μs | 9.7297 μs |   2,927 B |  328672 B |