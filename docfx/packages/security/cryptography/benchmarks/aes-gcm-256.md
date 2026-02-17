| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-GCM (OS)           | 128B         |     123.4 ns |     0.72 ns |     0.64 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 128B         |     966.2 ns |     7.62 ns |     6.36 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128B         |   1,081.9 ns |     8.74 ns |     7.30 ns |    1832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 128B         |     130.9 ns |     0.63 ns |     0.56 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 128B         |     928.7 ns |     3.87 ns |     3.23 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128B         |     985.7 ns |     6.82 ns |     6.38 ns |    1816 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 1KB          |     211.0 ns |     1.59 ns |     1.33 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,735.7 ns |    53.33 ns |    49.88 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)      | 1KB          |   6,532.4 ns |    35.24 ns |    31.24 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 1KB          |     181.6 ns |     0.89 ns |     0.83 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,631.4 ns |    37.39 ns |    34.97 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)      | 1KB          |   6,342.0 ns |    35.82 ns |    31.75 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 8KB          |     921.7 ns |     3.75 ns |     3.13 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 8KB          |  33,786.4 ns |   302.46 ns |   282.92 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)      | 8KB          |  49,447.1 ns |   293.91 ns |   274.93 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 8KB          |     713.1 ns |     5.14 ns |     4.81 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 8KB          |  33,639.8 ns |   296.08 ns |   262.47 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)      | 8KB          |  49,322.9 ns |   267.96 ns |   250.65 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-GCM (OS)           | 128KB        |  14,307.6 ns |    55.28 ns |    49.00 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128KB        | 533,370.3 ns | 3,310.62 ns | 3,096.75 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)      | 128KB        | 798,247.8 ns | 4,021.70 ns | 3,761.90 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-GCM (OS)           | 128KB        |  11,201.6 ns |    72.44 ns |    64.22 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128KB        | 536,411.5 ns | 3,988.12 ns | 3,535.37 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)      | 128KB        | 789,787.2 ns | 6,355.20 ns | 5,944.65 ns |         - |