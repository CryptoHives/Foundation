| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.721 μs |  0.0153 μs |  0.0143 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.861 μs |  0.0107 μs |  0.0095 μs |    1312 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.710 μs |  0.0094 μs |  0.0088 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.732 μs |  0.0096 μs |  0.0080 μs |    1312 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    12.309 μs |  0.1321 μs |  0.1103 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    17.948 μs |  0.1016 μs |  0.0901 μs |    3552 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    12.318 μs |  0.0711 μs |  0.0665 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    17.870 μs |  0.0837 μs |  0.0783 μs |    3552 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    96.955 μs |  0.5939 μs |  0.5555 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   137.747 μs |  0.6168 μs |  0.5770 μs |   21472 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    96.587 μs |  0.8539 μs |  0.7130 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   140.600 μs |  2.8059 μs |  2.8814 μs |   21472 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,549.805 μs | 17.2722 μs | 18.4811 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,194.653 μs | 15.7052 μs | 14.6907 μs |  328672 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 1,547.369 μs | 11.5858 μs | 10.8374 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 2,221.125 μs | 13.2717 μs | 12.4144 μs |  328672 B |