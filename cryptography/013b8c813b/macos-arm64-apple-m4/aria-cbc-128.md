| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       958.3 ns |     0.49 ns |     0.46 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,318.5 ns |     3.77 ns |     3.52 ns |    1288 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       946.6 ns |     0.77 ns |     0.72 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,288.5 ns |     2.53 ns |     2.37 ns |    1288 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,826.1 ns |     2.07 ns |     1.94 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,379.9 ns |    12.43 ns |    11.62 ns |    3528 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,725.6 ns |     5.58 ns |     4.95 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,226.7 ns |    16.83 ns |    14.92 ns |    3528 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    53,723.8 ns |    29.76 ns |    26.38 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   109,051.1 ns |    97.10 ns |    90.83 ns |   21448 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,950.2 ns |    49.63 ns |    46.43 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   107,770.1 ns |    83.51 ns |    74.03 ns |   21448 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   858,530.5 ns |   632.22 ns |   560.44 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,737,366.2 ns | 1,931.29 ns | 1,806.53 ns |  328648 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   846,237.7 ns |   659.66 ns |   584.77 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,711,333.4 ns | 1,698.98 ns | 1,589.23 ns |  328648 B |