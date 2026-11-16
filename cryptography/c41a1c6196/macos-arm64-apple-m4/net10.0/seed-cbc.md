| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.318 μs | 0.0037 μs | 0.0034 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.399 μs | 0.0050 μs | 0.0047 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.364 μs | 0.0056 μs | 0.0050 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.429 μs | 0.0079 μs | 0.0070 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.365 μs | 0.0471 μs | 0.0441 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.582 μs | 0.0541 μs | 0.0506 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.843 μs | 0.0347 μs | 0.0324 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.935 μs | 0.0491 μs | 0.0459 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    73.745 μs | 0.4302 μs | 0.4024 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    74.905 μs | 0.4549 μs | 0.4255 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    77.609 μs | 0.3605 μs | 0.3372 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    78.050 μs | 0.3486 μs | 0.3261 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,174.807 μs | 5.4431 μs | 4.2496 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,196.731 μs | 8.3444 μs | 7.8053 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,242.468 μs | 6.6293 μs | 6.2010 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,244.099 μs | 4.8530 μs | 4.5395 μs |     152 B |