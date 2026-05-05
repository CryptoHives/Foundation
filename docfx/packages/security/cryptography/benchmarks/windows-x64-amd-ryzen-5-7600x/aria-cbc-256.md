| Description                                 | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.851 μs |  0.0078 μs | 0.0066 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.171 μs |  0.0140 μs | 0.0124 μs |    1496 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.855 μs |  0.0073 μs | 0.0065 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.031 μs |  0.0107 μs | 0.0095 μs |    1496 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.305 μs |  0.0489 μs | 0.0433 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    19.823 μs |  0.0688 μs | 0.0644 μs |    3736 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.305 μs |  0.0729 μs | 0.0646 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    19.883 μs |  0.0850 μs | 0.0795 μs |    3736 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   105.022 μs |  0.5500 μs | 0.5145 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   152.947 μs |  0.5263 μs | 0.4666 μs |   21656 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   104.956 μs |  0.6108 μs | 0.4769 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   154.912 μs |  0.5991 μs | 0.5311 μs |   21656 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,676.004 μs |  9.2202 μs | 8.6246 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,438.043 μs | 10.9866 μs | 9.7393 μs |  328856 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,679.356 μs | 10.4183 μs | 9.7453 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,468.656 μs | 10.0598 μs | 8.9178 μs |  328856 B |