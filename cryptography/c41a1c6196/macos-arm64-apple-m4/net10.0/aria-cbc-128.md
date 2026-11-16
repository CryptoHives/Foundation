| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       937.5 ns |     0.66 ns |     0.61 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,170.8 ns |    11.13 ns |    10.41 ns |    1208 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       940.8 ns |     1.42 ns |     1.33 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,087.8 ns |     8.54 ns |     7.99 ns |    1208 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,659.0 ns |     4.77 ns |     4.47 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    13,159.3 ns |    47.13 ns |    44.08 ns |    3448 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,698.4 ns |     7.19 ns |     6.72 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    12,882.8 ns |    24.66 ns |    21.86 ns |    3448 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,387.4 ns |    83.40 ns |    73.93 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   102,144.5 ns |   268.67 ns |   238.17 ns |   21368 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    53,116.4 ns |   844.91 ns |   748.99 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |    99,413.6 ns |   281.10 ns |   249.19 ns |   21368 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   837,255.8 ns | 1,209.34 ns | 1,131.21 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,630,120.4 ns | 4,849.16 ns | 4,535.91 ns |  328568 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   841,406.3 ns |   616.31 ns |   576.50 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,578,839.0 ns | 2,813.23 ns | 2,631.50 ns |  328568 B |