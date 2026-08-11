| Description                             | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.381 μs |  0.0142 μs |  0.0133 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.465 μs |  0.0140 μs |  0.0130 μs |     152 B |
|                                         |              |              |            |            |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.427 μs |  0.0148 μs |  0.0131 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.499 μs |  0.0139 μs |  0.0130 μs |     152 B |
|                                         |              |              |            |            |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.776 μs |  0.0342 μs |  0.0267 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.056 μs |  0.1051 μs |  0.0983 μs |     152 B |
|                                         |              |              |            |            |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    10.249 μs |  0.0715 μs |  0.0597 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.432 μs |  0.1011 μs |  0.0946 μs |     152 B |
|                                         |              |              |            |            |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    76.947 μs |  0.3371 μs |  0.2632 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    78.718 μs |  0.8514 μs |  0.7964 μs |     152 B |
|                                         |              |              |            |            |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    81.251 μs |  0.7670 μs |  0.7175 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    81.749 μs |  0.8517 μs |  0.7967 μs |     152 B |
|                                         |              |              |            |            |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,231.475 μs |  7.5605 μs |  5.9028 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,248.733 μs |  5.5593 μs |  4.3403 μs |     152 B |
|                                         |              |              |            |            |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,297.728 μs | 14.4547 μs | 13.5209 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,308.957 μs | 16.3039 μs | 15.2507 μs |     152 B |