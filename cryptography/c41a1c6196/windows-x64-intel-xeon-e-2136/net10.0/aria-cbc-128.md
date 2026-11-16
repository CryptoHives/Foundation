| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     3.845 μs |  0.0197 μs |  0.0185 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     4.915 μs |  0.0190 μs |  0.0168 μs |   2,937 B |    1208 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     3.902 μs |  0.0170 μs |  0.0159 μs |   1,307 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     4.548 μs |  0.0073 μs |  0.0068 μs |   2,921 B |    1208 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    27.037 μs |  0.0836 μs |  0.0741 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    28.759 μs |  0.0548 μs |  0.0513 μs |   2,935 B |    3448 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    27.372 μs |  0.0177 μs |  0.0157 μs |   1,307 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    28.133 μs |  0.0235 μs |  0.0208 μs |   2,933 B |    3448 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   211.187 μs |  0.8742 μs |  0.8177 μs |   1,298 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   221.463 μs |  0.2827 μs |  0.2506 μs |   2,933 B |   21368 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   214.956 μs |  0.1914 μs |  0.1598 μs |   1,305 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   221.516 μs |  0.5421 μs |  0.4806 μs |   2,935 B |   21368 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 3,373.341 μs | 14.3272 μs | 13.4016 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 3,561.564 μs |  9.6256 μs |  9.0038 μs |   2,933 B |  328568 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 3,430.859 μs |  1.1533 μs |  0.9630 μs |   1,311 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 3,506.728 μs |  4.0872 μs |  3.6232 μs |   2,933 B |  328568 B |