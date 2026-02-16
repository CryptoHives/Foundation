| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-192-GCM (OS)           | 128B         |     140.0 ns |     0.90 ns |     0.85 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 128B         |     915.1 ns |     6.47 ns |     6.05 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128B         |   1,012.2 ns |    12.09 ns |    11.31 ns |    2200 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 128B         |     120.3 ns |     0.82 ns |     0.77 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 128B         |     883.5 ns |     7.69 ns |     7.19 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128B         |     933.1 ns |     6.93 ns |     6.49 ns |    2184 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 1KB          |     206.3 ns |     1.19 ns |     1.11 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,287.4 ns |    25.67 ns |    22.76 ns |    3992 B |
| Decrypt · AES-192-GCM (Managed)      | 1KB          |   5,984.4 ns |    35.53 ns |    33.23 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 1KB          |     174.2 ns |     1.74 ns |     1.62 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,182.3 ns |    41.43 ns |    38.75 ns |    3976 B |
| Encrypt · AES-192-GCM (Managed)      | 1KB          |   5,987.4 ns |    46.42 ns |    41.15 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 8KB          |     773.3 ns |     8.39 ns |     7.85 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 8KB          |  30,405.8 ns |   243.26 ns |   227.55 ns |   18328 B |
| Decrypt · AES-192-GCM (Managed)      | 8KB          |  46,705.3 ns |   323.62 ns |   286.88 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 8KB          |     693.7 ns |     5.29 ns |     4.95 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 8KB          |  30,151.1 ns |   378.83 ns |   354.36 ns |   18312 B |
| Encrypt · AES-192-GCM (Managed)      | 8KB          |  46,444.3 ns |   283.50 ns |   265.18 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 128KB        |  11,623.4 ns |   134.66 ns |   125.96 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128KB        | 522,252.2 ns | 2,927.33 ns | 2,738.23 ns |  264116 B |
| Decrypt · AES-192-GCM (Managed)      | 128KB        | 740,285.4 ns | 5,851.24 ns | 4,886.05 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 128KB        |  10,194.1 ns |   106.17 ns |    94.12 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128KB        | 519,261.3 ns | 2,718.80 ns | 2,543.16 ns |  264100 B |
| Encrypt · AES-192-GCM (Managed)      | 128KB        | 738,583.2 ns | 5,887.33 ns | 5,507.01 ns |         - |