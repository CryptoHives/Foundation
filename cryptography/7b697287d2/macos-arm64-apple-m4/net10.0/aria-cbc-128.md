| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       933.3 ns |     0.74 ns |     0.70 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,134.3 ns |     7.74 ns |     7.24 ns |    1208 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       933.7 ns |     0.35 ns |     0.32 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,056.4 ns |     6.37 ns |     5.96 ns |    1208 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,675.4 ns |     2.82 ns |     2.64 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    13,012.9 ns |    27.81 ns |    26.01 ns |    3448 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,637.6 ns |     3.91 ns |     3.66 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    12,698.9 ns |    29.47 ns |    27.57 ns |    3448 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,408.7 ns |    33.10 ns |    30.96 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   101,061.3 ns |   276.81 ns |   258.93 ns |   21368 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,209.8 ns |    32.33 ns |    25.24 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |    96,696.9 ns |   302.57 ns |   268.22 ns |   21368 B |
|                                             |              |                |             |             |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   840,100.7 ns | 1,014.06 ns |   948.55 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,606,410.3 ns | 4,411.91 ns | 4,126.90 ns |  328568 B |
|                                             |              |                |             |             |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   834,431.4 ns |   293.00 ns |   274.08 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,553,994.7 ns | 4,985.69 ns | 4,663.62 ns |  328568 B |