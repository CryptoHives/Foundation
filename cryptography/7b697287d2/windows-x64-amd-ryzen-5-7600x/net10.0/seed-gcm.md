| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.362 μs | 0.0012 μs | 0.0011 μs |     306 B |         - |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     1.807 μs | 0.0011 μs | 0.0011 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128B         |     1.862 μs | 0.0019 μs | 0.0018 μs |     306 B |     944 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.325 μs | 0.0006 μs | 0.0005 μs |     383 B |         - |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     1.761 μs | 0.0014 μs | 0.0012 μs |     383 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128B         |     1.765 μs | 0.0014 μs | 0.0013 μs |     386 B |     928 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |     9.495 μs | 0.0079 μs | 0.0062 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 1KB          |    10.481 μs | 0.0069 μs | 0.0057 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    12.425 μs | 0.0098 μs | 0.0092 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |     9.469 μs | 0.0051 μs | 0.0047 μs |     383 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 1KB          |    10.411 μs | 0.0079 μs | 0.0074 μs |     383 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    12.385 μs | 0.0123 μs | 0.0109 μs |     383 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |    74.571 μs | 0.0536 μs | 0.0502 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 8KB          |    79.292 μs | 0.0371 μs | 0.0347 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |    97.364 μs | 0.0635 μs | 0.0563 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |    74.496 μs | 0.0305 μs | 0.0270 μs |     383 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 8KB          |    79.493 μs | 0.0489 μs | 0.0408 μs |     383 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |    97.292 μs | 0.0705 μs | 0.0588 μs |     383 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,190.571 μs | 0.5137 μs | 0.4805 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,260.358 μs | 0.7377 μs | 0.6900 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 1,553.705 μs | 2.1231 μs | 1.8821 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,189.767 μs | 0.4899 μs | 0.4583 μs |     383 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,265.524 μs | 0.5439 μs | 0.4542 μs |     383 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 1,552.916 μs | 1.3855 μs | 1.2960 μs |     383 B |         - |