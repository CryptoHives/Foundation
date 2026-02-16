| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-192-GCM (OS)           | 128B         |     122.2 ns |     1.55 ns |     1.45 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 128B         |     903.4 ns |     4.30 ns |     4.02 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128B         |   1,026.5 ns |     7.45 ns |     6.61 ns |    2200 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 128B         |     127.1 ns |     1.17 ns |     1.09 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 128B         |     868.5 ns |     3.68 ns |     3.44 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128B         |     937.0 ns |    10.16 ns |     9.50 ns |    2184 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 1KB          |     188.4 ns |     1.33 ns |     1.24 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,331.5 ns |    34.14 ns |    31.94 ns |    3992 B |
| Decrypt · AES-192-GCM (Managed)      | 1KB          |   5,924.7 ns |    40.10 ns |    37.51 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 1KB          |     176.2 ns |     0.89 ns |     0.79 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,202.9 ns |    27.64 ns |    21.58 ns |    3976 B |
| Encrypt · AES-192-GCM (Managed)      | 1KB          |   6,077.2 ns |    27.21 ns |    25.45 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 8KB          |     754.6 ns |     2.86 ns |     2.54 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 8KB          |  30,375.8 ns |   158.28 ns |   132.17 ns |   18328 B |
| Decrypt · AES-192-GCM (Managed)      | 8KB          |  46,118.9 ns |   259.60 ns |   230.12 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 8KB          |     684.2 ns |     2.69 ns |     2.10 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 8KB          |  30,331.3 ns |   247.70 ns |   231.70 ns |   18312 B |
| Encrypt · AES-192-GCM (Managed)      | 8KB          |  46,163.8 ns |   187.09 ns |   165.85 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 128KB        |  11,626.1 ns |    91.48 ns |    85.57 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128KB        | 528,492.7 ns | 5,427.92 ns | 5,077.28 ns |  264116 B |
| Decrypt · AES-192-GCM (Managed)      | 128KB        | 736,246.4 ns | 2,988.46 ns | 2,795.41 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 128KB        |  10,194.6 ns |    90.88 ns |    85.01 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128KB        | 527,180.3 ns | 3,916.73 ns | 3,663.71 ns |  264100 B |
| Encrypt · AES-192-GCM (Managed)      | 128KB        | 735,198.1 ns | 2,303.78 ns | 2,042.24 ns |         - |