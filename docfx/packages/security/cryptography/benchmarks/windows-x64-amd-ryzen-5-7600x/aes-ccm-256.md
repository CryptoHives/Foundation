| Description                          | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (AES-NI)       | 128B         |       443.7 ns |     0.71 ns |     0.59 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1,252.7 ns |     4.40 ns |     4.12 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,954.9 ns |     9.34 ns |     8.28 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128B         |       409.6 ns |     0.69 ns |     0.65 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1,213.6 ns |     3.42 ns |     2.86 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,916.6 ns |    14.40 ns |    13.47 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,709.6 ns |     6.36 ns |     5.95 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     7,991.9 ns |    34.96 ns |    32.71 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,110.7 ns |    58.75 ns |    54.95 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,674.9 ns |     5.33 ns |     4.73 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     7,949.5 ns |    17.26 ns |    14.42 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,052.9 ns |    48.15 ns |    42.68 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 8KB          |    20,836.2 ns |    23.93 ns |    19.98 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    61,844.9 ns |   436.10 ns |   386.59 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74,781.8 ns |   352.01 ns |   329.27 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 8KB          |    20,798.7 ns |    34.71 ns |    32.47 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    61,876.2 ns |   303.40 ns |   253.35 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74,650.1 ns |   338.46 ns |   316.60 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 128KB        |   331,843.4 ns |   819.39 ns |   766.46 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128KB        |   981,880.8 ns | 3,010.77 ns | 2,816.27 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,183,622.0 ns | 5,562.39 ns | 5,203.06 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128KB        |   331,552.7 ns |   600.17 ns |   501.17 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128KB        |   985,507.2 ns | 5,331.94 ns | 4,726.63 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,181,070.8 ns | 4,758.17 ns | 3,973.29 ns |    2848 B |