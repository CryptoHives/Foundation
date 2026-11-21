| Description                             | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     2.059 μs |  0.0174 μs |  0.0163 μs |   4,026 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     2.306 μs |  0.0058 μs |  0.0048 μs |   7,776 B |     152 B |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     2.116 μs |  0.0049 μs |  0.0046 μs |   4,026 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     2.242 μs |  0.0044 μs |  0.0041 μs |  13,735 B |     152 B |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    14.281 μs |  0.0551 μs |  0.0461 μs |  10,551 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    15.226 μs |  0.0335 μs |  0.0297 μs |  13,735 B |     152 B |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    14.609 μs |  0.0050 μs |  0.0041 μs |   4,026 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    14.840 μs |  0.0422 μs |  0.0394 μs |  13,925 B |     152 B |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |   112.521 μs |  0.2189 μs |  0.2048 μs |  10,361 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |   117.684 μs |  0.1455 μs |  0.1290 μs |   7,776 B |     152 B |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |   114.698 μs |  0.0594 μs |  0.0526 μs |   4,026 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |   116.012 μs |  0.0879 μs |  0.0686 μs |   7,776 B |     152 B |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,810.521 μs |  4.1833 μs |  3.7084 μs |  10,551 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,902.769 μs | 13.1445 μs | 12.2954 μs |  13,735 B |     152 B |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,830.140 μs |  0.6707 μs |  0.6273 μs |  10,361 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,840.971 μs |  1.4071 μs |  1.1750 μs |  13,925 B |     152 B |