| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.214 μs | 0.0040 μs | 0.0037 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     1.680 μs | 0.0023 μs | 0.0020 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     1.773 μs | 0.0036 μs | 0.0034 μs |     306 B |    1440 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.166 μs | 0.0034 μs | 0.0032 μs |     383 B |         - |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     1.600 μs | 0.0026 μs | 0.0023 μs |     383 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     1.634 μs | 0.0049 μs | 0.0038 μs |     386 B |    1424 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |     8.272 μs | 0.0263 μs | 0.0246 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |     9.495 μs | 0.0416 μs | 0.0389 μs |     306 B |    3680 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    11.228 μs | 0.0362 μs | 0.0339 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |     8.203 μs | 0.0152 μs | 0.0135 μs |     386 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |     9.386 μs | 0.0236 μs | 0.0221 μs |     383 B |    3664 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    11.690 μs | 0.0225 μs | 0.0199 μs |     386 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    64.908 μs | 0.3294 μs | 0.3081 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    71.322 μs | 0.1608 μs | 0.1425 μs |     306 B |   21600 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |    87.834 μs | 0.1160 μs | 0.1028 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    65.128 μs | 0.2346 μs | 0.2195 μs |     383 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    71.741 μs | 0.2573 μs | 0.2407 μs |     383 B |   21584 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |    87.878 μs | 0.2001 μs | 0.1774 μs |     383 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,039.817 μs | 5.8286 μs | 5.1669 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,135.401 μs | 4.5519 μs | 4.2578 μs |     306 B |  328800 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 1,406.557 μs | 6.3042 μs | 5.8969 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,032.347 μs | 3.0817 μs | 2.7318 μs |     383 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,137.487 μs | 3.8859 μs | 3.6349 μs |     383 B |  328784 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 1,416.309 μs | 4.5841 μs | 4.2879 μs |     383 B |         - |