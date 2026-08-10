| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     572.1 ns |     3.05 ns |     2.54 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,059.4 ns |     1.80 ns |     1.51 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     609.1 ns |     0.74 ns |     0.65 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,031.0 ns |     1.18 ns |     0.98 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,071.7 ns |     4.21 ns |     3.51 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,771.5 ns |     8.97 ns |     7.49 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,261.9 ns |     7.83 ns |     6.11 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,701.1 ns |     7.49 ns |     7.00 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  32,642.9 ns |    42.31 ns |    37.51 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  52,593.0 ns |    85.84 ns |    71.68 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,687.6 ns |    68.51 ns |    57.21 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  52,035.0 ns |   124.37 ns |   103.86 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 527,990.4 ns |   634.18 ns |   593.21 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 838,826.8 ns | 1,491.24 ns | 1,245.26 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 535,373.5 ns |   592.31 ns |   525.07 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 830,353.8 ns | 1,370.91 ns | 1,144.77 ns |  327936 B |