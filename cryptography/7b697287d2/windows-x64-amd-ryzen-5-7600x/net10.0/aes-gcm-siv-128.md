| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |     270.0 ns |     0.69 ns |     0.64 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |   1,198.1 ns |     4.80 ns |     4.49 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |   1,511.3 ns |     6.37 ns |     5.96 ns |     306 B |    2992 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |     218.7 ns |     0.14 ns |     0.12 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |   1,139.5 ns |     2.24 ns |     1.98 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |   1,440.7 ns |    24.91 ns |    22.08 ns |     383 B |    2544 B |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     798.8 ns |     0.80 ns |     0.71 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |   6,284.7 ns |    18.47 ns |    17.28 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |   6,929.2 ns |    24.91 ns |    22.08 ns |     306 B |    7416 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     750.4 ns |     0.48 ns |     0.40 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |   6,154.1 ns |    12.16 ns |    10.15 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |   6,298.4 ns |    23.18 ns |    20.55 ns |     383 B |    3312 B |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |   5,020.2 ns |     5.50 ns |     4.87 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |  46,707.5 ns |   144.55 ns |   128.14 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |  49,273.6 ns |   180.00 ns |   168.37 ns |     306 B |   43328 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |   4,978.6 ns |     6.26 ns |     5.86 ns |     383 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |  45,187.1 ns |   138.16 ns |   122.48 ns |     383 B |   10480 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |  46,458.1 ns |   183.72 ns |   171.85 ns |     383 B |         - |
|                                                       |              |              |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |  78,253.3 ns |   130.99 ns |   122.53 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 740,862.8 ns | 1,723.49 ns | 1,612.15 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 892,635.5 ns | 2,933.82 ns | 2,744.30 ns |     306 B |  657936 B |
|                                                       |              |              |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |  78,194.5 ns |    96.70 ns |    85.72 ns |     383 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 735,554.6 ns | 1,868.97 ns | 1,748.23 ns |     383 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 744,018.7 ns | 2,153.85 ns | 1,909.33 ns |     383 B |  133388 B |