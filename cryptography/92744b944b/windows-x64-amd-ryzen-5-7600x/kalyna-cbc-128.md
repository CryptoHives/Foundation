| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2.337 μs | 0.0096 μs | 0.0085 μs |     872 B |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     5.027 μs | 0.0179 μs | 0.0159 μs |         - |
|                                               |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1.327 μs | 0.0032 μs | 0.0027 μs |     872 B |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     3.547 μs | 0.0115 μs | 0.0102 μs |         - |
|                                               |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    14.360 μs | 0.0585 μs | 0.0547 μs |     872 B |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |    36.403 μs | 0.1291 μs | 0.1207 μs |         - |
|                                               |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7.055 μs | 0.0150 μs | 0.0141 μs |     872 B |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |    25.714 μs | 0.0604 μs | 0.0565 μs |         - |
|                                               |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   113.686 μs | 0.2425 μs | 0.2268 μs |     872 B |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |   285.070 μs | 0.8701 μs | 0.7713 μs |         - |
|                                               |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    52.924 μs | 0.1145 μs | 0.0956 μs |     872 B |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |   201.055 μs | 0.5040 μs | 0.4468 μs |         - |
|                                               |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,750.147 μs | 5.0284 μs | 4.4575 μs |     872 B |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 4,551.189 μs | 8.7791 μs | 6.8542 μs |         - |
|                                               |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   837.794 μs | 1.5960 μs | 1.4929 μs |     872 B |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 3,258.497 μs | 4.4095 μs | 4.1246 μs |         - |