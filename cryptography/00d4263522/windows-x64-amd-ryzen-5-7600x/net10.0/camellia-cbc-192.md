| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       753.0 ns |     1.91 ns |     1.79 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,243.6 ns |     4.67 ns |     4.14 ns |     584 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       813.1 ns |     2.30 ns |     1.92 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,230.8 ns |     7.14 ns |     6.68 ns |     584 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,539.1 ns |     5.58 ns |     4.35 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,300.1 ns |    51.84 ns |    48.49 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,647.6 ns |    32.56 ns |    30.45 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,172.0 ns |    24.38 ns |    20.36 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    43,559.3 ns |   107.00 ns |   100.08 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    64,982.0 ns |   261.75 ns |   244.85 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    44,532.6 ns |   203.72 ns |   190.56 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    64,504.1 ns |   290.65 ns |   257.65 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   690,835.3 ns | 1,544.30 ns | 1,289.56 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,032,497.2 ns | 5,137.29 ns | 4,554.08 ns |  327944 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   714,146.0 ns | 4,694.08 ns | 4,390.84 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,020,540.8 ns | 5,663.75 ns | 5,020.77 ns |  327944 B |