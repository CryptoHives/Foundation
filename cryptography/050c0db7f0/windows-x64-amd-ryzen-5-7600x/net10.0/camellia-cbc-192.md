| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.323 μs | 0.0047 μs | 0.0044 μs |     584 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128B         |     1.884 μs | 0.0040 μs | 0.0037 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.312 μs | 0.0020 μs | 0.0018 μs |     584 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128B         |     1.880 μs | 0.0059 μs | 0.0046 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     8.847 μs | 0.0192 μs | 0.0171 μs |    2824 B |
| Decrypt · Camellia-192-CBC (Managed)      | 1KB          |    13.631 μs | 0.0378 μs | 0.0353 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     8.733 μs | 0.0326 μs | 0.0305 μs |    2824 B |
| Encrypt · Camellia-192-CBC (Managed)      | 1KB          |    13.674 μs | 0.0401 μs | 0.0356 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    68.490 μs | 0.2081 μs | 0.1845 μs |   20744 B |
| Decrypt · Camellia-192-CBC (Managed)      | 8KB          |   106.426 μs | 0.4783 μs | 0.4474 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    67.703 μs | 0.1210 μs | 0.1073 μs |   20744 B |
| Encrypt · Camellia-192-CBC (Managed)      | 8KB          |   107.530 μs | 0.2293 μs | 0.2145 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128KB        | 1,107.132 μs | 4.9032 μs | 4.5864 μs |  327944 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,690.812 μs | 5.8450 μs | 5.4674 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128KB        | 1,089.611 μs | 4.5824 μs | 4.0621 μs |  327944 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,715.076 μs | 4.2297 μs | 3.9564 μs |         - |