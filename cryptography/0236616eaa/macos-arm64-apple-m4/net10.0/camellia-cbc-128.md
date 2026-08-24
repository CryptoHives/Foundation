| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     602.0 ns |     0.25 ns |     0.23 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     911.0 ns |     0.24 ns |     0.22 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     679.6 ns |     0.63 ns |     0.56 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     941.2 ns |     0.42 ns |     0.38 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,231.5 ns |     0.93 ns |     0.77 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,941.1 ns |     7.92 ns |     7.41 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,933.2 ns |     2.13 ns |     2.00 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,181.8 ns |    44.42 ns |    37.09 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,511.0 ns |    10.72 ns |    10.03 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,610.4 ns |    95.03 ns |    88.89 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  37,692.9 ns |   186.61 ns |   174.55 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  47,222.3 ns |    66.87 ns |    55.84 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 537,425.9 ns |   385.03 ns |   360.16 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 735,470.1 ns | 2,558.70 ns | 2,393.41 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 615,074.6 ns | 1,922.79 ns | 1,798.58 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 757,100.1 ns | 1,353.12 ns | 1,265.71 ns |  327936 B |