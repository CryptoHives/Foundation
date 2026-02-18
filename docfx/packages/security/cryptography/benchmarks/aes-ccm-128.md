| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (AES-NI)       | 128B         |     431.1 ns |     2.47 ns |     2.31 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128B         |   1,034.0 ns |     9.98 ns |     9.34 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,593.1 ns |     7.61 ns |     7.11 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128B         |     386.2 ns |     7.72 ns |     7.22 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     989.5 ns |     9.23 ns |     8.63 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,567.9 ns |    13.90 ns |    13.00 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,403.1 ns |     5.53 ns |     4.62 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   6,706.1 ns |    46.62 ns |    43.60 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,061.9 ns |    73.72 ns |    68.96 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,358.0 ns |    14.35 ns |    13.42 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   6,493.8 ns |    49.08 ns |    45.91 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,046.1 ns |    85.72 ns |    80.18 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 8KB          |  18,267.2 ns |    98.15 ns |    91.81 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  50,590.1 ns |   423.57 ns |   396.21 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,186.7 ns |   296.50 ns |   262.84 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 8KB          |  18,157.2 ns |   108.05 ns |   101.07 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  50,538.9 ns |   277.38 ns |   259.46 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,325.9 ns |   292.48 ns |   273.59 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 128KB        | 288,380.8 ns | 1,343.50 ns | 1,121.88 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 804,965.9 ns | 7,040.97 ns | 6,586.13 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 936,185.3 ns | 5,527.44 ns | 5,170.37 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128KB        | 288,893.1 ns | 1,551.30 ns | 1,451.08 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 801,696.3 ns | 5,033.31 ns | 4,708.16 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 941,109.3 ns | 6,890.77 ns | 6,445.63 ns |    2464 B |