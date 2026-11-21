| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     609.0 ns |     3.35 ns |     3.13 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     884.6 ns |     1.66 ns |     1.55 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     706.1 ns |     2.78 ns |     2.60 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     888.7 ns |     2.73 ns |     2.42 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,222.4 ns |    27.03 ns |    25.28 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,609.3 ns |    12.86 ns |    11.40 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   5,118.3 ns |    22.84 ns |    21.37 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,767.3 ns |    15.77 ns |    13.98 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,257.3 ns |   208.64 ns |   184.96 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  44,004.1 ns |   157.13 ns |   131.21 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  40,265.2 ns |   150.67 ns |   125.82 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  44,847.2 ns |   125.21 ns |   111.00 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 533,968.1 ns | 2,864.49 ns | 2,539.29 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 693,041.4 ns | 2,233.09 ns | 2,088.84 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 645,335.2 ns | 2,333.87 ns | 2,183.10 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 716,713.6 ns | 2,023.74 ns | 1,793.99 ns |  327936 B |