| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.289 μs | 0.0050 μs | 0.0047 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.371 μs | 0.0053 μs | 0.0050 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.331 μs | 0.0077 μs | 0.0072 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.404 μs | 0.0060 μs | 0.0056 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.157 μs | 0.0644 μs | 0.0602 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.383 μs | 0.0318 μs | 0.0298 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.602 μs | 0.0507 μs | 0.0474 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.737 μs | 0.0454 μs | 0.0425 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    72.002 μs | 0.5601 μs | 0.5239 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    73.327 μs | 0.4377 μs | 0.4094 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    75.675 μs | 0.4050 μs | 0.3788 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    76.368 μs | 0.3481 μs | 0.3086 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,151.554 μs | 7.9760 μs | 7.4607 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,171.036 μs | 6.6826 μs | 6.2510 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,209.253 μs | 7.3444 μs | 6.8700 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,220.976 μs | 6.0330 μs | 5.6433 μs |     152 B |