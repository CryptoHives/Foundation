| Description                                | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       526.5 ns |      3.47 ns |      3.25 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,378.6 ns |     19.40 ns |     18.15 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,205.0 ns |     42.07 ns |     45.02 ns |    3016 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       485.2 ns |      2.34 ns |      2.19 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,331.4 ns |     21.64 ns |     20.24 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,150.3 ns |     29.29 ns |     27.40 ns |    2904 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     3,219.7 ns |     15.44 ns |     14.45 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,778.1 ns |     72.59 ns |     67.91 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    11,942.8 ns |    227.32 ns |    212.64 ns |    3912 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     3,177.5 ns |     14.21 ns |     13.29 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,696.3 ns |    100.46 ns |     93.97 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    11,824.5 ns |    147.74 ns |    138.20 ns |    2904 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    24,839.1 ns |    104.62 ns |     97.86 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    68,115.5 ns |  1,111.91 ns |  1,040.08 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    89,347.5 ns |  1,139.78 ns |  1,066.16 ns |   11080 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    24,627.6 ns |    105.62 ns |     98.80 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    67,608.6 ns |    913.92 ns |    854.88 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    88,532.4 ns |    652.28 ns |    544.68 ns |    2904 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   393,982.8 ns |  1,740.19 ns |  1,627.78 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,081,244.7 ns | 19,339.17 ns | 18,089.87 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,446,276.3 ns | 10,516.71 ns |  9,837.33 ns |  133974 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   393,572.6 ns |  1,347.51 ns |  1,260.46 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,077,050.1 ns | 16,390.79 ns | 15,331.96 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,399,858.8 ns | 12,245.50 ns | 10,855.32 ns |    2904 B |