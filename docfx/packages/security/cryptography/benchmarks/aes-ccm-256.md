| Description                          | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (AES-NI)       | 128B         |       443.4 ns |     0.53 ns |     0.44 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1,277.4 ns |     2.05 ns |     1.71 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     2,017.4 ns |     8.93 ns |     7.46 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128B         |       407.9 ns |     0.40 ns |     0.38 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1,239.6 ns |     3.08 ns |     2.88 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,953.6 ns |     7.22 ns |     6.03 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,704.5 ns |    12.41 ns |     9.69 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8,239.7 ns |    62.74 ns |    55.62 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,331.0 ns |    59.84 ns |    55.98 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,664.1 ns |     2.60 ns |     2.31 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     8,366.1 ns |    36.10 ns |    33.77 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,222.6 ns |    22.01 ns |    20.59 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 8KB          |    20,763.4 ns |    33.39 ns |    29.60 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    63,206.7 ns |   198.17 ns |   175.67 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    76,056.9 ns |   221.92 ns |   196.73 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 8KB          |    20,713.8 ns |    27.13 ns |    25.38 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    63,674.2 ns | 1,083.69 ns |   904.93 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    76,121.0 ns |   222.34 ns |   197.10 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 128KB        |   331,181.9 ns |   343.17 ns |   286.57 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128KB        | 1,005,913.0 ns | 2,476.25 ns | 2,067.78 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,208,008.0 ns | 1,721.23 ns | 1,437.31 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128KB        |   330,581.0 ns |   700.30 ns |   620.80 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,010,300.7 ns | 2,887.12 ns | 2,559.36 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,205,328.8 ns | 2,218.21 ns | 2,074.92 ns |    2848 B |