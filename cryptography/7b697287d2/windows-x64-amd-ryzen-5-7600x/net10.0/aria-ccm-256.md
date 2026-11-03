| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     4.838 μs |  0.0067 μs |  0.0052 μs |  14,203 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     8.290 μs |  0.0289 μs |  0.0270 μs |     306 B |    3880 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     4.781 μs |  0.0196 μs |  0.0173 μs |  14,244 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     8.217 μs |  0.0300 μs |  0.0280 μs |     383 B |    3768 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    31.349 μs |  0.1964 μs |  0.1837 μs |  14,216 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    49.399 μs |  0.0534 μs |  0.0417 μs |     306 B |    9256 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    31.385 μs |  0.1829 μs |  0.1711 μs |  14,251 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    49.437 μs |  0.0984 μs |  0.0872 μs |     383 B |    8248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   243.298 μs |  0.4073 μs |  0.3180 μs |  14,217 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   376.605 μs |  0.8429 μs |  0.7884 μs |     306 B |   52264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   243.362 μs |  0.5261 μs |  0.4664 μs |  14,255 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   375.289 μs |  0.7074 μs |  0.6617 μs |     383 B |   44088 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 3,880.835 μs |  6.1332 μs |  5.4369 μs |  14,217 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 6,055.373 μs | 12.6878 μs | 11.2474 μs |     306 B |  789557 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 3,867.634 μs |  5.0752 μs |  4.7473 μs |  14,255 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 5,951.931 μs | 10.9338 μs |  9.6925 μs |     383 B |  658488 B |