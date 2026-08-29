| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.386 μs | 0.0025 μs | 0.0022 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.464 μs | 0.0044 μs | 0.0039 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.437 μs | 0.0010 μs | 0.0009 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.498 μs | 0.0011 μs | 0.0010 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.861 μs | 0.0377 μs | 0.0315 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.090 μs | 0.0382 μs | 0.0357 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    10.399 μs | 0.0238 μs | 0.0211 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.457 μs | 0.0172 μs | 0.0144 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    77.581 μs | 0.3318 μs | 0.2771 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    79.032 μs | 0.3529 μs | 0.3128 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    82.034 μs | 0.2466 μs | 0.2307 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    82.040 μs | 0.1679 μs | 0.1402 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,243.434 μs | 4.4041 μs | 3.6776 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,264.101 μs | 5.2792 μs | 4.6799 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,309.544 μs | 4.7448 μs | 3.9622 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,310.907 μs | 3.2904 μs | 2.7476 μs |         - |