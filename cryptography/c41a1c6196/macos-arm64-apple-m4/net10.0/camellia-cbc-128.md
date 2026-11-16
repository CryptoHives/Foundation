| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     599.4 ns |     2.84 ns |     2.65 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     913.7 ns |     2.30 ns |     2.15 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     704.7 ns |     2.59 ns |     2.42 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     934.5 ns |     2.76 ns |     2.58 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,197.7 ns |    27.87 ns |    26.07 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,911.1 ns |    15.86 ns |    14.84 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   5,096.9 ns |    18.64 ns |    16.52 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,067.3 ns |     9.62 ns |     9.00 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  32,630.1 ns |   199.15 ns |   186.28 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,316.3 ns |   205.60 ns |   192.32 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  40,188.3 ns |   160.04 ns |   149.70 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  47,740.2 ns |   153.38 ns |   135.97 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 523,831.6 ns | 2,271.26 ns | 2,013.41 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 729,161.5 ns | 2,565.60 ns | 2,399.87 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 643,381.4 ns | 3,098.15 ns | 2,898.01 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 751,335.4 ns | 2,652.04 ns | 2,350.97 ns |  327936 B |