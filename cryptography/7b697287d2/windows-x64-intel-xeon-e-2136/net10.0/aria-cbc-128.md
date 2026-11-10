| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     3.808 μs | 0.0049 μs | 0.0046 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     4.938 μs | 0.0088 μs | 0.0082 μs |   2,935 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     3.882 μs | 0.0055 μs | 0.0052 μs |   1,307 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     4.660 μs | 0.0111 μs | 0.0092 μs |   2,935 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    26.748 μs | 0.0251 μs | 0.0223 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    29.011 μs | 0.0764 μs | 0.0715 μs |   2,935 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    27.332 μs | 0.0235 μs | 0.0220 μs |   1,307 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    28.914 μs | 0.0467 μs | 0.0437 μs |   2,933 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   210.434 μs | 0.3299 μs | 0.3086 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   224.068 μs | 0.4322 μs | 0.4043 μs |   2,933 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   214.916 μs | 0.2903 μs | 0.2715 μs |   1,305 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   221.041 μs | 0.3386 μs | 0.3167 μs |   2,933 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 3,360.929 μs | 5.5789 μs | 4.9456 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 3,563.399 μs | 9.1968 μs | 7.6797 μs |   2,933 B |  328568 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 3,428.506 μs | 1.7388 μs | 1.5414 μs |   1,311 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 3,517.470 μs | 5.2675 μs | 4.9272 μs |   2,933 B |  328568 B |