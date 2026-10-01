| Description                                 | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     279.4 ns |      1.39 ns |      1.23 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     937.6 ns |      6.46 ns |      6.04 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,349.5 ns |     12.18 ns |     10.17 ns |    2616 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     244.0 ns |      1.29 ns |      1.08 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     895.9 ns |      2.86 ns |      2.39 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,291.5 ns |      6.66 ns |      5.91 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,551.7 ns |      6.98 ns |      5.83 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,871.0 ns |      1.81 ns |      1.41 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,833.8 ns |     33.43 ns |     27.92 ns |    3512 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,514.6 ns |     15.76 ns |     15.47 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,838.8 ns |     13.68 ns |     12.13 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,689.5 ns |     50.39 ns |     47.14 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,676.1 ns |     43.70 ns |     34.11 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  45,445.3 ns |    215.81 ns |    191.31 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,149.8 ns |    136.83 ns |    121.29 ns |   10680 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,575.7 ns |     44.03 ns |     39.03 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  45,677.9 ns |    359.09 ns |    335.89 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,720.7 ns |     33.03 ns |     30.90 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 192,308.4 ns |    287.29 ns |    239.90 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 732,193.1 ns |  1,139.70 ns |  1,066.08 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 815,196.2 ns |  2,949.37 ns |  2,614.54 ns |  133588 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 186,537.1 ns |  2,193.32 ns |  1,944.32 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 734,839.6 ns |  1,508.04 ns |  1,410.62 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 809,835.8 ns | 11,635.65 ns | 10,314.70 ns |    2504 B |