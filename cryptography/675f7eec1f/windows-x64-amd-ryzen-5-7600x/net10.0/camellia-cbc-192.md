| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       761.6 ns |     4.15 ns |     3.88 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,293.1 ns |    12.85 ns |    12.02 ns |     584 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       813.2 ns |     3.28 ns |     2.91 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,253.4 ns |     8.53 ns |     7.98 ns |     584 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,359.2 ns |    21.19 ns |    19.82 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    10,191.1 ns |    38.41 ns |    34.05 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,763.9 ns |    15.09 ns |    13.38 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,284.1 ns |    36.17 ns |    32.06 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    43,262.6 ns |   240.82 ns |   225.27 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    65,348.4 ns |   331.47 ns |   310.05 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    44,833.9 ns |   149.04 ns |   132.12 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    64,733.1 ns |   591.87 ns |   524.67 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   698,017.1 ns | 2,453.84 ns | 2,175.27 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,037,964.4 ns | 6,521.33 ns | 5,780.99 ns |  327944 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   716,419.8 ns | 2,480.73 ns | 2,071.52 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,027,493.4 ns | 5,834.68 ns | 4,872.22 ns |  327944 B |