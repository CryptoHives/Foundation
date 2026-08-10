| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.367 μs | 0.0031 μs | 0.0029 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.445 μs | 0.0065 μs | 0.0060 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.412 μs | 0.0064 μs | 0.0059 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.481 μs | 0.0058 μs | 0.0054 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.734 μs | 0.0349 μs | 0.0326 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.941 μs | 0.0439 μs | 0.0411 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    10.181 μs | 0.0286 μs | 0.0267 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.326 μs | 0.0344 μs | 0.0322 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    76.635 μs | 0.2637 μs | 0.2466 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    77.669 μs | 0.1886 μs | 0.1575 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    80.249 μs | 0.3636 μs | 0.3401 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.879 μs | 0.2915 μs | 0.2727 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,224.433 μs | 4.2531 μs | 3.9783 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,242.163 μs | 6.1394 μs | 5.7428 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,284.432 μs | 4.2503 μs | 3.9758 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,292.957 μs | 4.4524 μs | 4.1647 μs |     152 B |