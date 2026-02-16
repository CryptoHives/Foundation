| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-GCM (OS)           | 128B         |     123.6 ns |     0.89 ns |     0.83 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 128B         |     980.3 ns |    11.06 ns |    10.34 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128B         |   1,109.3 ns |    10.67 ns |     9.98 ns |    2312 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 128B         |     124.3 ns |     1.06 ns |     0.94 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 128B         |     944.8 ns |    10.31 ns |     9.64 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128B         |   1,014.0 ns |    11.57 ns |    10.82 ns |    2296 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 1KB          |     212.8 ns |     1.10 ns |     1.03 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,797.8 ns |    28.63 ns |    25.38 ns |    4104 B |
| Decrypt · AES-256-GCM (Managed)      | 1KB          |   6,404.2 ns |    38.40 ns |    35.92 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 1KB          |     180.3 ns |     1.76 ns |     1.65 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,684.0 ns |    39.18 ns |    36.64 ns |    4088 B |
| Encrypt · AES-256-GCM (Managed)      | 1KB          |   6,363.8 ns |    65.06 ns |    57.67 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 8KB          |     949.0 ns |     3.79 ns |     3.16 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 8KB          |  34,300.7 ns |   262.48 ns |   245.52 ns |   18440 B |
| Decrypt · AES-256-GCM (Managed)      | 8KB          |  49,914.6 ns |   424.67 ns |   397.24 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 8KB          |     721.9 ns |     5.00 ns |     4.67 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 8KB          |  34,077.3 ns |   160.83 ns |   150.44 ns |   18424 B |
| Encrypt · AES-256-GCM (Managed)      | 8KB          |  49,712.8 ns |   355.76 ns |   332.78 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 128KB        |  16,235.1 ns |   309.78 ns |   289.76 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128KB        | 589,755.5 ns | 4,693.14 ns | 4,160.35 ns |  264228 B |
| Decrypt · AES-256-GCM (Managed)      | 128KB        | 793,575.3 ns | 5,452.22 ns | 4,552.85 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 128KB        |  10,617.8 ns |    84.89 ns |    75.25 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128KB        | 586,872.2 ns | 3,881.40 ns | 3,630.66 ns |  264212 B |
| Encrypt · AES-256-GCM (Managed)      | 128KB        | 794,061.9 ns | 4,874.59 ns | 4,559.70 ns |         - |