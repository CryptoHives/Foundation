| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.382 μs | 0.0020 μs | 0.0018 μs |   1,289 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.519 μs | 0.0022 μs | 0.0021 μs |   2,911 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.393 μs | 0.0011 μs | 0.0008 μs |   1,285 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.521 μs | 0.0031 μs | 0.0029 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.828 μs | 0.0206 μs | 0.0193 μs |   1,289 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.287 μs | 0.0163 μs | 0.0152 μs |   2,911 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    10.021 μs | 0.0160 μs | 0.0150 μs |   1,285 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.350 μs | 0.0204 μs | 0.0191 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    77.160 μs | 0.1329 μs | 0.1179 μs |   1,289 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.368 μs | 0.1288 μs | 0.1205 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    77.593 μs | 0.0992 μs | 0.0928 μs |   1,283 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.955 μs | 0.0812 μs | 0.0634 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,233.324 μs | 1.1711 μs | 1.0954 μs |   1,289 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,279.112 μs | 1.0773 μs | 0.9550 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,239.925 μs | 2.1410 μs | 2.0027 μs |   1,283 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,291.237 μs | 1.4674 μs | 1.3008 μs |   2,909 B |     152 B |