| Description                            | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.082 μs |  0.0154 μs |  0.0144 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.153 μs |  0.0136 μs |  0.0127 μs |    1032 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.040 μs |  0.0127 μs |  0.0119 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.092 μs |  0.0127 μs |  0.0119 μs |     920 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    13.308 μs |  0.0528 μs |  0.0494 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    18.268 μs |  0.0881 μs |  0.0824 μs |    1928 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    13.264 μs |  0.0449 μs |  0.0420 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    18.172 μs |  0.0952 μs |  0.0891 μs |     920 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   102.986 μs |  0.3861 μs |  0.3611 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   139.210 μs |  0.9105 μs |  0.8517 μs |    9096 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   102.951 μs |  0.4851 μs |  0.4537 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   138.582 μs |  0.5591 μs |  0.5230 μs |     920 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,647.185 μs |  7.8858 μs |  7.3764 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,225.221 μs | 12.1843 μs | 11.3972 μs |  132002 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,644.236 μs |  6.2440 μs |  5.8406 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,206.914 μs | 14.0591 μs | 13.1509 μs |     920 B |