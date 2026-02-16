| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-GCM (OS)           | 128B         |     119.0 ns |     0.96 ns |     0.85 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 128B         |     843.3 ns |     6.07 ns |     5.68 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128B         |     934.6 ns |    10.96 ns |    10.25 ns |    2088 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-GCM (OS)           | 128B         |     119.7 ns |     0.80 ns |     0.71 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 128B         |     807.0 ns |     5.56 ns |     5.20 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128B         |     844.2 ns |     6.37 ns |     5.64 ns |    2072 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-GCM (OS)           | 1KB          |     175.8 ns |     1.40 ns |     1.31 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,788.9 ns |    21.31 ns |    19.93 ns |    3880 B |
| Decrypt · AES-128-GCM (Managed)      | 1KB          |   5,482.2 ns |    37.60 ns |    35.18 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-GCM (OS)           | 1KB          |     168.9 ns |     0.70 ns |     0.58 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,662.8 ns |    33.48 ns |    31.32 ns |    3864 B |
| Encrypt · AES-128-GCM (Managed)      | 1KB          |   5,468.5 ns |    32.08 ns |    30.01 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-GCM (OS)           | 8KB          |     681.1 ns |     4.72 ns |     4.42 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 8KB          |  26,408.3 ns |   211.87 ns |   198.18 ns |   18216 B |
| Decrypt · AES-128-GCM (Managed)      | 8KB          |  42,716.5 ns |   164.15 ns |   145.52 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-GCM (OS)           | 8KB          |     662.5 ns |     4.84 ns |     4.53 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 8KB          |  26,218.6 ns |   233.43 ns |   206.93 ns |   18200 B |
| Encrypt · AES-128-GCM (Managed)      | 8KB          |  42,829.6 ns |   241.94 ns |   226.31 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-GCM (OS)           | 128KB        |  10,895.6 ns |    49.92 ns |    46.70 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128KB        | 468,278.2 ns | 2,288.96 ns | 2,141.09 ns |  264004 B |
| Decrypt · AES-128-GCM (Managed)      | 128KB        | 679,606.7 ns | 5,914.86 ns | 5,532.76 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-GCM (OS)           | 128KB        |   9,649.0 ns |    68.12 ns |    60.39 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128KB        | 461,168.0 ns | 2,769.43 ns | 2,312.60 ns |  263988 B |
| Encrypt · AES-128-GCM (Managed)      | 128KB        | 681,441.0 ns | 3,661.53 ns | 3,425.00 ns |         - |