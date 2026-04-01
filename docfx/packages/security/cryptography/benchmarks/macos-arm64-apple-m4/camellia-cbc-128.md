| Description                               | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128B         |       930.9 ns |     1.39 ns |     1.23 ns |     576 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128B         |     1,442.9 ns |     5.45 ns |     5.10 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128B         |       906.0 ns |     0.89 ns |     0.74 ns |     576 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128B         |     1,541.0 ns |    18.37 ns |    17.18 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     5,819.7 ns |    12.68 ns |    11.86 ns |    2816 B |
| Decrypt · Camellia-128-CBC (Managed)      | 1KB          |    10,318.2 ns |    59.01 ns |    55.20 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     5,935.5 ns |    12.76 ns |    11.93 ns |    2816 B |
| Encrypt · Camellia-128-CBC (Managed)      | 1KB          |    10,840.3 ns |    21.60 ns |    20.20 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    45,077.4 ns |   123.42 ns |   115.45 ns |   20736 B |
| Decrypt · Camellia-128-CBC (Managed)      | 8KB          |    81,270.2 ns |   575.14 ns |   537.99 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    45,478.1 ns |   138.37 ns |   129.43 ns |   20736 B |
| Encrypt · Camellia-128-CBC (Managed)      | 8KB          |    85,170.7 ns |   244.50 ns |   228.70 ns |         - |
|                                           |              |                |             |             |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   737,510.6 ns | 1,487.94 ns | 1,391.82 ns |  327936 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,299,903.3 ns | 5,020.73 ns | 4,450.74 ns |         - |
|                                           |              |                |             |             |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   719,839.6 ns | 2,435.91 ns | 2,278.56 ns |  327936 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,377,271.3 ns | 8,525.38 ns | 7,974.65 ns |         - |