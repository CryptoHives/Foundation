| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       763.4 ns |     0.48 ns |     0.40 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,267.2 ns |     1.64 ns |     1.37 ns |     592 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       815.7 ns |     1.05 ns |     0.93 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,306.7 ns |     1.42 ns |     1.26 ns |     592 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,349.4 ns |     8.27 ns |     7.33 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,386.7 ns |    12.94 ns |    10.80 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,708.9 ns |     8.03 ns |     7.12 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,284.2 ns |     9.56 ns |     8.94 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    43,093.4 ns |    52.50 ns |    46.54 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    65,804.9 ns |   169.67 ns |   141.68 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    44,978.7 ns |   116.48 ns |   108.96 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    66,098.2 ns |   102.88 ns |    85.91 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   700,271.0 ns | 1,685.08 ns | 1,493.78 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,051,202.3 ns | 2,110.87 ns | 1,871.24 ns |  327952 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   728,863.9 ns | 1,232.06 ns | 1,092.18 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,033,551.0 ns | 2,375.47 ns | 2,105.79 ns |  327952 B |