| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (AES-NI)       | 128B         |     396.5 ns |     1.35 ns |     1.26 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128B         |     998.9 ns |     8.03 ns |     7.51 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,609.7 ns |     9.80 ns |     9.17 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128B         |     350.1 ns |     6.70 ns |     6.58 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     969.9 ns |     8.39 ns |     7.84 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,596.2 ns |    31.26 ns |    29.24 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,290.9 ns |     9.14 ns |     8.55 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   6,425.8 ns |    53.06 ns |    47.03 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,189.6 ns |    63.81 ns |    59.69 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,253.9 ns |    10.59 ns |     9.38 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   6,348.2 ns |    77.23 ns |    72.24 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,075.2 ns |    64.35 ns |    60.20 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,514.9 ns |    92.45 ns |    86.48 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  48,882.9 ns |   338.65 ns |   316.77 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,673.3 ns |   233.48 ns |   218.40 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,609.6 ns |   268.45 ns |   237.97 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  48,966.9 ns |   346.38 ns |   289.24 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,484.4 ns |   385.87 ns |   360.95 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 128KB        | 277,366.2 ns |   800.91 ns |   668.80 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 778,917.8 ns | 7,154.78 ns | 6,692.59 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 942,925.0 ns | 5,476.24 ns | 5,122.48 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128KB        | 278,582.3 ns | 2,402.63 ns | 2,006.30 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 779,853.3 ns | 4,577.80 ns | 4,282.08 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 945,927.5 ns | 5,219.84 ns | 4,627.25 ns |    2464 B |