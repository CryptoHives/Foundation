| Description                          | TestDataSize | Mean           | Error     | StdDev    | Allocated |
|------------------------------------- |------------- |---------------:|----------:|----------:|----------:|
| Decrypt · AES-256-CCM (ArmAes)       | 128B         |       299.9 ns |   1.13 ns |   1.06 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1,252.1 ns |   1.36 ns |   1.27 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,785.1 ns |   3.98 ns |   3.73 ns |    2808 B |
|                                      |              |                |           |           |           |
| Encrypt · AES-256-CCM (ArmAes)       | 128B         |       265.4 ns |   1.55 ns |   1.45 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1,208.7 ns |   0.83 ns |   0.65 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,743.7 ns |   4.22 ns |   3.94 ns |    2848 B |
|                                      |              |                |           |           |           |
| Decrypt · AES-256-CCM (ArmAes)       | 1KB          |     1,707.3 ns |   5.60 ns |   5.24 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     7,946.1 ns |   3.66 ns |   3.42 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |     8,898.1 ns |   2.81 ns |   2.49 ns |    2808 B |
|                                      |              |                |           |           |           |
| Encrypt · AES-256-CCM (ArmAes)       | 1KB          |     1,670.1 ns |   6.02 ns |   5.63 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     7,898.7 ns |   2.85 ns |   2.53 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |     8,859.8 ns |   1.49 ns |   1.32 ns |    2848 B |
|                                      |              |                |           |           |           |
| Decrypt · AES-256-CCM (ArmAes)       | 8KB          |    12,868.8 ns |  32.20 ns |  30.12 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    61,446.4 ns |  25.35 ns |  23.72 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    65,644.3 ns |  34.18 ns |  30.30 ns |    2808 B |
|                                      |              |                |           |           |           |
| Encrypt · AES-256-CCM (ArmAes)       | 8KB          |    12,807.3 ns |  44.59 ns |  41.71 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    61,295.6 ns |  22.59 ns |  20.03 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    65,412.6 ns |  33.97 ns |  31.78 ns |    2848 B |
|                                      |              |                |           |           |           |
| Decrypt · AES-256-CCM (ArmAes)       | 128KB        |   205,913.9 ns | 612.81 ns | 543.24 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128KB        |   979,175.3 ns | 592.66 ns | 554.37 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,040,518.4 ns | 673.52 ns | 630.01 ns |    2808 B |
|                                      |              |                |           |           |           |
| Encrypt · AES-256-CCM (ArmAes)       | 128KB        |   204,195.7 ns | 643.92 ns | 602.32 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128KB        |   977,042.6 ns | 740.09 ns | 656.07 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,038,874.9 ns | 506.46 ns | 473.74 ns |    2848 B |