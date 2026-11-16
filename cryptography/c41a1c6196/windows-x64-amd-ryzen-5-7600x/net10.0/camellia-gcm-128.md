| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |       964.8 ns |     3.23 ns |     3.03 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     1,394.3 ns |     4.47 ns |     3.96 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1,436.1 ns |     4.01 ns |     3.56 ns |     306 B |    1408 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |       899.5 ns |     2.38 ns |     1.99 ns |     386 B |         - |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     1,332.6 ns |     3.43 ns |     2.86 ns |     383 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1,341.9 ns |     3.41 ns |     3.19 ns |     383 B |    1392 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     6,411.9 ns |    11.73 ns |    10.97 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     7,478.6 ns |    18.04 ns |    16.87 ns |     306 B |    3648 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |     9,415.7 ns |    23.94 ns |    22.39 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     6,386.6 ns |     8.07 ns |     7.16 ns |     383 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     7,407.4 ns |    18.15 ns |    16.98 ns |     383 B |    3632 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |     9,274.9 ns |    14.28 ns |    11.92 ns |     383 B |         - |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    49,729.5 ns |    91.63 ns |    81.23 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    55,561.5 ns |   156.65 ns |   146.53 ns |     306 B |   21568 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |    74,102.3 ns |   876.20 ns |   819.59 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    50,085.1 ns |    96.83 ns |    85.83 ns |     383 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    55,448.9 ns |    81.13 ns |    67.74 ns |     383 B |   21552 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |    72,646.5 ns |   117.89 ns |   104.50 ns |     383 B |         - |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        |   795,605.9 ns | 1,635.31 ns | 1,529.67 ns |     306 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        |   885,015.9 ns | 1,748.76 ns | 1,550.23 ns |     306 B |  328768 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,169,088.4 ns | 4,369.39 ns | 3,648.64 ns |     306 B |         - |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        |   804,969.5 ns | 2,278.32 ns | 2,131.14 ns |     383 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        |   882,853.4 ns | 2,249.42 ns | 1,994.05 ns |     383 B |  328752 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,166,442.9 ns | 3,185.33 ns | 2,979.56 ns |     383 B |         - |