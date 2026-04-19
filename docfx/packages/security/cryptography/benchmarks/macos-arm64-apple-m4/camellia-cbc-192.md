| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     833.0 ns |     3.68 ns |     2.87 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,199.2 ns |     2.48 ns |     1.93 ns |     584 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     914.9 ns |     9.90 ns |     8.77 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,169.8 ns |     7.65 ns |     6.38 ns |     584 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   5,899.5 ns |    41.86 ns |    37.11 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,900.9 ns |    92.02 ns |    81.58 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,563.5 ns |    47.01 ns |    41.68 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,682.9 ns |    29.80 ns |    24.89 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  46,299.1 ns |   305.23 ns |   285.51 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,341.8 ns |   335.93 ns |   297.79 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  51,714.5 ns |   410.36 ns |   363.77 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,750.9 ns |   863.56 ns |   765.52 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 744,326.9 ns | 3,660.35 ns | 3,056.56 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 944,916.0 ns | 6,715.11 ns | 5,952.77 ns |  327944 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 825,813.1 ns | 3,981.76 ns | 3,724.54 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 945,858.6 ns | 1,782.26 ns | 1,667.13 ns |  327944 B |