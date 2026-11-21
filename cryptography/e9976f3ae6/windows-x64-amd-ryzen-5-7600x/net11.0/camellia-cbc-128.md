| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     693.2 ns |     0.73 ns |     0.65 ns |  10,332 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,156.8 ns |     5.54 ns |     5.19 ns |   7,729 B |     576 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     712.1 ns |     1.20 ns |     1.07 ns |  10,332 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,061.1 ns |     2.28 ns |     2.02 ns |   7,734 B |     576 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,771.8 ns |     4.98 ns |     4.41 ns |  10,332 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   7,134.2 ns |    48.40 ns |    45.28 ns |  13,883 B |    2816 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   5,024.4 ns |    10.42 ns |     9.24 ns |  10,737 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,983.3 ns |    12.60 ns |    11.17 ns |   7,734 B |    2816 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  37,775.7 ns |    60.69 ns |    53.80 ns |   3,997 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  55,381.8 ns |    97.02 ns |    86.00 ns |  13,693 B |   20736 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  39,621.2 ns |   154.16 ns |   136.66 ns |   3,997 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  55,446.7 ns |   108.19 ns |    95.91 ns |   7,738 B |   20736 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 606,418.8 ns | 2,816.27 ns | 2,634.34 ns |   3,997 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 892,194.9 ns | 2,118.99 ns | 1,878.43 ns |   7,729 B |  327936 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 630,102.4 ns |   681.38 ns |   568.98 ns |   3,997 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 899,966.3 ns | 3,420.70 ns | 3,032.36 ns |  13,688 B |  327936 B |