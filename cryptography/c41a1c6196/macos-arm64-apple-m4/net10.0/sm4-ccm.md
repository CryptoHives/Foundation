| Description                            | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.144 μs |  0.0072 μs |  0.0067 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.235 μs |  0.0103 μs |  0.0097 μs |    1032 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.100 μs |  0.0125 μs |  0.0117 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.167 μs |  0.0107 μs |  0.0083 μs |     920 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    13.680 μs |  0.0564 μs |  0.0528 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    18.844 μs |  0.1336 μs |  0.1250 μs |    1928 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    13.629 μs |  0.0787 μs |  0.0736 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    18.720 μs |  0.0909 μs |  0.0850 μs |     920 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   106.325 μs |  0.3628 μs |  0.3394 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   143.710 μs |  0.8005 μs |  0.7488 μs |    9096 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   105.984 μs |  0.4352 μs |  0.4071 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   142.769 μs |  0.8336 μs |  0.7797 μs |     920 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,692.466 μs |  6.7345 μs |  6.2995 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,285.397 μs |  7.9128 μs |  7.0145 μs |  132002 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,690.022 μs |  6.5955 μs |  6.1695 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,268.359 μs | 13.7765 μs | 12.8865 μs |     920 B |