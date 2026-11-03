| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     3.680 μs |  0.0065 μs |  0.0061 μs |  14,203 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     6.461 μs |  0.0121 μs |  0.0113 μs |     306 B |    3448 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     3.643 μs |  0.0033 μs |  0.0030 μs |  14,241 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     7.704 μs |  0.0203 μs |  0.0190 μs |     386 B |    3336 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    23.799 μs |  0.0591 μs |  0.0553 μs |  14,213 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    38.250 μs |  0.1394 μs |  0.1304 μs |     306 B |    8824 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    23.770 μs |  0.1093 μs |  0.1022 μs |  14,244 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    38.794 μs |  0.1233 μs |  0.1154 μs |     383 B |    7816 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   184.834 μs |  0.7099 μs |  0.6293 μs |  14,220 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   289.652 μs |  0.8218 μs |  0.7285 μs |     306 B |   51832 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   184.725 μs |  0.5304 μs |  0.4962 μs |  14,249 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   294.982 μs |  0.5196 μs |  0.4606 μs |     383 B |   43656 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 2,944.251 μs |  8.4637 μs |  7.9170 μs |  14,220 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 4,820.769 μs | 18.3110 μs | 17.1281 μs |     306 B |  789125 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 2,946.655 μs | 11.5932 μs | 10.2771 μs |  14,255 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 4,611.794 μs | 20.6969 μs | 19.3599 μs |     383 B |  658056 B |