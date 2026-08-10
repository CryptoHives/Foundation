| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.194 μs | 0.0018 μs | 0.0017 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.290 μs | 0.0018 μs | 0.0017 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.203 μs | 0.0013 μs | 0.0012 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.286 μs | 0.0028 μs | 0.0026 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.539 μs | 0.0125 μs | 0.0111 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.745 μs | 0.0140 μs | 0.0131 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.626 μs | 0.0123 μs | 0.0115 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.802 μs | 0.0150 μs | 0.0140 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    67.278 μs | 0.0757 μs | 0.0708 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    68.374 μs | 0.0937 μs | 0.0876 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    67.979 μs | 0.0610 μs | 0.0540 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    68.824 μs | 0.0622 μs | 0.0582 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,075.115 μs | 0.7034 μs | 0.6579 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,104.152 μs | 1.2752 μs | 1.1304 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,085.774 μs | 1.4721 μs | 1.3050 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,098.385 μs | 1.5355 μs | 1.4363 μs |     152 B |