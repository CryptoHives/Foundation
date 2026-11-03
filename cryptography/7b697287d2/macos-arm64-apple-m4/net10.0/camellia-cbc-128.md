| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     590.2 ns |     2.01 ns |     1.88 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     903.6 ns |     2.80 ns |     2.62 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     693.8 ns |     2.39 ns |     2.24 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     922.4 ns |     2.54 ns |     2.37 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,147.7 ns |    17.79 ns |    16.64 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,845.4 ns |    23.57 ns |    22.05 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   5,030.1 ns |    17.53 ns |    15.54 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,090.2 ns |    22.19 ns |    20.76 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  32,525.4 ns |   169.82 ns |   158.85 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,382.1 ns |   162.90 ns |   152.38 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  39,788.2 ns |   201.06 ns |   188.07 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  47,050.6 ns |   256.39 ns |   239.83 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 519,582.1 ns | 2,092.30 ns | 1,957.14 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 727,246.9 ns | 4,110.63 ns | 3,845.09 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 636,317.2 ns | 2,046.13 ns | 1,913.95 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 742,771.7 ns | 4,098.53 ns | 3,833.76 ns |  327936 B |