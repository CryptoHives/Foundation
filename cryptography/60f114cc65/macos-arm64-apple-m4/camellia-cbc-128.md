| Description                               | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128B         |       933.7 ns |     1.00 ns |     0.93 ns |     576 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128B         |     1,439.8 ns |     4.90 ns |     4.58 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128B         |       903.6 ns |     0.40 ns |     0.38 ns |     576 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128B         |     1,528.9 ns |     7.63 ns |     6.37 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     5,815.3 ns |     7.68 ns |     7.18 ns |    2816 B |
| Decrypt · Camellia-128-CBC (Managed)      | 1KB          |    10,289.1 ns |    56.89 ns |    50.43 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     5,943.2 ns |     5.22 ns |     4.88 ns |    2816 B |
| Encrypt · Camellia-128-CBC (Managed)      | 1KB          |    10,797.6 ns |    26.33 ns |    24.63 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    45,076.8 ns |    87.36 ns |    81.72 ns |   20736 B |
| Decrypt · Camellia-128-CBC (Managed)      | 8KB          |    81,301.4 ns |   464.41 ns |   434.41 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    47,091.1 ns |    70.08 ns |    65.55 ns |   20736 B |
| Encrypt · Camellia-128-CBC (Managed)      | 8KB          |    84,936.4 ns |   171.39 ns |   160.31 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   717,751.6 ns | 1,378.98 ns | 1,289.90 ns |  327936 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,300,993.7 ns | 6,997.57 ns | 6,545.53 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   724,379.5 ns | 1,474.92 ns | 1,379.64 ns |  327936 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,369,328.2 ns | 9,196.41 ns | 8,602.32 ns |         - |