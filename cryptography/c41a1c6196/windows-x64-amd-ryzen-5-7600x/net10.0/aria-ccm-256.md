| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     4.829 μs |  0.0202 μs |  0.0179 μs |  14,206 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     8.245 μs |  0.0312 μs |  0.0276 μs |     306 B |    3880 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     4.775 μs |  0.0154 μs |  0.0129 μs |  14,241 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     8.148 μs |  0.0120 μs |  0.0093 μs |     386 B |    3768 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    31.208 μs |  0.1543 μs |  0.1368 μs |  14,213 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    49.089 μs |  0.1123 μs |  0.1051 μs |     306 B |    9256 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    31.248 μs |  0.1264 μs |  0.1183 μs |  14,251 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    49.170 μs |  0.1370 μs |  0.1144 μs |     383 B |    8248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   242.952 μs |  1.1208 μs |  0.9359 μs |  14,217 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   376.606 μs |  0.8924 μs |  0.8348 μs |     306 B |   52264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   243.340 μs |  0.7486 μs |  0.6636 μs |  14,258 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   377.200 μs |  0.5022 μs |  0.4452 μs |     383 B |   44088 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 3,881.850 μs |  8.1568 μs |  7.6299 μs |  14,217 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 6,070.026 μs | 23.2951 μs | 20.6505 μs |     306 B |  789557 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 3,874.321 μs |  9.9266 μs |  8.2892 μs |  14,255 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 5,946.388 μs | 13.0538 μs | 12.2105 μs |     383 B |  658488 B |