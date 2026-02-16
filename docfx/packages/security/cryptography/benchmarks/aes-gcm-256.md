| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-GCM (OS)           | 128B         |     125.4 ns |     0.63 ns |     0.56 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 128B         |     964.8 ns |     5.76 ns |     5.10 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128B         |   1,120.2 ns |    11.08 ns |    10.37 ns |    2312 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 128B         |     125.0 ns |     0.92 ns |     0.82 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 128B         |     929.2 ns |     6.07 ns |     5.38 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128B         |   1,022.6 ns |     8.25 ns |     7.31 ns |    2296 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 1KB          |     209.9 ns |     0.75 ns |     0.67 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,849.6 ns |    48.50 ns |    42.99 ns |    4104 B |
| Decrypt · AES-256-GCM (Managed)      | 1KB          |   6,388.0 ns |    44.03 ns |    39.03 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 1KB          |     182.8 ns |     1.12 ns |     1.05 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,746.7 ns |    35.31 ns |    29.49 ns |    4088 B |
| Encrypt · AES-256-GCM (Managed)      | 1KB          |   6,370.0 ns |    56.25 ns |    49.87 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 8KB          |     936.8 ns |    18.36 ns |    23.22 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 8KB          |  34,264.6 ns |   292.28 ns |   273.40 ns |   18440 B |
| Decrypt · AES-256-GCM (Managed)      | 8KB          |  49,325.2 ns |   627.75 ns |   587.19 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 8KB          |     716.2 ns |     5.41 ns |     4.80 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 8KB          |  34,228.5 ns |   141.67 ns |   125.59 ns |   18424 B |
| Encrypt · AES-256-GCM (Managed)      | 8KB          |  49,309.9 ns |   393.35 ns |   367.94 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 128KB        |  14,439.8 ns |    51.56 ns |    48.23 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128KB        | 588,791.8 ns | 5,793.39 ns | 4,837.74 ns |  264228 B |
| Decrypt · AES-256-GCM (Managed)      | 128KB        | 783,364.0 ns | 4,616.38 ns | 4,318.17 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 128KB        |  10,705.6 ns |    66.97 ns |    59.37 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128KB        | 592,079.0 ns | 3,365.92 ns | 2,810.69 ns |  264212 B |
| Encrypt · AES-256-GCM (Managed)      | 128KB        | 788,267.4 ns | 5,556.84 ns | 4,925.99 ns |         - |