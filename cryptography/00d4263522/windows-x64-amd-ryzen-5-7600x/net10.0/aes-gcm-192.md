| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (OS)                            | 17B          |     120.38 ns |     0.833 ns |     0.780 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     122.59 ns |     0.645 ns |     0.603 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     122.59 ns |     0.432 ns |     0.404 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     361.84 ns |     1.605 ns |     1.423 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     525.86 ns |     4.783 ns |     4.474 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      68.62 ns |     0.238 ns |     0.223 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      69.66 ns |     0.206 ns |     0.193 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     125.09 ns |     0.893 ns |     0.835 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     332.64 ns |     1.288 ns |     1.005 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     471.95 ns |     2.618 ns |     2.320 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     113.29 ns |     0.417 ns |     0.349 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     115.27 ns |     0.597 ns |     0.559 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     123.76 ns |     0.567 ns |     0.503 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     630.55 ns |     6.486 ns |     6.067 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     740.49 ns |     7.087 ns |     6.629 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      75.91 ns |     0.206 ns |     0.193 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      76.27 ns |     0.355 ns |     0.332 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     130.58 ns |     1.077 ns |     1.008 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     600.99 ns |     6.190 ns |     5.790 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     648.03 ns |     6.264 ns |     5.859 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      96.97 ns |     0.582 ns |     0.544 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     100.44 ns |     0.518 ns |     0.484 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     121.77 ns |     0.855 ns |     0.800 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     890.73 ns |     4.819 ns |     4.508 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     905.85 ns |     5.240 ns |     4.902 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      63.64 ns |     0.325 ns |     0.304 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      65.95 ns |     0.354 ns |     0.332 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     123.97 ns |     0.642 ns |     0.569 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     811.28 ns |     6.303 ns |     5.896 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     910.60 ns |     5.843 ns |     5.465 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     125.54 ns |     1.005 ns |     0.940 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     130.02 ns |     0.614 ns |     0.574 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     138.55 ns |     0.792 ns |     0.741 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,044.20 ns |     9.650 ns |     8.555 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,073.06 ns |     7.323 ns |     6.850 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      90.92 ns |     0.898 ns |     0.796 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      92.50 ns |     0.377 ns |     0.353 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     140.50 ns |     0.803 ns |     0.751 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |     964.99 ns |     4.692 ns |     4.159 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,060.25 ns |    19.507 ns |    26.701 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     111.42 ns |     0.532 ns |     0.472 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     125.92 ns |     0.708 ns |     0.662 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     141.29 ns |     1.068 ns |     0.999 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,375.42 ns |     9.866 ns |     9.229 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,629.45 ns |     6.266 ns |     5.861 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      81.39 ns |     0.475 ns |     0.444 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      86.69 ns |     0.387 ns |     0.362 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     131.27 ns |     0.629 ns |     0.525 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,271.09 ns |     9.689 ns |     9.063 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,565.28 ns |     8.925 ns |     7.912 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     190.99 ns |     1.078 ns |     1.008 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     204.08 ns |     0.831 ns |     0.778 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     255.39 ns |     2.817 ns |     2.497 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,155.47 ns |    34.338 ns |    32.120 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,836.49 ns |    33.255 ns |    31.107 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     177.27 ns |     1.653 ns |     1.465 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     189.89 ns |     0.912 ns |     0.853 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     210.16 ns |     1.097 ns |     0.856 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,078.34 ns |    18.809 ns |    15.706 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,810.22 ns |    46.403 ns |    41.135 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     760.43 ns |     6.636 ns |     6.208 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,069.35 ns |     6.974 ns |     6.524 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,459.52 ns |     9.060 ns |     8.475 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  29,765.81 ns |   141.678 ns |   125.594 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  45,466.78 ns |   238.044 ns |   222.667 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     684.03 ns |     3.884 ns |     3.633 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,203.86 ns |     9.554 ns |     8.937 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,372.22 ns |     8.419 ns |     7.875 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  29,710.95 ns |   235.568 ns |   220.350 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  45,574.48 ns |   427.450 ns |   399.837 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  12,346.00 ns |   134.447 ns |   125.762 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,556.70 ns |   113.831 ns |   100.908 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,174.79 ns |   144.988 ns |   135.622 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 471,032.45 ns | 1,633.901 ns | 1,528.352 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 722,675.77 ns | 4,895.219 ns | 4,578.990 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  10,266.43 ns |    67.367 ns |    63.015 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,713.22 ns |   176.574 ns |   165.167 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,338.21 ns |   163.473 ns |   152.913 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 474,136.58 ns | 4,240.878 ns | 3,966.920 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 723,997.03 ns | 7,478.808 ns | 6,245.143 ns |         - |