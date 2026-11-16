| Description                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.207 μs | 0.0017 μs | 0.0014 μs |  10,033 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.452 μs | 0.0086 μs | 0.0081 μs |     306 B |    1032 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.162 μs | 0.0022 μs | 0.0019 μs |  10,071 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.395 μs | 0.0040 μs | 0.0036 μs |     383 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    14.114 μs | 0.0085 μs | 0.0079 μs |  10,043 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    20.112 μs | 0.0375 μs | 0.0332 μs |     306 B |    1928 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    14.073 μs | 0.0086 μs | 0.0080 μs |  10,081 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    20.006 μs | 0.0320 μs | 0.0299 μs |     383 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   109.033 μs | 0.0759 μs | 0.0710 μs |  10,047 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   153.336 μs | 0.2065 μs | 0.1831 μs |     306 B |    9096 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   109.392 μs | 0.0967 μs | 0.0905 μs |  10,085 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   152.687 μs | 0.1923 μs | 0.1799 μs |     383 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,737.296 μs | 1.1554 μs | 1.0242 μs |  10,047 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,474.055 μs | 2.3795 μs | 2.1094 μs |     306 B |  131989 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,736.380 μs | 1.4284 μs | 1.3361 μs |  10,085 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,429.994 μs | 1.7734 μs | 1.5720 μs |     383 B |     920 B |