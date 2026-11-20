| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     2,078.1 ns |     3.27 ns |     3.06 ns |  10,553 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     6,328.3 ns |    17.98 ns |    15.93 ns |  13,735 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       898.1 ns |     2.41 ns |     2.25 ns |  10,553 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,106.1 ns |     8.33 ns |     7.39 ns |  13,925 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    14,242.9 ns |     9.83 ns |     9.19 ns |  10,743 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    37,991.9 ns |    28.96 ns |    25.67 ns |  13,735 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     6,152.9 ns |    10.90 ns |     9.66 ns |  10,553 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    16,316.4 ns |   178.78 ns |   167.23 ns |  13,925 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |   111,919.5 ns |    95.67 ns |    89.49 ns |   4,218 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   291,665.1 ns |   359.96 ns |   300.58 ns |  13,925 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    48,171.7 ns |    91.81 ns |    81.39 ns |  10,743 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   120,709.1 ns |   311.39 ns |   276.04 ns |  13,925 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,788,778.0 ns | 1,167.83 ns | 1,035.25 ns |  10,958 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 4,449,358.0 ns | 7,371.28 ns | 6,534.45 ns |  13,737 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   764,327.8 ns | 1,476.36 ns | 1,308.75 ns |  10,553 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,985,192.8 ns | 6,062.28 ns | 5,374.05 ns |   7,778 B |    1112 B |