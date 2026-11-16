| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     3.924 μs |  0.0037 μs |  0.0031 μs |  18,765 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     5.358 μs |  0.0129 μs |  0.0120 μs |     310 B |    2232 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     3.843 μs |  0.0045 μs |  0.0042 μs |  18,821 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     5.244 μs |  0.0104 μs |  0.0097 μs |     387 B |    2120 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    24.785 μs |  0.0175 μs |  0.0146 μs |  18,772 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    30.608 μs |  0.1171 μs |  0.1038 μs |     310 B |    7608 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    24.672 μs |  0.0099 μs |  0.0093 μs |  18,825 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    31.103 μs |  0.0960 μs |  0.0898 μs |     387 B |    6600 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   191.047 μs |  0.0632 μs |  0.0591 μs |  18,776 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   235.350 μs |  1.1289 μs |  1.0560 μs |     310 B |   50616 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   191.217 μs |  0.0977 μs |  0.0914 μs |  18,829 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   232.116 μs |  0.8875 μs |  0.8301 μs |     387 B |   42440 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 3,041.890 μs |  1.0186 μs |  0.9528 μs |  18,776 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 3,785.725 μs |  3.8251 μs |  3.5780 μs |     310 B |  787909 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 3,052.050 μs |  0.4493 μs |  0.3983 μs |  18,829 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 3,721.455 μs | 18.4968 μs | 17.3019 μs |     387 B |  656840 B |