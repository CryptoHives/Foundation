| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     848.1 ns |     1.13 ns |     1.00 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,208.7 ns |     1.51 ns |     1.42 ns |     584 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     924.9 ns |     1.84 ns |     1.72 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,174.7 ns |     1.03 ns |     0.81 ns |     584 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,022.9 ns |     4.84 ns |     4.52 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,671.6 ns |    25.68 ns |    24.02 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,689.0 ns |    17.39 ns |    16.27 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,782.0 ns |    12.97 ns |    12.13 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  47,477.0 ns |   107.28 ns |   100.35 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  61,759.7 ns |    67.73 ns |    63.36 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  52,839.7 ns |   125.42 ns |   117.31 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,699.6 ns |   222.27 ns |   207.92 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 760,707.9 ns |   709.54 ns |   663.71 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 946,665.3 ns | 2,898.72 ns | 2,711.47 ns |  327944 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 844,602.8 ns | 2,017.84 ns | 1,887.49 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 948,702.3 ns | 3,014.06 ns | 2,819.36 ns |  327944 B |