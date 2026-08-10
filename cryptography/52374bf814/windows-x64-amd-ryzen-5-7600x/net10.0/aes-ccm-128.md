| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (AES-NI)       | 128B         |     400.5 ns |     0.98 ns |     0.92 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128B         |     992.3 ns |     6.26 ns |     5.55 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,598.8 ns |    13.94 ns |    13.04 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128B         |     345.1 ns |     0.78 ns |     0.73 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     957.3 ns |     6.80 ns |     6.36 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,575.8 ns |    10.40 ns |     9.73 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,287.3 ns |     3.87 ns |     3.43 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   6,625.7 ns |    32.52 ns |    30.42 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,013.6 ns |    15.61 ns |    13.03 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 1KB          |   2,242.2 ns |     4.89 ns |     4.34 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   6,225.2 ns |    21.61 ns |    18.05 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   7,962.1 ns |    36.31 ns |    28.35 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,431.8 ns |    48.56 ns |    45.43 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  48,366.1 ns |   246.63 ns |   218.63 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,152.2 ns |   279.28 ns |   247.57 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 8KB          |  17,368.0 ns |    47.69 ns |    44.61 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  48,453.4 ns |   158.32 ns |   140.34 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,074.0 ns |   180.39 ns |   168.74 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (AES-NI)       | 128KB        | 276,834.7 ns |   477.47 ns |   446.62 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 772,132.2 ns | 3,646.06 ns | 3,410.53 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 932,033.8 ns | 2,603.81 ns | 2,308.21 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (AES-NI)       | 128KB        | 276,979.9 ns |   358.57 ns |   299.42 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 772,513.1 ns | 3,687.35 ns | 3,268.74 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 936,123.7 ns | 4,669.35 ns | 4,367.71 ns |    2464 B |