| Description                                       | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      87.25 ns |      0.152 ns |      0.142 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     352.89 ns |      0.715 ns |      0.669 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     501.00 ns |      0.880 ns |      0.823 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,864.18 ns |      3.436 ns |      3.046 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      52.86 ns |      0.117 ns |      0.109 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     297.16 ns |      0.564 ns |      0.527 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     421.39 ns |      0.451 ns |      0.400 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,483.42 ns |      7.117 ns |      6.658 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      93.93 ns |      0.329 ns |      0.308 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     642.76 ns |      1.344 ns |      1.257 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     682.76 ns |      0.883 ns |      0.826 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,853.32 ns |      5.178 ns |      4.843 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      61.20 ns |      0.495 ns |      0.463 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     616.83 ns |      2.341 ns |      2.190 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     619.18 ns |      0.724 ns |      0.677 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,457.15 ns |      3.945 ns |      3.691 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      91.11 ns |      0.117 ns |      0.109 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     849.79 ns |      1.228 ns |      1.088 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     878.50 ns |      0.900 ns |      0.842 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   1,924.66 ns |     10.417 ns |      9.744 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      61.48 ns |      0.313 ns |      0.293 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     825.66 ns |      0.693 ns |      0.615 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     900.08 ns |      8.717 ns |      8.154 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,500.57 ns |      5.164 ns |      4.830 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     115.39 ns |      0.259 ns |      0.243 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,001.10 ns |      1.264 ns |      1.183 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,011.25 ns |      2.062 ns |      1.929 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   1,919.82 ns |     15.138 ns |     14.160 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      84.31 ns |      0.339 ns |      0.317 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     953.47 ns |      1.823 ns |      1.705 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,022.74 ns |      1.995 ns |      1.866 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,493.53 ns |      4.300 ns |      4.023 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     118.77 ns |      0.570 ns |      0.533 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,373.51 ns |      3.310 ns |      3.096 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,542.07 ns |      4.331 ns |      4.052 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   1,941.79 ns |      9.053 ns |      8.468 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      82.60 ns |      0.142 ns |      0.132 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,336.66 ns |      1.534 ns |      1.435 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,488.23 ns |      2.054 ns |      1.921 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,515.79 ns |      4.710 ns |      4.406 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     294.52 ns |      1.390 ns |      1.232 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,019.38 ns |     14.525 ns |     13.587 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,332.59 ns |      5.599 ns |      5.238 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,514.00 ns |      6.935 ns |      6.487 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     255.97 ns |      0.844 ns |      0.790 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,623.84 ns |      6.807 ns |      6.367 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,409.49 ns |     18.558 ns |     17.359 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,763.28 ns |     55.476 ns |     51.892 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,868.96 ns |      2.890 ns |      2.562 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   2,911.79 ns |     12.025 ns |     11.248 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  31,765.29 ns |     48.327 ns |     45.205 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  46,350.77 ns |    268.412 ns |    251.073 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,810.97 ns |     10.802 ns |     10.104 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   2,453.45 ns |     20.043 ns |     18.749 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  33,076.99 ns |     50.224 ns |     44.523 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  42,741.63 ns |    258.885 ns |    242.161 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,349.10 ns |     68.254 ns |     63.845 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  30,354.46 ns |    540.607 ns |  1,274.274 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 501,972.85 ns |  1,156.101 ns |  1,081.418 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 735,458.48 ns |  4,198.353 ns |  3,927.142 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  23,698.34 ns |     96.579 ns |     90.340 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  28,678.96 ns |     72.803 ns |     60.794 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 525,668.56 ns |    728.213 ns |    681.171 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 695,535.80 ns | 13,870.521 ns | 14,841.302 ns |         - |