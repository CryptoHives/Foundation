| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     3.692 μs |  0.0176 μs |  0.0156 μs |  14,203 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     6.448 μs |  0.0224 μs |  0.0209 μs |     306 B |    3448 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     3.634 μs |  0.0064 μs |  0.0054 μs |  14,241 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     6.442 μs |  0.0170 μs |  0.0159 μs |     383 B |    3336 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    23.749 μs |  0.0701 μs |  0.0621 μs |  14,213 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    37.966 μs |  0.1293 μs |  0.1080 μs |     306 B |    8824 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    23.746 μs |  0.0503 μs |  0.0446 μs |  14,244 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    38.093 μs |  0.0831 μs |  0.0737 μs |     383 B |    7816 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   184.475 μs |  0.4098 μs |  0.3200 μs |  14,217 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   289.962 μs |  0.6527 μs |  0.5786 μs |     306 B |   51832 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   184.578 μs |  0.1884 μs |  0.1574 μs |  14,255 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   289.222 μs |  0.7527 μs |  0.7041 μs |     383 B |   43656 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 2,939.139 μs | 10.8628 μs |  9.6296 μs |  14,214 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 4,660.379 μs | 17.4508 μs | 16.3235 μs |     306 B |  789125 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 2,934.225 μs |  7.6487 μs |  6.7804 μs |  14,258 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 4,615.618 μs | 17.1837 μs | 15.2329 μs |     383 B |  658056 B |