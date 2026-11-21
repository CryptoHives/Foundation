| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     1.654 μs |  0.0073 μs |  0.0065 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     2.082 μs |  0.0175 μs |  0.0155 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     2.875 μs |  0.0046 μs |  0.0039 μs |     306 B |    2040 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     1.601 μs |  0.0031 μs |  0.0025 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     2.024 μs |  0.0091 μs |  0.0081 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     2.753 μs |  0.0085 μs |  0.0071 μs |     386 B |    2024 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    11.697 μs |  0.1607 μs |  0.1503 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    14.489 μs |  0.1746 μs |  0.1633 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    16.205 μs |  0.1797 μs |  0.1593 μs |     306 B |    4280 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    11.388 μs |  0.0236 μs |  0.0197 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    14.221 μs |  0.0180 μs |  0.0140 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    15.849 μs |  0.1580 μs |  0.1319 μs |     386 B |    4264 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |    91.709 μs |  1.2812 μs |  1.1985 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   114.501 μs |  1.5178 μs |  1.3455 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   121.974 μs |  1.1042 μs |  1.0329 μs |     306 B |   22200 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |    89.736 μs |  0.2211 μs |  0.2068 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   111.451 μs |  0.2703 μs |  0.2257 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   120.108 μs |  0.1938 μs |  0.1619 μs |     386 B |   22184 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 1,461.674 μs | 19.9531 μs | 18.6642 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 1,818.826 μs | 18.8705 μs | 16.7282 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 1,940.978 μs | 26.0109 μs | 21.7203 μs |     306 B |  329400 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 1,432.339 μs |  3.2958 μs |  2.9217 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 1,778.284 μs |  4.6124 μs |  3.8516 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 1,907.894 μs |  5.8295 μs |  5.1677 μs |     386 B |  329384 B |