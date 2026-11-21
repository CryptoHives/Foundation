| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     854.1 ns |     1.63 ns |     1.52 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,127.1 ns |     4.28 ns |     4.00 ns |     584 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     954.8 ns |     8.25 ns |     7.71 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,135.7 ns |     5.53 ns |     5.17 ns |     584 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   5,950.2 ns |    25.86 ns |    24.19 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,424.1 ns |    20.31 ns |    19.00 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,816.9 ns |    17.24 ns |    16.13 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,951.2 ns |    49.95 ns |    46.73 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  46,635.0 ns |   169.48 ns |   158.53 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  57,051.3 ns |   141.88 ns |   132.72 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  53,852.8 ns |   133.14 ns |   124.54 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  58,200.4 ns |   123.40 ns |   115.43 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 749,301.8 ns | 2,241.74 ns | 2,096.92 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 905,895.2 ns | 1,967.10 ns | 1,840.03 ns |  327944 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 862,484.5 ns | 3,379.75 ns | 3,161.42 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 929,570.7 ns | 2,256.22 ns | 2,110.47 ns |  327944 B |