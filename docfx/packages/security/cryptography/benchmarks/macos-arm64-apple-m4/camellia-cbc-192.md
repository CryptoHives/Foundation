| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     820.7 ns |     2.38 ns |     2.23 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,188.6 ns |     3.76 ns |     3.52 ns |     584 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     885.3 ns |     2.39 ns |     2.23 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,156.7 ns |     4.04 ns |     3.77 ns |     584 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   5,834.2 ns |    25.49 ns |    23.85 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,798.0 ns |    47.11 ns |    44.06 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,427.0 ns |    20.27 ns |    18.96 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,745.4 ns |    43.40 ns |    40.59 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  45,869.3 ns |   195.60 ns |   182.96 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  58,656.9 ns |   152.55 ns |   135.23 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  51,318.2 ns |   116.53 ns |   109.00 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,060.5 ns |   207.52 ns |   194.12 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 736,722.4 ns | 3,650.15 ns | 3,414.35 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 937,658.5 ns | 1,999.75 ns | 1,870.56 ns |  327944 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 812,382.3 ns | 2,779.24 ns | 2,599.71 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 938,201.8 ns | 3,448.62 ns | 3,225.84 ns |  327944 B |