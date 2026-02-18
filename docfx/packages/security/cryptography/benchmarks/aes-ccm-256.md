| Description                          | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (AES-NI)       | 128B         |       509.3 ns |     3.92 ns |     3.67 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1,287.3 ns |    10.44 ns |     9.76 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,958.9 ns |    12.16 ns |    11.38 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128B         |       463.9 ns |     3.66 ns |     3.42 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1,255.0 ns |    12.82 ns |    11.99 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1,916.4 ns |     6.78 ns |     6.34 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,814.7 ns |    17.09 ns |    15.99 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8,234.0 ns |    53.81 ns |    50.33 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,104.2 ns |    28.30 ns |    25.09 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,798.2 ns |    17.99 ns |    16.82 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     8,206.3 ns |    60.09 ns |    53.27 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,157.4 ns |   110.05 ns |   102.94 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 8KB          |    21,247.5 ns |    99.95 ns |    93.49 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    63,777.9 ns |   547.94 ns |   512.54 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74,817.8 ns |   555.57 ns |   492.50 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 8KB          |    21,325.3 ns |   106.91 ns |   100.00 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    63,858.5 ns |   533.72 ns |   499.25 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74,806.7 ns |   592.33 ns |   554.07 ns |    2848 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-256-CCM (AES-NI)       | 128KB        |   340,635.3 ns | 1,552.07 ns | 1,451.81 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128KB        | 1,015,249.8 ns | 6,028.36 ns | 5,033.96 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,185,649.3 ns | 5,608.82 ns | 5,246.49 ns |    2808 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128KB        |   339,795.0 ns | 1,838.13 ns | 1,719.39 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,015,335.2 ns | 7,555.05 ns | 7,067.00 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,188,062.3 ns | 8,414.51 ns | 7,870.94 ns |    2848 B |