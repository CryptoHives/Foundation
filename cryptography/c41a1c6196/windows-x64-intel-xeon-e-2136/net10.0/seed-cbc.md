| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     2.203 μs | 0.0108 μs | 0.0101 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     2.385 μs | 0.0057 μs | 0.0051 μs |   2,935 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     2.226 μs | 0.0078 μs | 0.0069 μs |   1,313 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     2.336 μs | 0.0038 μs | 0.0033 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    15.198 μs | 0.0627 μs | 0.0587 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    15.722 μs | 0.1074 μs | 0.1005 μs |   2,935 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    15.395 μs | 0.0298 μs | 0.0279 μs |   1,307 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    15.471 μs | 0.0579 μs | 0.0541 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |   118.968 μs | 0.1844 μs | 0.1635 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |   123.216 μs | 0.8428 μs | 0.7883 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |   120.464 μs | 0.2022 μs | 0.1892 μs |   1,305 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |   120.760 μs | 0.1382 μs | 0.1225 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,899.610 μs | 4.2688 μs | 3.7842 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,942.313 μs | 3.8630 μs | 3.2258 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,923.289 μs | 0.7891 μs | 0.7382 μs |   1,305 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,930.527 μs | 8.0494 μs | 7.5294 μs |   2,933 B |     152 B |