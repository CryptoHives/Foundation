| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       927.8 ns |     1.82 ns |     1.70 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,324.1 ns |     8.46 ns |     7.91 ns |    1288 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       941.6 ns |     4.68 ns |     3.91 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,240.6 ns |     7.23 ns |     6.76 ns |    1288 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,627.7 ns |     4.24 ns |     3.76 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,412.4 ns |    40.69 ns |    36.07 ns |    3528 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,779.2 ns |    12.17 ns |    10.79 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,089.4 ns |    36.20 ns |    33.86 ns |    3528 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,162.7 ns |    46.58 ns |    43.57 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   109,308.5 ns |   199.95 ns |   187.04 ns |   21448 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,727.6 ns |   693.84 ns |   649.02 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   106,426.1 ns |   272.56 ns |   241.62 ns |   21448 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   830,361.3 ns | 2,946.62 ns | 2,756.27 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,746,905.1 ns | 4,124.45 ns | 3,858.02 ns |  328648 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   855,540.8 ns |   724.33 ns |   565.51 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,719,585.5 ns | 3,806.57 ns | 3,560.67 ns |  328648 B |