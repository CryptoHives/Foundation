| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     7.174 μs |   0.0137 μs |   0.0121 μs |   4,218 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |    10.430 μs |   0.0384 μs |   0.0341 μs |  13,740 B |    1784 B |
|                                               |              |              |             |             |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     4.429 μs |   0.0032 μs |   0.0028 μs |  10,743 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     6.314 μs |   0.0066 μs |   0.0062 μs |  13,740 B |    1784 B |
|                                               |              |              |             |             |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    46.836 μs |   0.0593 μs |   0.0526 μs |  10,553 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    60.136 μs |   0.3608 μs |   0.3375 μs |   7,781 B |    1784 B |
|                                               |              |              |             |             |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    29.069 μs |   0.0138 μs |   0.0123 μs |  10,553 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    32.069 μs |   0.0279 μs |   0.0261 μs |   7,781 B |    1784 B |
|                                               |              |              |             |             |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   366.693 μs |   1.9315 μs |   1.8068 μs |  10,553 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   458.491 μs |   0.8730 μs |   0.6816 μs |  13,930 B |    1784 B |
|                                               |              |              |             |             |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   231.277 μs |   0.2957 μs |   0.2766 μs |  10,743 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   236.945 μs |   0.2077 μs |   0.1943 μs |  13,930 B |    1784 B |
|                                               |              |              |             |             |           |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 5,803.340 μs |   7.0083 μs |   6.5556 μs |  10,506 B |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 7,139.926 μs | 123.8343 μs | 115.8347 μs |  13,740 B |    1784 B |
|                                               |              |              |             |             |           |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 3,593.798 μs |   2.7161 μs |   2.2681 μs |  10,552 B |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,738.653 μs |   0.9243 μs |   0.7718 μs |  13,740 B |    1784 B |