| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.373 μs | 0.0016 μs | 0.0015 μs |     306 B |         - |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     1.800 μs | 0.0024 μs | 0.0021 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128B         |     1.830 μs | 0.0048 μs | 0.0045 μs |     306 B |     944 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.328 μs | 0.0015 μs | 0.0012 μs |     386 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128B         |     1.705 μs | 0.0059 μs | 0.0055 μs |     386 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     1.753 μs | 0.0044 μs | 0.0041 μs |     386 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |     9.511 μs | 0.0092 μs | 0.0086 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 1KB          |    10.137 μs | 0.0176 μs | 0.0147 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    12.315 μs | 0.0162 μs | 0.0143 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |     9.469 μs | 0.0067 μs | 0.0056 μs |     386 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 1KB          |    10.079 μs | 0.0260 μs | 0.0203 μs |     386 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    12.290 μs | 0.0300 μs | 0.0266 μs |     386 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |    74.612 μs | 0.0552 μs | 0.0489 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 8KB          |    76.685 μs | 0.0721 μs | 0.0675 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |    96.905 μs | 0.1557 μs | 0.1381 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |    74.639 μs | 0.0666 μs | 0.0623 μs |     386 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 8KB          |    76.812 μs | 0.1099 μs | 0.1028 μs |     386 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |    96.483 μs | 0.2786 μs | 0.2327 μs |     386 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,190.418 μs | 0.4042 μs | 0.3583 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,220.044 μs | 1.4084 μs | 1.3174 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 1,539.448 μs | 2.4460 μs | 2.2880 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,191.564 μs | 1.5037 μs | 1.4065 μs |     386 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,226.869 μs | 0.9865 μs | 0.8745 μs |     386 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 1,540.745 μs | 2.2158 μs | 1.9642 μs |     386 B |         - |