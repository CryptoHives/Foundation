| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     833.8 ns |     2.52 ns |     2.35 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,172.6 ns |     1.72 ns |     1.43 ns |     584 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     904.4 ns |     2.62 ns |     2.45 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,161.1 ns |     1.72 ns |     1.43 ns |     584 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   5,911.4 ns |    19.87 ns |    18.59 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,758.0 ns |    22.35 ns |    20.90 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,553.3 ns |    18.80 ns |    17.59 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,684.5 ns |    20.72 ns |    19.38 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  46,522.7 ns |   210.47 ns |   196.88 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  58,978.4 ns |   111.82 ns |   104.59 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  51,760.9 ns |   163.27 ns |   152.73 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,022.8 ns |   122.71 ns |   114.79 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 746,835.2 ns | 2,694.70 ns | 2,520.62 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 960,669.0 ns | 1,932.63 ns | 1,807.79 ns |  327944 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 827,563.7 ns | 1,884.17 ns | 1,762.46 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 943,068.4 ns | 1,699.03 ns | 1,589.27 ns |  327944 B |