| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |     275.4 ns |     0.46 ns |     0.43 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |   1,198.4 ns |     2.98 ns |     2.64 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |   1,521.4 ns |    11.46 ns |     9.57 ns |     306 B |    2992 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |     219.5 ns |     0.19 ns |     0.17 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |   1,139.1 ns |     2.32 ns |     2.06 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |   1,381.6 ns |     3.41 ns |     2.85 ns |     386 B |    2544 B |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     803.2 ns |     0.52 ns |     0.46 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |   6,248.2 ns |    11.64 ns |     9.72 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |   6,784.1 ns |    24.41 ns |    21.64 ns |     306 B |    7416 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     748.2 ns |     0.51 ns |     0.43 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |   6,159.7 ns |    15.99 ns |    14.17 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |   6,236.2 ns |    15.02 ns |    12.55 ns |     383 B |    3312 B |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |   5,058.8 ns |     5.41 ns |     4.22 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |  46,724.7 ns |   114.77 ns |   101.74 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |  48,739.4 ns |   211.34 ns |   187.34 ns |     306 B |   43328 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |   5,009.3 ns |     7.02 ns |     6.56 ns |     383 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |  44,975.0 ns |   184.04 ns |   172.16 ns |     383 B |   10480 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |  46,253.3 ns |   139.19 ns |   123.39 ns |     383 B |         - |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |  78,196.9 ns |    81.78 ns |    76.50 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 739,419.0 ns | 1,209.02 ns | 1,071.77 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 887,884.2 ns | 2,647.44 ns | 2,476.42 ns |     306 B |  657936 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |  78,290.3 ns |   172.93 ns |   153.30 ns |     383 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 734,274.6 ns | 3,421.70 ns | 3,033.25 ns |     383 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 740,437.5 ns | 2,350.45 ns | 2,083.61 ns |     383 B |  133388 B |