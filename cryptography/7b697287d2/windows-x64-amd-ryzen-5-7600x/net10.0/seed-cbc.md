| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.371 μs | 0.0013 μs | 0.0011 μs |   1,289 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.511 μs | 0.0016 μs | 0.0015 μs |   2,895 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.378 μs | 0.0012 μs | 0.0012 μs |   1,291 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.508 μs | 0.0008 μs | 0.0007 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.757 μs | 0.0071 μs | 0.0066 μs |   1,289 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.243 μs | 0.0159 μs | 0.0149 μs |   2,911 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.817 μs | 0.0130 μs | 0.0122 μs |   1,285 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.310 μs | 0.0076 μs | 0.0072 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    76.864 μs | 0.0933 μs | 0.0873 μs |   1,289 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    81.257 μs | 0.0868 μs | 0.0812 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    77.319 μs | 0.0734 μs | 0.0687 μs |   1,283 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.606 μs | 0.0470 μs | 0.0440 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,229.267 μs | 0.8901 μs | 0.7890 μs |   1,289 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,284.289 μs | 1.1918 μs | 1.1148 μs |   2,909 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,234.249 μs | 1.1798 μs | 1.0458 μs |   1,283 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,290.908 μs | 5.7709 μs | 5.3981 μs |   2,909 B |     152 B |