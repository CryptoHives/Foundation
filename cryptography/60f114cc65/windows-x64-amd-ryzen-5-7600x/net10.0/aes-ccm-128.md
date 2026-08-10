| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (AES-NI)       | 128B         |     401.0 ns |     1.65 ns |     1.29 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128B         |   1,007.8 ns |     9.08 ns |     8.49 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,626.7 ns |    11.95 ns |    11.17 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128B         |     352.9 ns |     1.11 ns |     0.98 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     968.4 ns |    11.16 ns |     9.90 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,588.9 ns |    14.63 ns |    13.69 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,291.3 ns |     5.82 ns |     5.16 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   6,318.0 ns |    46.31 ns |    43.32 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,122.3 ns |    47.06 ns |    44.02 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,248.5 ns |     5.60 ns |     4.97 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   6,303.8 ns |    38.42 ns |    35.94 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,082.1 ns |    57.54 ns |    48.05 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,694.7 ns |   154.02 ns |   120.25 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  49,884.2 ns |   563.24 ns |   499.30 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  60,955.1 ns |   613.93 ns |   574.27 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,483.4 ns |    83.27 ns |    73.82 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  48,906.6 ns |   260.37 ns |   243.55 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  60,040.4 ns |   359.25 ns |   336.04 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 128KB        | 281,169.4 ns | 2,618.66 ns | 2,449.49 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 797,137.3 ns | 9,556.13 ns | 7,979.80 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 966,882.5 ns | 9,239.59 ns | 7,715.48 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128KB        | 277,799.9 ns |   573.65 ns |   479.03 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 777,035.0 ns | 4,378.12 ns | 4,095.30 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 950,361.4 ns | 4,562.74 ns | 4,267.99 ns |    2464 B |