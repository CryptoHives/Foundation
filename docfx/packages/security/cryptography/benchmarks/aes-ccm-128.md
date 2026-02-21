| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (AES-NI)       | 128B         |     391.6 ns |     0.68 ns |     0.60 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128B         |     992.3 ns |     5.20 ns |     4.61 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,616.0 ns |     7.68 ns |     7.18 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128B         |     343.3 ns |     0.47 ns |     0.44 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     951.5 ns |     4.60 ns |     4.07 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,570.9 ns |     8.85 ns |     8.28 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,265.0 ns |     7.26 ns |     6.79 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   6,272.5 ns |    33.26 ns |    31.11 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,036.3 ns |    40.59 ns |    35.98 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,220.6 ns |     3.94 ns |     3.29 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   6,253.0 ns |    34.65 ns |    28.93 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,057.5 ns |    66.46 ns |    62.17 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,262.3 ns |    40.04 ns |    37.45 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  48,474.5 ns |   290.80 ns |   272.01 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,094.5 ns |   179.80 ns |   168.18 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,210.0 ns |    28.40 ns |    26.56 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  48,495.6 ns |   238.70 ns |   223.28 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,202.0 ns |   232.16 ns |   217.17 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 128KB        | 274,534.3 ns |   609.29 ns |   569.93 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 768,560.4 ns | 2,640.01 ns | 2,204.53 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 940,559.5 ns | 3,693.70 ns | 3,455.09 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128KB        | 274,729.4 ns |   766.00 ns |   716.52 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 771,740.0 ns | 4,973.16 ns | 4,651.90 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 935,224.2 ns | 3,727.62 ns | 3,486.82 ns |    2464 B |