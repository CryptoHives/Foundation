| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     566.5 ns |     2.22 ns |     2.07 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     995.1 ns |     4.99 ns |     4.42 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     600.3 ns |     3.19 ns |     2.98 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     986.2 ns |     6.86 ns |     6.42 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,001.3 ns |    13.47 ns |    12.60 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,649.7 ns |    38.06 ns |    35.60 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,334.0 ns |    18.19 ns |    16.12 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,590.2 ns |    27.58 ns |    25.79 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  31,621.3 ns |   142.33 ns |   133.14 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  52,054.5 ns |   257.42 ns |   228.19 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,159.8 ns |   162.49 ns |   144.05 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  51,749.3 ns |   231.73 ns |   205.43 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 521,918.4 ns | 3,503.98 ns | 3,277.63 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 826,601.1 ns | 6,209.07 ns | 5,807.97 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 527,699.2 ns | 1,302.15 ns | 1,087.36 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 816,162.9 ns | 3,551.86 ns | 3,322.41 ns |  327936 B |