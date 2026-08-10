| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       965.0 ns |     1.58 ns |     1.47 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,341.3 ns |     5.09 ns |     4.76 ns |    1288 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       952.1 ns |     2.31 ns |     2.16 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,292.6 ns |     6.34 ns |     5.93 ns |    1288 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,873.9 ns |     4.16 ns |     3.89 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,546.6 ns |    17.30 ns |    16.18 ns |    3528 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,770.8 ns |    11.48 ns |    10.74 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,187.4 ns |    28.67 ns |    26.82 ns |    3528 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    54,105.5 ns |    25.86 ns |    24.19 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   110,141.2 ns |   299.33 ns |   265.34 ns |   21448 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    53,277.0 ns |    35.25 ns |    29.44 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   109,552.2 ns |   280.82 ns |   262.68 ns |   21448 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   863,730.5 ns | 1,632.20 ns | 1,526.76 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,753,706.8 ns |   891.25 ns |   833.68 ns |  328648 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   850,690.0 ns |   555.79 ns |   519.89 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,724,458.6 ns | 3,909.43 ns | 3,656.88 ns |  328648 B |