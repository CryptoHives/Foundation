| Description                                           | TestDataSize | Mean         | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |     259.9 ns |      0.64 ns |      0.57 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |   1,179.1 ns |      5.33 ns |      4.72 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |   1,396.4 ns |     10.78 ns |     10.08 ns |     306 B |    2992 B |
|                                                       |              |              |              |              |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |     219.8 ns |      0.18 ns |      0.16 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |   1,134.5 ns |      4.30 ns |      3.36 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |   1,315.6 ns |      5.68 ns |      5.03 ns |     386 B |    2544 B |
|                                                       |              |              |              |              |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     797.2 ns |      1.75 ns |      1.64 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |   6,116.1 ns |     28.06 ns |     26.24 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |   6,447.2 ns |     38.03 ns |     33.71 ns |     306 B |    7416 B |
|                                                       |              |              |              |              |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     794.3 ns |      0.52 ns |      0.43 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |   5,886.9 ns |     30.84 ns |     27.34 ns |     386 B |    3312 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |   6,091.5 ns |     15.96 ns |     14.15 ns |     386 B |         - |
|                                                       |              |              |              |              |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |   5,080.2 ns |      6.39 ns |      5.34 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |  45,421.8 ns |    169.76 ns |    150.48 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |  46,052.0 ns |    417.12 ns |    369.76 ns |     306 B |   43328 B |
|                                                       |              |              |              |              |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |   5,006.1 ns |      7.66 ns |      6.79 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |  42,637.7 ns |    111.30 ns |     92.94 ns |     386 B |   10480 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |  45,600.4 ns |    117.26 ns |     97.92 ns |     386 B |         - |
|                                                       |              |              |              |              |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |  78,763.6 ns |    134.49 ns |    112.31 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 720,094.7 ns |  2,450.67 ns |  2,172.45 ns |     306 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 879,215.6 ns | 13,501.98 ns | 12,629.76 ns |     306 B |  658039 B |
|                                                       |              |              |              |              |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |  78,756.0 ns |    189.49 ns |    177.25 ns |     386 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 712,531.4 ns |  2,174.35 ns |  1,927.51 ns |     386 B |  133413 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 723,516.6 ns |  1,284.91 ns |  1,072.96 ns |     386 B |         - |