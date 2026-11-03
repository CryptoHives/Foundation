| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |       949.7 ns |     2.25 ns |     2.00 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     1,384.6 ns |     2.21 ns |     2.07 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1,458.2 ns |     4.44 ns |     3.94 ns |     306 B |    1408 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |       902.6 ns |     1.17 ns |     0.98 ns |     383 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1,323.5 ns |     6.48 ns |     6.06 ns |     383 B |    1392 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     1,345.7 ns |     3.04 ns |     2.84 ns |     383 B |         - |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     6,365.4 ns |     8.85 ns |     7.39 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     7,513.1 ns |    18.68 ns |    17.48 ns |     306 B |    3648 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |     9,371.0 ns |    29.55 ns |    27.64 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     6,362.4 ns |    12.49 ns |    11.68 ns |     383 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     7,381.8 ns |    17.77 ns |    16.62 ns |     383 B |    3632 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |     9,347.8 ns |    21.51 ns |    19.07 ns |     386 B |         - |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    55,734.8 ns |    75.30 ns |    70.44 ns |     306 B |   21568 B |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    67,645.6 ns |   253.72 ns |   224.92 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |    73,088.8 ns |   155.00 ns |   137.40 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    50,408.1 ns |   111.73 ns |    99.05 ns |     383 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    55,754.5 ns |   152.63 ns |   119.17 ns |     383 B |   21552 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |    73,468.2 ns |   333.37 ns |   295.52 ns |     383 B |         - |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        |   806,379.6 ns | 2,410.73 ns | 2,137.05 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        |   888,261.7 ns | 2,029.01 ns | 1,798.66 ns |     306 B |  328768 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,190,698.5 ns | 2,378.49 ns | 2,224.84 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        |   812,806.7 ns | 5,698.96 ns | 5,051.98 ns |     383 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        |   894,600.8 ns | 6,989.07 ns | 5,836.19 ns |     383 B |  328752 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,164,832.4 ns | 5,350.78 ns | 5,005.12 ns |     383 B |         - |