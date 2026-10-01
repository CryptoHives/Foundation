| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     604.7 ns |     1.01 ns |     0.95 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     918.8 ns |     2.28 ns |     2.13 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     686.6 ns |     1.88 ns |     1.76 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     942.9 ns |     1.74 ns |     1.45 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,250.6 ns |    14.43 ns |    13.50 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,974.3 ns |    23.70 ns |    21.01 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,970.9 ns |    14.62 ns |    12.96 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,497.9 ns |    20.17 ns |    18.87 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,688.5 ns |   121.03 ns |   113.21 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,930.1 ns |    85.98 ns |    80.43 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  39,163.5 ns |   153.78 ns |   143.85 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  47,885.9 ns |   193.06 ns |   171.14 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 534,662.8 ns |   632.66 ns |   528.30 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 731,014.7 ns | 2,494.20 ns | 2,333.07 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 625,184.1 ns | 2,178.18 ns | 2,037.47 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 763,209.0 ns | 2,109.90 ns | 1,973.61 ns |  327936 B |