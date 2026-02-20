| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (AES-NI)       | 128B         |     399.2 ns |     0.54 ns |     0.48 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128B         |   1,034.9 ns |     6.19 ns |     5.79 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,620.7 ns |     5.57 ns |     4.65 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128B         |     346.3 ns |     0.61 ns |     0.54 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     977.3 ns |    10.74 ns |     8.39 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,596.8 ns |     5.04 ns |     4.47 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,292.4 ns |    15.86 ns |    13.24 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   6,429.9 ns |    65.64 ns |    54.81 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,206.8 ns |    29.44 ns |    27.54 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,249.5 ns |     3.17 ns |     2.81 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   6,351.5 ns |    10.64 ns |     9.43 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,149.7 ns |    19.30 ns |    16.11 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,515.9 ns |   115.35 ns |   102.26 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  49,411.4 ns |   122.89 ns |   108.94 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  60,244.8 ns |   164.87 ns |   146.15 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,421.2 ns |    18.84 ns |    16.70 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  49,448.3 ns |   174.06 ns |   154.30 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  60,140.8 ns |    87.44 ns |    73.01 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 128KB        | 278,131.9 ns |   805.84 ns |   672.91 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 786,160.4 ns | 1,648.31 ns | 1,376.41 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 955,205.2 ns | 4,178.05 ns | 3,261.95 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128KB        | 278,254.3 ns | 1,606.25 ns | 1,341.29 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 786,663.2 ns | 2,319.05 ns | 2,055.78 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 955,938.3 ns | 2,072.49 ns | 1,730.62 ns |    2464 B |