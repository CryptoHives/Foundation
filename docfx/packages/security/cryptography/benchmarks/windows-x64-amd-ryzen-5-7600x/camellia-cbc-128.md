| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     576.3 ns |     4.21 ns |     3.93 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,021.3 ns |     7.98 ns |     7.47 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     608.0 ns |     3.55 ns |     3.32 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,018.1 ns |    12.59 ns |    11.16 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   3,982.2 ns |    19.45 ns |    17.25 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,704.2 ns |    28.70 ns |    23.97 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,250.4 ns |    20.99 ns |    19.64 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,608.4 ns |    33.29 ns |    27.80 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  31,283.4 ns |    78.64 ns |    65.67 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  52,479.0 ns |   312.84 ns |   292.63 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,407.9 ns |   137.74 ns |   122.10 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  51,600.3 ns |   188.47 ns |   157.38 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 523,487.8 ns | 2,817.49 ns | 2,635.48 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 834,532.3 ns | 4,129.68 ns | 3,660.85 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 537,710.3 ns | 3,771.08 ns | 3,527.47 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 830,027.3 ns | 4,185.23 ns | 3,710.10 ns |  327936 B |