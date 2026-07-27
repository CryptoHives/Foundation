| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     606.7 ns |     0.38 ns |     0.35 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     911.6 ns |     1.89 ns |     1.77 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     684.1 ns |     1.48 ns |     1.39 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     917.0 ns |     0.53 ns |     0.50 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,259.1 ns |     3.59 ns |     3.36 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,895.9 ns |     4.80 ns |     4.49 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,958.9 ns |     6.74 ns |     6.30 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,997.6 ns |    12.80 ns |    11.35 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,311.9 ns |    76.30 ns |    71.38 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  47,899.1 ns |   108.89 ns |   101.85 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  39,138.3 ns |    94.19 ns |    88.10 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  46,110.9 ns |   131.17 ns |   122.70 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 540,112.7 ns |   540.04 ns |   505.16 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 724,262.9 ns | 2,148.84 ns | 2,010.03 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 625,513.4 ns | 1,406.45 ns | 1,315.60 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 731,005.8 ns | 2,174.42 ns | 2,033.96 ns |  327936 B |