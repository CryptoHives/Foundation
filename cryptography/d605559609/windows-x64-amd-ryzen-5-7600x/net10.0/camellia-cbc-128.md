| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     596.8 ns |     3.02 ns |     2.68 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,010.4 ns |    11.28 ns |     9.42 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     609.3 ns |     3.54 ns |     3.31 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,004.3 ns |    14.78 ns |    14.52 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,158.2 ns |    17.89 ns |    16.73 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,784.1 ns |    26.12 ns |    20.39 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,215.2 ns |    20.35 ns |    18.04 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,634.1 ns |    31.44 ns |    24.54 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,144.1 ns |   150.91 ns |   141.16 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  52,602.5 ns |   206.39 ns |   193.06 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,828.5 ns |   104.17 ns |    81.33 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  51,785.7 ns |   238.27 ns |   222.88 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 535,933.1 ns | 1,838.28 ns | 1,535.05 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 841,258.8 ns | 2,651.53 ns | 2,070.14 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 531,767.8 ns | 2,765.60 ns | 2,586.94 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 827,630.9 ns | 3,722.58 ns | 3,299.97 ns |  327936 B |