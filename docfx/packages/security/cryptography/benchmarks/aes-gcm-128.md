| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-GCM (OS)           | 128B         |     119.2 ns |     1.01 ns |     0.90 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 128B         |     859.5 ns |     7.03 ns |     6.57 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128B         |     930.9 ns |     6.04 ns |     5.65 ns |    2088 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-GCM (OS)           | 128B         |     116.6 ns |     1.19 ns |     1.11 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128B         |     837.6 ns |     7.34 ns |     6.86 ns |    2072 B |
| Encrypt · AES-128-GCM (Managed)      | 128B         |     846.3 ns |    16.81 ns |    16.51 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-GCM (OS)           | 1KB          |     175.3 ns |     0.82 ns |     0.77 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,757.8 ns |    36.29 ns |    32.17 ns |    3880 B |
| Decrypt · AES-128-GCM (Managed)      | 1KB          |   5,554.7 ns |    42.93 ns |    38.06 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-GCM (OS)           | 1KB          |     169.7 ns |     1.13 ns |     1.06 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,671.6 ns |    24.29 ns |    21.54 ns |    3864 B |
| Encrypt · AES-128-GCM (Managed)      | 1KB          |   5,566.6 ns |    67.62 ns |    56.46 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-GCM (OS)           | 8KB          |     724.5 ns |     5.62 ns |     5.25 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 8KB          |  26,278.4 ns |   288.53 ns |   255.77 ns |   18216 B |
| Decrypt · AES-128-GCM (Managed)      | 8KB          |  43,084.0 ns |   428.18 ns |   400.52 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-GCM (OS)           | 8KB          |     704.3 ns |     4.85 ns |     4.54 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 8KB          |  26,009.6 ns |   161.29 ns |   150.87 ns |   18200 B |
| Encrypt · AES-128-GCM (Managed)      | 8KB          |  43,105.9 ns |   453.65 ns |   424.34 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-GCM (OS)           | 128KB        |  10,821.7 ns |   104.19 ns |    92.36 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128KB        | 466,608.2 ns | 4,420.59 ns | 4,135.02 ns |  264004 B |
| Decrypt · AES-128-GCM (Managed)      | 128KB        | 683,571.4 ns | 5,877.77 ns | 5,210.49 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-GCM (OS)           | 128KB        |   9,698.4 ns |   123.73 ns |   115.73 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128KB        | 461,012.9 ns | 4,126.31 ns | 3,859.75 ns |  263988 B |
| Encrypt · AES-128-GCM (Managed)      | 128KB        | 688,264.0 ns | 6,019.18 ns | 5,630.35 ns |         - |