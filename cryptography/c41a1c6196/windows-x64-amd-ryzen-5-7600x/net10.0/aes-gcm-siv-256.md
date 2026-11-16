| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       338.9 ns |     0.73 ns |     0.68 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,505.9 ns |     3.28 ns |     2.74 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     1,924.0 ns |     6.63 ns |     5.88 ns |     306 B |    3408 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       295.0 ns |     0.36 ns |     0.32 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,447.7 ns |     3.22 ns |     2.85 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     1,846.5 ns |    10.43 ns |     9.75 ns |     386 B |    2960 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |       977.9 ns |     1.15 ns |     1.02 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     7,329.7 ns |    14.76 ns |    13.08 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |     8,224.1 ns |    44.28 ns |    41.41 ns |     306 B |    7832 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |       935.0 ns |     1.18 ns |     0.92 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     7,234.9 ns |    10.72 ns |    10.03 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |     7,699.9 ns |    34.34 ns |    28.68 ns |     383 B |    3728 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     6,097.3 ns |    10.42 ns |     9.24 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    53,851.5 ns |   107.93 ns |    95.67 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |    58,145.4 ns |   224.57 ns |   187.53 ns |     306 B |   43744 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     6,055.9 ns |     8.41 ns |     7.46 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    53,680.4 ns |   247.09 ns |   231.13 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |    54,328.0 ns |   276.19 ns |   244.84 ns |     383 B |   10896 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |    93,690.5 ns |   100.93 ns |    84.28 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        |   852,508.9 ns |   994.82 ns |   776.69 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,037,976.4 ns | 4,482.38 ns | 4,192.83 ns |     306 B |  658352 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |    93,974.0 ns |   149.50 ns |   139.84 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        |   847,687.8 ns | 2,934.00 ns | 2,600.92 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        |   886,782.9 ns | 2,535.97 ns | 2,248.07 ns |     383 B |  133804 B |