| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |       904.8 ns |     3.40 ns |     3.18 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     1,301.9 ns |     3.36 ns |     2.98 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1,323.0 ns |     7.01 ns |     6.55 ns |     306 B |    1408 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |       844.4 ns |     1.86 ns |     1.74 ns |     386 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1,208.9 ns |     1.93 ns |     1.71 ns |     386 B |    1392 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     1,259.0 ns |     3.81 ns |     3.18 ns |     386 B |         - |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     5,952.1 ns |    23.16 ns |    19.34 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     6,783.1 ns |    11.15 ns |     9.31 ns |     306 B |    3648 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |     8,682.3 ns |    16.87 ns |    14.95 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     5,861.9 ns |     9.64 ns |     8.54 ns |     386 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     6,846.6 ns |    12.32 ns |    10.92 ns |     386 B |    3632 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |     8,706.4 ns |    13.39 ns |    11.18 ns |     386 B |         - |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    46,064.7 ns |    89.11 ns |    69.57 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    50,451.8 ns |   166.78 ns |   130.21 ns |     306 B |   21568 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |    69,473.3 ns |   210.96 ns |   176.16 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    46,591.4 ns |   114.41 ns |   101.42 ns |     386 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    53,723.6 ns |    85.79 ns |    76.05 ns |     386 B |   21552 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |    68,515.1 ns |   279.57 ns |   247.83 ns |     386 B |         - |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        |   743,438.9 ns |   964.79 ns |   855.26 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        |   801,993.0 ns | 1,913.91 ns | 1,598.20 ns |     306 B |  328768 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,255,538.2 ns | 2,931.55 ns | 2,598.74 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        |   802,922.6 ns | 1,545.90 ns | 1,290.90 ns |     386 B |  328752 B |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        |   939,761.3 ns |   959.47 ns |   801.20 ns |     386 B |         - |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,081,883.3 ns | 2,153.99 ns | 1,798.68 ns |     386 B |         - |