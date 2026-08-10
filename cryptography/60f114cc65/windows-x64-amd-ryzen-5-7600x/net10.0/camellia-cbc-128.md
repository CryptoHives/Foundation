| Description                               | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128B         |     1,009.8 ns |     4.95 ns |     4.63 ns |     576 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128B         |     1,444.8 ns |     6.87 ns |     6.42 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128B         |       997.7 ns |     8.44 ns |     7.48 ns |     576 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128B         |     1,416.4 ns |    12.41 ns |    11.61 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     6,637.9 ns |    26.38 ns |    24.67 ns |    2816 B |
| Decrypt · Camellia-128-CBC (Managed)      | 1KB          |    10,267.4 ns |    27.95 ns |    24.78 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     6,506.7 ns |    19.40 ns |    18.14 ns |    2816 B |
| Encrypt · Camellia-128-CBC (Managed)      | 1KB          |     9,998.4 ns |   107.12 ns |    89.45 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    51,235.0 ns |   213.18 ns |   188.98 ns |   20736 B |
| Decrypt · Camellia-128-CBC (Managed)      | 8KB          |    81,495.4 ns |   318.67 ns |   298.08 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    50,999.7 ns |   194.29 ns |   151.69 ns |   20736 B |
| Encrypt · Camellia-128-CBC (Managed)      | 8KB          |    78,669.2 ns |   401.84 ns |   335.55 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   823,018.9 ns | 4,471.82 ns | 3,964.15 ns |  327936 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,302,355.4 ns | 7,367.33 ns | 6,891.40 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   808,957.6 ns | 4,767.09 ns | 4,459.14 ns |  327936 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,251,307.9 ns | 6,437.50 ns | 5,375.61 ns |         - |