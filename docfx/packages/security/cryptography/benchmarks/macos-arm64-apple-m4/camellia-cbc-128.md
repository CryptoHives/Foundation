| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     598.5 ns |     1.47 ns |     1.38 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     906.8 ns |     1.01 ns |     0.89 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     673.3 ns |     2.23 ns |     2.09 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     904.5 ns |     0.51 ns |     0.45 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,200.5 ns |    10.74 ns |    10.05 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,836.6 ns |     8.20 ns |     7.67 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,857.5 ns |    19.59 ns |    18.32 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,963.2 ns |     5.24 ns |     4.90 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  32,856.6 ns |    74.97 ns |    70.13 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,646.8 ns |    89.82 ns |    84.02 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  38,335.1 ns |   147.68 ns |   138.14 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  46,472.3 ns |    38.64 ns |    34.26 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 532,346.2 ns | 1,223.48 ns | 1,084.58 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 717,414.6 ns | 1,660.09 ns | 1,552.85 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 613,741.2 ns | 2,961.91 ns | 2,770.57 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 726,129.0 ns | 1,504.58 ns | 1,333.77 ns |  327936 B |