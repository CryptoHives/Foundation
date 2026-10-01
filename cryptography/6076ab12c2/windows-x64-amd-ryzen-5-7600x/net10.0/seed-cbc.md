| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.363 μs | 0.0073 μs | 0.0068 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.557 μs | 0.0066 μs | 0.0062 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.377 μs | 0.0055 μs | 0.0051 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.522 μs | 0.0087 μs | 0.0081 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.757 μs | 0.0409 μs | 0.0383 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.318 μs | 0.0506 μs | 0.0473 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.834 μs | 0.0321 μs | 0.0285 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.378 μs | 0.0409 μs | 0.0383 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    76.657 μs | 0.3083 μs | 0.2883 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.560 μs | 0.3688 μs | 0.3449 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    77.539 μs | 0.3545 μs | 0.3316 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    81.147 μs | 0.2879 μs | 0.2693 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,224.597 μs | 5.9208 μs | 5.5383 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,284.995 μs | 5.5807 μs | 5.2202 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,237.990 μs | 4.7942 μs | 4.4845 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,292.858 μs | 2.7952 μs | 2.4778 μs |     152 B |