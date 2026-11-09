| Description                             | TestDataSize | Mean         | Error      | StdDev     | Median       | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|-------------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.683 μs |  0.0204 μs |  0.0190 μs |     1.689 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.820 μs |  0.0278 μs |  0.0260 μs |     1.836 μs |   2,935 B |     152 B |
|                                         |              |              |            |            |              |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.705 μs |  0.0186 μs |  0.0165 μs |     1.712 μs |   1,313 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.791 μs |  0.0243 μs |  0.0227 μs |     1.802 μs |   2,933 B |     152 B |
|                                         |              |              |            |            |              |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    11.553 μs |  0.1690 μs |  0.1581 μs |    11.637 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    11.966 μs |  0.0915 μs |  0.0856 μs |    12.003 μs |   2,935 B |     152 B |
|                                         |              |              |            |            |              |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    11.674 μs |  0.2079 μs |  0.1945 μs |    11.828 μs |   1,307 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    11.783 μs |  0.1261 μs |  0.1179 μs |    11.802 μs |   2,933 B |     152 B |
|                                         |              |              |            |            |              |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    90.422 μs |  1.3182 μs |  1.2331 μs |    90.984 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    93.022 μs |  1.6363 μs |  1.5306 μs |    94.033 μs |   2,933 B |     152 B |
|                                         |              |              |            |            |              |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    91.522 μs |  1.7427 μs |  1.6301 μs |    92.765 μs |   2,933 B |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    91.894 μs |  1.2664 μs |  1.1846 μs |    92.540 μs |   1,305 B |         - |
|                                         |              |              |            |            |              |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,443.272 μs | 21.9380 μs | 20.5208 μs | 1,456.053 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,469.004 μs | 23.6001 μs | 22.0755 μs | 1,480.059 μs |   2,933 B |     152 B |
|                                         |              |              |            |            |              |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,463.175 μs | 20.8783 μs | 19.5296 μs | 1,470.036 μs |   1,305 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,467.378 μs | 17.4136 μs | 16.2887 μs | 1,474.509 μs |   2,933 B |     152 B |