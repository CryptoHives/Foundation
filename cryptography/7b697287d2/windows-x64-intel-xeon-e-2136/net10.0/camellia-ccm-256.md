| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.950 μs |  0.0077 μs |  0.0072 μs |  18,765 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     4.123 μs |  0.0481 μs |  0.0450 μs |     310 B |    2232 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.875 μs |  0.0040 μs |  0.0036 μs |  18,818 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     3.969 μs |  0.0196 μs |  0.0184 μs |     390 B |    2120 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    19.036 μs |  0.1768 μs |  0.1654 μs |  18,772 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    23.537 μs |  0.3034 μs |  0.2838 μs |     310 B |    7608 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    18.620 μs |  0.0727 μs |  0.0680 μs |  18,828 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    22.790 μs |  0.0463 μs |  0.0433 μs |     387 B |    6600 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   146.184 μs |  1.5645 μs |  1.4635 μs |  18,776 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   178.373 μs |  2.1614 μs |  2.0218 μs |     310 B |   50616 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   143.857 μs |  0.4340 μs |  0.4060 μs |  18,829 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   175.047 μs |  0.4876 μs |  0.4561 μs |     387 B |   42440 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 2,341.723 μs | 18.5053 μs | 17.3099 μs |  18,776 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 2,898.763 μs | 28.1708 μs | 26.3510 μs |     310 B |  787909 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 2,294.915 μs |  7.9023 μs |  7.0052 μs |  18,829 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 2,746.166 μs | 10.8331 μs |  9.0462 μs |     387 B |  656840 B |