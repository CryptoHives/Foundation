| Description                          | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (Managed)      | 128B         |     1,025.1 ns |     6.95 ns |     5.80 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |     1,650.7 ns |     5.90 ns |     5.23 ns |    2888 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-128-CCM (Managed)      | 128B         |       986.3 ns |     8.88 ns |     8.30 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |     1,633.9 ns |    12.86 ns |    12.03 ns |    2928 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |     6,518.6 ns |    22.63 ns |    20.06 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |     8,211.1 ns |    72.76 ns |    68.06 ns |    4680 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |     6,502.1 ns |    80.90 ns |    75.68 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |     8,172.1 ns |    79.35 ns |    74.22 ns |    4720 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |    50,483.3 ns |   215.95 ns |   202.00 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |    60,359.7 ns |   150.42 ns |   133.34 ns |   19016 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |    50,277.0 ns |   362.79 ns |   339.36 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |    60,434.3 ns |   370.27 ns |   346.35 ns |   19056 B |
|                                      |              |                |             |             |           |
| Decrypt · AES-128-CCM (Managed)      | 128KB        |   803,797.8 ns | 3,226.82 ns | 2,860.49 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 1,007,847.4 ns | 8,343.07 ns | 7,804.11 ns |  264804 B |
|                                      |              |                |             |             |           |
| Encrypt · AES-128-CCM (Managed)      | 128KB        |   799,080.8 ns | 6,316.14 ns | 5,908.12 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 1,004,402.8 ns | 5,944.09 ns | 5,269.28 ns |  264844 B |