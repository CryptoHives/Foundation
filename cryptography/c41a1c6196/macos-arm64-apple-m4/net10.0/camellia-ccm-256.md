| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.073 μs | 0.0091 μs | 0.0081 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     2.771 μs | 0.0080 μs | 0.0074 μs |    2232 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.026 μs | 0.0174 μs | 0.0163 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     2.707 μs | 0.0132 μs | 0.0123 μs |    2120 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    13.241 μs | 0.0371 μs | 0.0347 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    15.957 μs | 0.0914 μs | 0.0855 μs |    7608 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    13.206 μs | 0.0293 μs | 0.0259 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    15.912 μs | 0.0983 μs | 0.0919 μs |    6600 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   102.474 μs | 0.3146 μs | 0.2943 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   121.784 μs | 0.3084 μs | 0.2885 μs |   50616 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   102.340 μs | 0.2040 μs | 0.1703 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   121.502 μs | 0.4023 μs | 0.3763 μs |   42440 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,675.388 μs | 3.1754 μs | 2.6516 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 1,962.773 μs | 4.7853 μs | 4.4762 μs |  787924 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,634.269 μs | 3.7394 μs | 3.1226 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 1,929.805 μs | 9.3346 μs | 8.2749 μs |  656840 B |