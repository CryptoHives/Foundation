| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     3.935 μs | 0.0036 μs | 0.0032 μs |  18,765 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     5.384 μs | 0.0097 μs | 0.0081 μs |     310 B |    2232 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     3.834 μs | 0.0050 μs | 0.0044 μs |  18,818 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     5.253 μs | 0.0092 μs | 0.0082 μs |     387 B |    2120 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    24.922 μs | 0.0250 μs | 0.0234 μs |  18,775 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    30.884 μs | 0.0524 μs | 0.0465 μs |     310 B |    7608 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    24.788 μs | 0.0273 μs | 0.0242 μs |  18,825 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    31.181 μs | 0.0978 μs | 0.0915 μs |     387 B |    6600 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   191.497 μs | 0.1163 μs | 0.0971 μs |  18,776 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   234.168 μs | 0.4864 μs | 0.4550 μs |     310 B |   50616 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   191.464 μs | 0.1334 μs | 0.1114 μs |  18,829 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   233.958 μs | 0.3535 μs | 0.3134 μs |     387 B |   42440 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 3,060.064 μs | 1.7147 μs | 1.4318 μs |  18,776 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 3,813.472 μs | 4.4737 μs | 4.1847 μs |     310 B |  787909 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 3,059.583 μs | 1.7118 μs | 1.5175 μs |  18,829 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 3,710.257 μs | 6.9991 μs | 6.2046 μs |     387 B |  656840 B |