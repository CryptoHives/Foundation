| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     3.184 μs |  0.0033 μs |  0.0031 μs |  18,775 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     4.393 μs |  0.0184 μs |  0.0172 μs |     310 B |    2184 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     3.053 μs |  0.0021 μs |  0.0018 μs |  18,825 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     4.291 μs |  0.0222 μs |  0.0197 μs |     387 B |    2072 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    19.747 μs |  0.0051 μs |  0.0045 μs |  18,764 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    24.955 μs |  0.0827 μs |  0.0733 μs |     310 B |    7560 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    19.695 μs |  0.0093 μs |  0.0078 μs |  18,835 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    25.008 μs |  0.0809 μs |  0.0756 μs |     387 B |    6552 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |   152.132 μs |  0.0277 μs |  0.0246 μs |  18,783 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   188.698 μs |  0.3089 μs |  0.2738 μs |     310 B |   50568 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |   151.768 μs |  0.0661 μs |  0.0586 μs |  18,836 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   187.571 μs |  1.0306 μs |  0.9640 μs |     387 B |   42392 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 2,413.608 μs |  0.5330 μs |  0.4450 μs |  18,783 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 3,081.294 μs |  4.1670 μs |  3.8979 μs |     310 B |  787861 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 2,423.471 μs |  0.9921 μs |  0.9280 μs |  18,833 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 2,939.607 μs | 20.7846 μs | 19.4420 μs |     387 B |  656792 B |