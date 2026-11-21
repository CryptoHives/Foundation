| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     3.967 μs | 0.0052 μs | 0.0049 μs |  37,951 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     4.953 μs | 0.0102 μs | 0.0090 μs |     310 B |    2200 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     3.872 μs | 0.0051 μs | 0.0048 μs |  24,623 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     4.887 μs | 0.0051 μs | 0.0048 μs |     390 B |    2048 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    24.998 μs | 0.0064 μs | 0.0060 μs |  23,161 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    27.701 μs | 0.0476 μs | 0.0422 μs |     310 B |    7576 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    25.108 μs | 0.0052 μs | 0.0043 μs |  25,432 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    27.938 μs | 0.0322 μs | 0.0285 μs |     390 B |    6528 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   193.247 μs | 0.0477 μs | 0.0446 μs |  29,705 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   212.935 μs | 0.6062 μs | 0.5374 μs |     310 B |   50584 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   193.772 μs | 0.0769 μs | 0.0720 μs |  30,945 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   211.143 μs | 0.4459 μs | 0.3724 μs |     390 B |   42368 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 3,066.185 μs | 0.3951 μs | 0.3502 μs |  31,229 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 3,438.213 μs | 3.2821 μs | 2.9095 μs |     310 B |  787915 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 3,085.029 μs | 0.5569 μs | 0.4936 μs |  26,752 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 3,465.075 μs | 4.4669 μs | 3.4875 μs |     390 B |  656768 B |