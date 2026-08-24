| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     572.1 ns |     0.96 ns |     0.85 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,014.0 ns |     4.18 ns |     3.71 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     610.3 ns |     1.32 ns |     1.17 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     996.8 ns |     2.64 ns |     2.21 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   3,986.4 ns |     9.88 ns |     8.25 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,817.9 ns |    17.57 ns |    14.67 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,336.5 ns |     7.87 ns |     6.57 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,671.8 ns |    19.28 ns |    17.09 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  31,328.7 ns |    63.01 ns |    55.86 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  53,323.0 ns |    64.79 ns |    54.10 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,653.6 ns |    65.06 ns |    57.67 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  52,061.8 ns |   186.02 ns |   164.91 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 526,229.0 ns |   701.27 ns |   655.97 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 841,190.2 ns | 2,239.54 ns | 1,985.29 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 691,576.7 ns |   685.85 ns |   641.54 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 830,416.6 ns | 2,617.16 ns | 2,320.05 ns |  327936 B |