| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       761.1 ns |     1.76 ns |     1.56 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,233.4 ns |     6.74 ns |     5.62 ns |     584 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       794.4 ns |     0.57 ns |     0.44 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,233.1 ns |     4.15 ns |     3.68 ns |     584 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,357.5 ns |    15.35 ns |    14.36 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,213.6 ns |    44.53 ns |    41.66 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,601.4 ns |    12.34 ns |    10.94 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,120.3 ns |    59.18 ns |    55.36 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    43,069.6 ns |   136.11 ns |   113.66 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    63,971.7 ns |   362.27 ns |   338.87 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    44,457.5 ns |   163.77 ns |   153.19 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    63,345.8 ns |   534.75 ns |   446.54 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   694,795.2 ns | 1,815.37 ns | 1,609.28 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,019,544.0 ns | 3,272.99 ns | 2,733.09 ns |  327944 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   737,488.5 ns | 2,697.29 ns | 2,523.04 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,009,565.8 ns | 6,176.17 ns | 5,777.20 ns |  327944 B |