| Description                            | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     3.268 μs |  0.0126 μs |  0.0118 μs |  22,632 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     5.305 μs |  0.0143 μs |  0.0134 μs |     310 B |    1000 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     3.179 μs |  0.0057 μs |  0.0048 μs |  16,267 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     5.198 μs |  0.0106 μs |  0.0099 μs |     390 B |     848 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    20.282 μs |  0.0424 μs |  0.0354 μs |  20,921 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    29.328 μs |  0.0388 μs |  0.0344 μs |     310 B |    1896 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    20.274 μs |  0.0545 μs |  0.0510 μs |  22,327 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    29.425 μs |  0.0234 μs |  0.0195 μs |     390 B |     848 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   156.394 μs |  0.3123 μs |  0.2921 μs |  16,680 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   223.098 μs |  0.3062 μs |  0.2557 μs |     310 B |    9064 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   156.950 μs |  0.3715 μs |  0.3475 μs |  25,301 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   223.151 μs |  0.2494 μs |  0.1947 μs |     390 B |     848 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 2,485.857 μs |  4.1611 μs |  3.6887 μs |  20,794 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 3,624.016 μs |  6.0493 μs |  5.3625 μs |     310 B |  131995 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 2,510.099 μs | 10.8630 μs | 10.1613 μs |  22,529 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 3,549.550 μs |  7.4890 μs |  7.0052 μs |     390 B |     848 B |