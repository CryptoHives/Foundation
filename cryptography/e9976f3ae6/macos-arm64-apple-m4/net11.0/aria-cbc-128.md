| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       942.7 ns |     1.82 ns |     1.70 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     1,996.0 ns |     8.98 ns |     8.40 ns |    1208 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       940.3 ns |     0.45 ns |     0.40 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     1,908.2 ns |     8.15 ns |     7.62 ns |    1208 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,665.1 ns |     6.30 ns |     5.89 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    11,490.9 ns |    27.06 ns |    25.31 ns |    3448 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,664.4 ns |     4.77 ns |     4.23 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    12,296.4 ns |    27.32 ns |    22.82 ns |    3448 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,470.6 ns |    39.20 ns |    34.75 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |    89,869.4 ns |   256.93 ns |   240.33 ns |   21368 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,483.9 ns |    81.03 ns |    75.80 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |    96,171.0 ns |   277.55 ns |   259.62 ns |   21368 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   838,780.0 ns |   601.99 ns |   563.10 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,417,147.1 ns | 5,111.01 ns | 4,780.84 ns |  328568 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   842,087.5 ns | 2,179.45 ns | 2,038.66 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,530,902.2 ns | 6,985.36 ns | 6,534.11 ns |  328568 B |