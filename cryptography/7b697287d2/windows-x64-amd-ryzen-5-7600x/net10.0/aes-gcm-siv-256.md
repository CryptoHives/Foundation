| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       344.0 ns |     0.40 ns |     0.37 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,511.5 ns |     4.68 ns |     4.38 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     1,953.9 ns |    15.62 ns |    14.61 ns |     306 B |    3408 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       296.1 ns |     0.35 ns |     0.33 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,448.5 ns |     4.22 ns |     3.94 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128B         |     1,845.8 ns |     4.99 ns |     4.67 ns |     383 B |    2960 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |       976.0 ns |     1.89 ns |     1.77 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     7,351.2 ns |    14.26 ns |    12.64 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |     8,322.5 ns |    44.47 ns |    37.13 ns |     306 B |    7832 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |       934.4 ns |     0.75 ns |     0.70 ns |     386 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     7,254.9 ns |    17.24 ns |    16.13 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 1KB          |     7,784.0 ns |    53.97 ns |    50.48 ns |     383 B |    3728 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     6,065.5 ns |    11.61 ns |    10.86 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    54,030.4 ns |   107.66 ns |   100.71 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |    58,552.0 ns |   184.53 ns |   172.61 ns |     306 B |   43744 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     6,021.6 ns |     5.16 ns |     4.57 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    53,675.4 ns |   112.88 ns |   105.58 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 8KB          |    54,612.5 ns |   124.95 ns |   110.77 ns |     383 B |   10896 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |    93,518.9 ns |   149.15 ns |   124.55 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        |   857,281.6 ns | 1,927.78 ns | 1,803.25 ns |     306 B |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        | 1,034,292.2 ns | 2,727.76 ns | 2,418.09 ns |     306 B |  658352 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |    93,722.4 ns |   140.57 ns |   124.61 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)        | 128KB        |   849,618.2 ns | 1,751.91 ns | 1,553.02 ns |     383 B |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)              | 128KB        |   889,406.0 ns | 2,211.70 ns | 1,960.61 ns |     383 B |  133804 B |