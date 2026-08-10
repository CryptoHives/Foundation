| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     5.629 μs |  0.0080 μs |  0.0063 μs |     592 B |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     8.950 μs |  0.0193 μs |  0.0171 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     5.469 μs |  0.0059 μs |  0.0055 μs |     592 B |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     9.612 μs |  0.0099 μs |  0.0092 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    36.101 μs |  0.0404 μs |  0.0378 μs |    2832 B |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |    64.019 μs |  0.1037 μs |  0.0970 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    36.965 μs |  0.0583 μs |  0.0517 μs |    2832 B |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |    69.154 μs |  0.1470 μs |  0.1375 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |   280.042 μs |  0.8990 μs |  0.7970 μs |   20752 B |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |   515.152 μs |  0.2538 μs |  0.2250 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |   280.038 μs |  0.8096 μs |  0.7177 μs |   20752 B |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |   546.403 μs |  1.0973 μs |  0.9728 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 4,436.875 μs | 16.6690 μs | 14.7766 μs |  327952 B |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 8,068.557 μs | 22.9966 μs | 17.9542 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 4,437.208 μs | 21.3359 μs | 19.9576 μs |  327952 B |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 8,779.871 μs | 40.6294 μs | 38.0047 μs |         - |