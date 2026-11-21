| Description                                | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       433.8 ns |      0.34 ns |      0.31 ns |  20,340 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,013.6 ns |     15.48 ns |     14.48 ns |  26,469 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,701.1 ns |     29.28 ns |     27.38 ns |     306 B |    2584 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       369.5 ns |      0.41 ns |      0.38 ns |  22,645 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |       954.3 ns |      1.89 ns |      1.77 ns |  23,053 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,581.0 ns |      3.40 ns |      2.84 ns |     386 B |    2432 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,329.9 ns |      2.40 ns |      2.25 ns |  14,615 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     6,239.5 ns |     85.75 ns |     80.21 ns |  24,806 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     8,847.3 ns |    135.63 ns |    126.87 ns |     306 B |    3480 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,306.1 ns |      1.13 ns |      1.06 ns |  21,541 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     6,092.6 ns |     11.68 ns |      9.75 ns |  16,165 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     8,641.8 ns |     24.72 ns |     20.64 ns |     386 B |    2432 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,583.7 ns |     14.93 ns |     13.97 ns |  21,412 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    49,338.2 ns |    416.87 ns |    389.94 ns |  14,877 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    65,171.0 ns |  1,013.77 ns |    948.28 ns |     306 B |   10648 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,802.6 ns |     14.01 ns |     13.10 ns |  15,286 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    47,227.0 ns |    151.54 ns |    134.33 ns |  16,184 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    65,440.9 ns |    202.54 ns |    169.13 ns |     386 B |    2432 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   293,402.2 ns |    642.68 ns |    601.17 ns |  89,516 B |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   761,899.8 ns |  7,393.86 ns |  6,916.22 ns |  20,908 B |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,080,277.4 ns | 13,007.41 ns | 12,167.14 ns |     306 B |  133581 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   278,086.2 ns |    194.94 ns |    182.34 ns |  15,268 B |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   752,563.6 ns |  2,273.73 ns |  2,126.85 ns |  25,410 B |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,026,663.3 ns |  3,002.61 ns |  2,507.32 ns |     386 B |    2432 B |