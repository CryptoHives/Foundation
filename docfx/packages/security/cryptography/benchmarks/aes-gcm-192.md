| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-192-GCM (OS)           | 128B         |     122.1 ns |     0.50 ns |     0.44 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 128B         |     908.4 ns |     2.81 ns |     2.50 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128B         |     977.4 ns |     4.16 ns |     3.25 ns |    1728 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 128B         |     121.9 ns |     0.75 ns |     0.70 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 128B         |     870.2 ns |     2.90 ns |     2.71 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128B         |     899.2 ns |     6.15 ns |     5.75 ns |    1712 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 1KB          |     194.0 ns |     1.00 ns |     0.93 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,187.7 ns |    42.29 ns |    37.49 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)      | 1KB          |   5,959.1 ns |    46.81 ns |    43.79 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 1KB          |     175.8 ns |     1.22 ns |     1.14 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,105.0 ns |    33.94 ns |    30.09 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)      | 1KB          |   5,974.7 ns |    22.66 ns |    21.19 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 8KB          |     754.4 ns |     3.57 ns |     3.34 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 8KB          |  30,024.9 ns |    88.60 ns |    82.87 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)      | 8KB          |  46,112.4 ns |   224.14 ns |   198.69 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 8KB          |     686.2 ns |     3.24 ns |     2.71 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 8KB          |  29,551.0 ns |   188.15 ns |   166.79 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)      | 8KB          |  46,391.0 ns |   258.27 ns |   228.95 ns |         - |
|                                      |              |              |             |             |           |
| Decrypt · AES-192-GCM (OS)           | 128KB        |  11,699.5 ns |    41.92 ns |    35.01 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128KB        | 473,453.9 ns | 3,136.17 ns | 2,933.57 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)      | 128KB        | 749,539.8 ns | 5,537.85 ns | 4,909.16 ns |         - |
|                                      |              |              |             |             |           |
| Encrypt · AES-192-GCM (OS)           | 128KB        |  10,170.2 ns |    66.04 ns |    58.54 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128KB        | 469,098.1 ns | 3,150.16 ns | 2,946.67 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)      | 128KB        | 735,242.7 ns | 4,296.09 ns | 3,808.37 ns |         - |