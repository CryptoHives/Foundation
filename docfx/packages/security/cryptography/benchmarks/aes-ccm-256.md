| Description                          | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (AES-NI)       | 128B         |       445.1 ns |      2.21 ns |      2.06 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1,275.4 ns |     14.36 ns |     13.43 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     2,091.1 ns |     41.44 ns |     62.02 ns |    2808 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128B         |       409.2 ns |      1.18 ns |      1.04 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1,231.9 ns |      7.99 ns |      7.48 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,924.8 ns |     12.09 ns |     10.10 ns |    2848 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,730.6 ns |      9.54 ns |      8.46 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8,327.5 ns |    165.58 ns |    154.89 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,723.2 ns |    213.08 ns |    361.83 ns |    2808 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,671.0 ns |      6.24 ns |      5.53 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     8,025.0 ns |     36.29 ns |     30.30 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,112.4 ns |     65.15 ns |     60.94 ns |    2848 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-256-CCM (AES-NI)       | 8KB          |    20,834.5 ns |     65.09 ns |     57.70 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    64,035.2 ns |    872.17 ns |    815.83 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    77,450.0 ns |  1,225.55 ns |  1,146.38 ns |    2808 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-256-CCM (AES-NI)       | 8KB          |    20,987.6 ns |    294.82 ns |    261.35 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    63,250.9 ns |  1,073.22 ns |    951.39 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    76,609.6 ns |  1,320.56 ns |  1,170.64 ns |    2848 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-256-CCM (AES-NI)       | 128KB        |   332,223.2 ns |  2,085.58 ns |  1,741.55 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128KB        |   995,002.8 ns |  6,246.30 ns |  4,876.70 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,202,928.2 ns |  8,444.72 ns |  7,051.73 ns |    2808 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128KB        |   332,356.7 ns |  2,270.99 ns |  2,013.17 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,028,136.7 ns | 20,361.68 ns | 31,094.43 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,211,991.6 ns | 17,618.91 ns | 15,618.71 ns |    2848 B |