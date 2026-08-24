| Description                                 | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       959.5 ns |      0.82 ns |      0.76 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,174.9 ns |      1.28 ns |      1.20 ns |    1208 B |
|                                             |              |                |              |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       947.1 ns |      0.70 ns |      0.66 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,097.0 ns |      0.86 ns |      0.77 ns |    1208 B |
|                                             |              |                |              |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,832.9 ns |      5.60 ns |      4.96 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    13,306.2 ns |      5.71 ns |      5.06 ns |    3448 B |
|                                             |              |                |              |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,727.9 ns |     22.06 ns |     17.22 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    12,808.1 ns |     37.08 ns |     32.87 ns |    3448 B |
|                                             |              |                |              |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    53,810.5 ns |    191.00 ns |    149.12 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   112,971.5 ns |  2,240.09 ns |  3,981.76 ns |   21368 B |
|                                             |              |                |              |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,936.2 ns |     19.00 ns |     14.84 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   100,084.0 ns |     34.29 ns |     28.63 ns |   21368 B |
|                                             |              |                |              |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   994,387.4 ns | 19,650.84 ns | 43,544.90 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,970,327.9 ns | 35,061.44 ns | 32,796.49 ns |  328568 B |
|                                             |              |                |              |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   846,545.0 ns |    631.57 ns |    527.39 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,590,485.9 ns |    262.27 ns |    232.49 ns |  328568 B |