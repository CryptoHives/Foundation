| Description                                 | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       312.5 ns |      2.27 ns |      2.01 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,236.2 ns |      3.55 ns |      2.96 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,734.5 ns |     15.61 ns |     13.03 ns |    3016 B |
|                                             |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       275.6 ns |      0.53 ns |      0.44 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,195.1 ns |      3.18 ns |      2.65 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,667.4 ns |      6.98 ns |      6.53 ns |    2904 B |
|                                             |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,785.7 ns |     26.68 ns |     22.28 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,919.7 ns |    115.01 ns |    101.95 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,951.6 ns |     71.55 ns |     63.43 ns |    3912 B |
|                                             |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,737.3 ns |      2.55 ns |      2.38 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,793.4 ns |     25.00 ns |     20.88 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,804.9 ns |     14.26 ns |     12.64 ns |    2904 B |
|                                             |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,525.8 ns |    169.96 ns |    141.93 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    60,535.1 ns |     10.54 ns |      8.23 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,298.0 ns |    308.76 ns |    257.83 ns |   11080 B |
|                                             |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,372.0 ns |     30.38 ns |     26.93 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    60,593.3 ns |     80.03 ns |     70.95 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,537.9 ns |  1,008.71 ns |    842.32 ns |    2904 B |
|                                             |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   213,082.4 ns |  1,514.28 ns |  1,342.37 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   971,861.9 ns |  8,690.76 ns |  8,129.34 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,075,623.2 ns | 15,672.78 ns | 14,660.33 ns |  133988 B |
|                                             |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   212,916.6 ns |  1,502.23 ns |  1,405.19 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   966,165.4 ns |  5,685.91 ns |  4,747.99 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,048,971.9 ns | 12,064.40 ns | 10,074.32 ns |    2904 B |