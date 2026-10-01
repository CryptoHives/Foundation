| Description                                 | TestDataSize | Mean           | Error       | StdDev    | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       944.6 ns |     0.39 ns |   0.36 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,220.1 ns |     1.01 ns |   0.90 ns |    1208 B |
|                                             |              |                |             |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       950.1 ns |     0.32 ns |   0.28 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,108.7 ns |     0.90 ns |   0.80 ns |    1208 B |
|                                             |              |                |             |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,712.8 ns |     1.65 ns |   1.54 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    14,079.4 ns |     5.66 ns |   5.30 ns |    3448 B |
|                                             |              |                |             |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,753.4 ns |     1.05 ns |   0.93 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    13,138.1 ns |     6.31 ns |   5.59 ns |    3448 B |
|                                             |              |                |             |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,869.3 ns |    22.05 ns |  20.63 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   104,041.6 ns |    37.32 ns |  34.91 ns |   21368 B |
|                                             |              |                |             |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    53,130.8 ns |    11.27 ns |   9.41 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   101,431.0 ns |    36.62 ns |  34.26 ns |   21368 B |
|                                             |              |                |             |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   845,442.2 ns |   239.00 ns | 211.87 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,664,172.9 ns | 1,062.43 ns | 993.79 ns |  328568 B |
|                                             |              |                |             |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   849,354.6 ns |   481.49 ns | 426.82 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,617,310.8 ns |   867.79 ns | 769.27 ns |  328568 B |