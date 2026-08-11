| Description                                       | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      80.34 ns |      1.407 ns |      1.316 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     353.22 ns |      5.455 ns |      5.103 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     498.25 ns |      2.274 ns |      1.776 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,897.18 ns |     24.387 ns |     22.812 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      53.63 ns |      0.556 ns |      0.520 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     314.13 ns |      2.543 ns |      2.124 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     426.84 ns |      6.354 ns |      5.944 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,728.01 ns |     25.188 ns |     23.561 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     117.00 ns |      1.338 ns |      1.252 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     622.00 ns |      9.948 ns |      9.305 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     701.71 ns |     11.743 ns |     10.984 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,904.71 ns |     25.118 ns |     23.495 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      85.77 ns |      1.090 ns |      1.020 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     574.55 ns |      1.334 ns |      1.041 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     641.29 ns |     11.912 ns |     11.142 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,723.81 ns |     24.089 ns |     22.533 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     153.58 ns |      2.292 ns |      2.144 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     874.42 ns |     11.230 ns |     10.504 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     905.78 ns |     12.438 ns |     11.635 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   1,907.54 ns |     10.055 ns |      7.850 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     118.69 ns |      0.313 ns |      0.244 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     845.64 ns |     12.960 ns |     12.122 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     861.67 ns |     12.148 ns |     11.363 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,750.19 ns |     23.467 ns |     21.951 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     192.79 ns |      2.583 ns |      2.417 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,012.74 ns |      0.939 ns |      0.733 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,048.62 ns |      2.639 ns |      2.061 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   1,928.31 ns |     11.179 ns |      8.727 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     150.84 ns |      0.435 ns |      0.339 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     983.42 ns |      0.726 ns |      0.567 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,006.41 ns |      0.790 ns |      0.617 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,749.16 ns |     21.906 ns |     20.491 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     261.00 ns |      1.963 ns |      1.532 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,412.19 ns |     22.641 ns |     21.179 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,589.60 ns |     22.097 ns |     20.669 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   1,937.33 ns |      9.776 ns |      7.633 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     220.65 ns |      2.183 ns |      2.042 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,410.85 ns |     26.007 ns |     24.327 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,554.04 ns |     21.760 ns |     20.354 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,764.87 ns |     23.161 ns |     21.665 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     866.43 ns |      8.669 ns |      8.109 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,044.68 ns |     12.217 ns |      9.538 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,417.37 ns |      2.338 ns |      1.825 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,685.52 ns |     81.314 ns |     76.061 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     820.09 ns |      8.935 ns |      8.358 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,850.29 ns |     12.816 ns |     10.006 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,697.66 ns |     91.837 ns |     85.905 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,566.20 ns |     80.939 ns |     75.710 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   2,948.24 ns |     41.766 ns |     39.068 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,486.39 ns |     58.844 ns |     55.043 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  32,295.37 ns |     69.246 ns |     54.063 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  43,672.29 ns |    663.841 ns |    620.958 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   2,847.42 ns |     49.279 ns |     46.095 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,453.50 ns |     69.879 ns |     61.946 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  35,133.58 ns |    690.335 ns |    645.740 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  43,568.55 ns |    609.520 ns |    570.146 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,763.78 ns |    339.715 ns |    317.770 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 103,700.25 ns |    856.459 ns |    801.132 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 510,540.57 ns |    826.760 ns |    645.480 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 695,746.54 ns | 10,709.484 ns | 10,017.658 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  19,801.19 ns |    384.327 ns |    442.592 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 104,027.90 ns |  1,626.452 ns |  1,521.384 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 551,848.98 ns |    670.319 ns |    523.341 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 696,214.27 ns | 12,963.508 ns | 12,126.073 ns |         - |