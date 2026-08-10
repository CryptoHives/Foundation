| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |       997.3 ns |     3.51 ns |     3.28 ns |     576 B |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     1,432.2 ns |     2.16 ns |     2.02 ns |         - |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |       986.3 ns |     2.90 ns |     2.71 ns |     576 B |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     1,392.4 ns |    24.43 ns |    22.85 ns |         - |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |     6,631.5 ns |    25.57 ns |    23.92 ns |    2816 B |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |    10,285.8 ns |    16.70 ns |    15.62 ns |         - |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |     6,472.6 ns |    25.34 ns |    23.70 ns |    2816 B |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |    10,019.4 ns |    42.54 ns |    33.21 ns |         - |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    51,051.3 ns |   128.53 ns |   107.32 ns |   20736 B |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    81,061.6 ns |   195.34 ns |   182.72 ns |         - |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    50,461.3 ns |    92.26 ns |    81.78 ns |   20736 B |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    77,783.5 ns |   271.69 ns |   254.14 ns |         - |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        |   815,945.8 ns | 1,499.09 ns | 1,402.25 ns |  327936 B |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 1,288,167.6 ns | 2,416.30 ns | 2,260.21 ns |         - |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        |   804,039.2 ns | 3,087.85 ns | 2,888.38 ns |  327936 B |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 1,267,783.9 ns | 6,593.98 ns | 6,168.01 ns |         - |