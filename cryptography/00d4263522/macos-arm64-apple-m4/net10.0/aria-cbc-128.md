| Description                                 | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       963.6 ns |      0.79 ns |      0.62 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,319.2 ns |      9.59 ns |      7.49 ns |    1208 B |
|                                             |              |                |              |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       959.9 ns |     12.72 ns |     11.90 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,279.4 ns |     37.45 ns |     33.20 ns |    1208 B |
|                                             |              |                |              |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,916.0 ns |     92.59 ns |     86.61 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,541.7 ns |    170.48 ns |    151.13 ns |    3448 B |
|                                             |              |                |              |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,822.0 ns |    110.37 ns |    103.24 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,335.5 ns |    172.16 ns |    161.04 ns |    3448 B |
|                                             |              |                |              |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    54,476.1 ns |    774.72 ns |    724.67 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   110,590.7 ns |  1,351.49 ns |  1,264.18 ns |   21368 B |
|                                             |              |                |              |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    53,740.2 ns |    865.24 ns |    809.35 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   108,280.3 ns |  1,287.59 ns |  1,204.41 ns |   21368 B |
|                                             |              |                |              |              |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   869,961.7 ns | 11,829.92 ns | 11,065.72 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,749,087.8 ns | 22,116.98 ns | 20,688.24 ns |  328568 B |
|                                             |              |                |              |              |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   857,566.7 ns | 12,639.70 ns | 11,823.18 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,745,656.0 ns | 21,232.21 ns | 19,860.63 ns |  328568 B |