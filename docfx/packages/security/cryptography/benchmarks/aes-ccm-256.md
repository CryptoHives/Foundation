| Description                          | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (AES-NI)       | 128B         |       448.4 ns |     0.93 ns |     0.87 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1,255.9 ns |     7.73 ns |     6.45 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,957.9 ns |    13.54 ns |    12.66 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128B         |       410.1 ns |     0.39 ns |     0.33 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1,217.6 ns |     4.99 ns |     4.42 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,921.1 ns |    15.00 ns |    14.03 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,718.5 ns |     3.56 ns |     3.33 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8,030.4 ns |    29.76 ns |    27.84 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,104.7 ns |    35.73 ns |    33.43 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,683.2 ns |     4.12 ns |     3.85 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     7,971.0 ns |    36.29 ns |    33.94 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,065.2 ns |    44.67 ns |    37.30 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 8KB          |    20,890.5 ns |    27.45 ns |    24.33 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    61,922.9 ns |   559.88 ns |   523.71 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74,739.1 ns |   303.85 ns |   269.35 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 8KB          |    20,843.8 ns |    32.03 ns |    28.39 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    62,044.6 ns |   405.58 ns |   379.38 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74,871.0 ns |   440.90 ns |   412.42 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 128KB        |   332,465.1 ns |   463.97 ns |   411.30 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128KB        |   988,926.0 ns | 7,059.62 ns | 6,603.57 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,183,783.6 ns | 5,958.25 ns | 5,281.84 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128KB        |   332,762.8 ns |   583.91 ns |   546.19 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128KB        |   986,023.7 ns | 4,269.17 ns | 3,784.51 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,185,531.5 ns | 6,162.29 ns | 5,764.21 ns |    2848 B |