| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     5.632 μs |  0.0034 μs |  0.0030 μs |     584 B |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     9.099 μs |  0.0481 μs |  0.0450 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     5.479 μs |  0.0059 μs |  0.0055 μs |     584 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     9.608 μs |  0.0106 μs |  0.0099 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    37.796 μs |  0.0199 μs |  0.0176 μs |    2824 B |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |    64.997 μs |  0.5909 μs |  0.5527 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    37.508 μs |  0.0245 μs |  0.0204 μs |    2824 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |    69.262 μs |  0.0625 μs |  0.0584 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |   284.240 μs |  0.4419 μs |  0.4133 μs |   20744 B |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |   504.456 μs |  0.5698 μs |  0.5051 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |   280.094 μs |  0.8741 μs |  0.8176 μs |   20744 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |   548.789 μs |  3.4213 μs |  3.2003 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 4,417.579 μs | 23.1165 μs | 20.4922 μs |  327944 B |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 8,127.228 μs | 87.3355 μs | 81.6937 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 4,424.125 μs | 29.3133 μs | 27.4197 μs |  327944 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 8,724.017 μs |  8.3344 μs |  7.7960 μs |         - |